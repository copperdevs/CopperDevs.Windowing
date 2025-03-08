using System.Buffers;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using ImGuiNET;
using SDL;
using static SDL.SDL3;
using GamepadEventValue = (
    ImGuiNET.ImGuiKey? Input1,
    float Value1,
    ImGuiNET.ImGuiKey?
    Input2, float Value2);

namespace CopperDevs.Windowing.Testing;

/// <summary>
/// ImGui backend for SDL3.
/// </summary>
public static unsafe class ImGuiSdl3
{
    /// <summary>
    /// Function definition for a callback to set clipboard data.
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalUsing(typeof(Utf8StringMarshaller))]
    private delegate string? ImGuiGetClipboardCallback(IntPtr ctx);

    /// <summary>
    /// Function definition for a callback to set clipboard data.
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void ImGuiSetClipboardCallback(
        IntPtr ctx,
        [MarshalUsing(typeof(Utf8StringMarshaller))] string? text);

    /// <summary>
    /// Function definition for a callback that can be specified instead of
    /// the standard rendering pipeline.
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void ImGuiUserCallback(
        ImDrawList* cmdList,
        ImDrawCmd* drawCmd);

    /// <summary>
    /// Function definition for a callback for when an input interface is
    /// activated (such as virtual keyboards, etc.)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void ImGuiPlatformSetImeDataCallback(
        IntPtr ctx,
        ImGuiViewport* viewport,
        ImGuiPlatformImeData* data);

    /// <summary>
    /// Gamepad stick dead zone. This determines how far from center the stick
    /// must be in order to be counted as inputs for ImGui control.
    /// </summary>
    private const float DefaultDeadZone = 0.2f;

    /// <summary>
    /// Number of mouse cursors that ImGui may use.
    /// </summary>
    private const int CursorCount = (int)ImGuiMouseCursor.COUNT;

    /// <summary>
    /// Stores data for all contexts for which this backend has been
    /// initialized.
    /// </summary>
    private static readonly Dictionary<IntPtr, CtxData> Contexts = [];

    private static readonly float[] ColorDivVec = BitConverter.IsLittleEndian
        ? [1u << 8, 1u << 16, 1u << 24, 1ul << 32]
        : [1ul << 32, 1u << 24, 1u << 16, 1u << 8];

    private static readonly uint[] ColorAndVec = BitConverter.IsLittleEndian
        ? [255u, 255u << 8, 255u << 16, 255u << 24]
        : [255u << 24, 255u << 16, 255u << 8, 255u];

    /// <summary>
    /// Stores data associated to a single ImGui context.
    /// </summary>
    private class CtxData
    {
        public IntPtr Context;
        public readonly SDL_Cursor*[] Cursors = new SDL_Cursor*[CursorCount];
        public float StickDeadZone = DefaultDeadZone;
        public float StickActiveZone => 1 - StickDeadZone;
        public SDL_Texture* Texture;
        public ulong LastTime;
        public SDL_Renderer* Renderer;
        public ImGuiPlatformSetImeDataCallback? PlatformSetImeDataCallback;
        public ImGuiGetClipboardCallback? GetClipboardCallback;
        public ImGuiSetClipboardCallback? SetClipboardCallback;
        public SDL_Window* Window;
        public SDL_Window* ImeWindow;
        public bool BegunFrame;
    }

    /// <summary>
    /// This hack is used to swap horizontal scrolling on OSX, which seems to
    /// behave opposite what is expected.
    /// </summary>
    private static float HorizontalScrollFactor = RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? -1f : 1f;

    /// <summary>
    /// Initialize this backend for the current ImGui context. If the context
    /// has already been initialized with the specified window and renderer,
    /// this call does nothing.
    /// </summary>
    /// <param name="window">
    /// SDL window to associate with the context.
    /// </param>
    /// <param name="renderer">
    /// SDL renderer to associate with the context.
    /// </param>
    /// <exception cref="ImGuiSdl3Exception">
    /// Thrown when
    /// - There is no current context
    /// - The current context has been initialized with a different window or
    ///   renderer.
    /// - 
    /// </exception>
    public static void Init(SDL_Window* window, SDL_Renderer* renderer)
    {
        RequireContext(out var ctx);

        //
        // Check to see if this context has been initialized with the same
        // properties. If so, nothing needs to be done.
        //

        if (Contexts.TryGetValue(ctx, out var ctxData) &&
            (ctxData.Window != window || ctxData.Renderer != renderer))
            ImGuiSdl3Exception.ThrowAlreadyInitialized(ctx);

        if (ctxData != null)
            return;

        //
        // Set up backend IO flags. These tell ImGui what is supported by this
        // backend.
        //

        var io = ImGui.GetIO();

        io.BackendFlags = ImGuiBackendFlags.RendererHasVtxOffset |
                          ImGuiBackendFlags.HasMouseCursors |
                          ImGuiBackendFlags.HasSetMousePos;

        if (SDL_WasInit(SDL_InitFlags.SDL_INIT_GAMEPAD) == SDL_InitFlags.SDL_INIT_GAMEPAD)
            io.BackendFlags |= ImGuiBackendFlags.HasGamepad;

        var vp = ImGui.GetMainViewport();
        vp.PlatformHandle = (IntPtr)window;

        //
        // Configure the context for rendering using this backend.
        //

        ctxData = Contexts[ctx] = new CtxData
        {
            Renderer = renderer,
            Window = window,
            LastTime = SDL_GetTicksNS(),
            Context = ctx,
            PlatformSetImeDataCallback = PlatformSetImeData,
            GetClipboardCallback = GetClipboard,
            SetClipboardCallback = SetClipboard
        };

        //
        // Configure callbacks. These references must be kept so that the
        // GC does not free them.
        //

        ImGui.GetPlatformIO().Platform_SetImeDataFn = Marshal.GetFunctionPointerForDelegate(ctxData.PlatformSetImeDataCallback!);

        ImGui.GetPlatformIO().Platform_GetClipboardTextFn = Marshal.GetFunctionPointerForDelegate(ctxData.GetClipboardCallback!);

        ImGui.GetPlatformIO().Platform_SetClipboardTextFn = Marshal.GetFunctionPointerForDelegate(ctxData.SetClipboardCallback!);

        //
        // Create the atlas texture that will be used and assign it to the
        // context. This texture ID is what will be populated in the draw list
        // later for any polygons that aren't a solid color.
        //

        io.Fonts.GetTexDataAsRGBA32(
            out IntPtr pixels,
            out var width,
            out var height);

        var surface = SDL_CreateSurfaceFrom(
            width, height,
            SDL_PIXELFORMAT_RGBA32,
            pixels,
            width * 4);

        if (surface == null)
            ImGuiSdl3Exception.ThrowSurfaceFailed(ctx);

        var texture = SDL_CreateTextureFromSurface(
            renderer,
            surface);

        if (texture == null)
            ImGuiSdl3Exception.ThrowTextureFailed(ctx, (IntPtr)surface);

        SDL_DestroySurface(surface);

        var texId = (IntPtr)texture;

        if (!SDL_SetTextureBlendMode(
                texture,
                SDL_BlendMode.SDL_BLENDMODE_BLEND))
            ImGuiSdl3Exception.ThrowBlendModeFailed(ctx, texId);

        if (!SDL_SetTextureScaleMode(
                texture,
                SDL_ScaleMode.SDL_SCALEMODE_LINEAR))
            ImGuiSdl3Exception.ThrowScaleModeFailed(ctx, texId);

        io.Fonts.SetTexID(texId);
    }

    /// <summary>
    /// Free resources used by this backend for the current ImGui context.
    /// </summary>
    public static void Shutdown()
    {
        RequireContext(out var ctx);

        //
        // If this context hasn't been initialized, nothing to do.
        //

        if (!Contexts.TryGetValue(ctx, out var ctxData))
            return;

        //
        // Clean up the atlas texture.
        //

        if (ctxData.Texture != null)
        {
            SDL_DestroyTexture(ctxData.Texture);
            ctxData.Texture = null;
        }

        //
        // Clean up cursors.
        //

        for (var i = 0; i < ctxData.Cursors.Length; i++)
        {
            if (ctxData.Cursors[i] == null)
                continue;

            SDL_DestroyCursor(ctxData.Cursors[i]);
            ctxData.Cursors[i] = null;
        }

        //
        // Clean up function pointers.
        //

        ctxData.PlatformSetImeDataCallback = null;

        //
        // Clean up context data.
        //

        Contexts.Remove(ctx);
    }

    /// <summary>
    /// Set up the current ImGui context for a new frame.
    /// </summary>
    public static void NewFrame()
    {
        RequireContextData(out var ctxData);

        //
        // If NewFrame was already called, do nothing.
        //

        if (ctxData.BegunFrame)
            return;

        //
        // Determine the amount of time that has elapsed since the last frame.
        //

        var io = ImGui.GetIO();
        var now = SDL_GetTicksNS();
        var elapsed = now - ctxData.LastTime;


        io.DeltaTime = elapsed / (float)SDL_NS_PER_SECOND;

        //
        // Determine the render size and scale for this frame.
        //

        int width, height;
        if (!SDL_GetRenderOutputSize(ctxData.Renderer, &width, &height))
            (width, height) = (0, 0);

        float scaleX, scaleY;
        if (!SDL_GetRenderScale(ctxData.Renderer, &scaleX, &scaleY))
            (scaleX, scaleY) = (1, 1);

        io.DisplaySize.X = width;
        io.DisplaySize.Y = height;
        io.DisplayFramebufferScale.X = scaleX;
        io.DisplayFramebufferScale.Y = scaleY;

        //
        // Update input for this frame.
        //

        if (io.WantSetMousePos)
            SDL_WarpMouseInWindow(ctxData.Window, io.MousePos.X, io.MousePos.Y);

        if ((io.ConfigFlags & ImGuiConfigFlags.NoMouseCursorChange) == 0)
            SetMouseCursor(ctxData, ImGui.GetMouseCursor());

        //
        // Mark the current frame in progress.
        //

        ctxData.BegunFrame = true;
        ctxData.LastTime = now;
    }

    /// <summary>
    /// Render an ImGui draw data structure to SDL.
    /// </summary>
    /// <param name="drawData">
    /// ImGui draw data for the frame to be rendered.
    /// </param>
    public static void RenderDrawData(ImDrawDataPtr drawData)
    {
        RequireContextData(out var ctxData);

        //
        // If RenderDrawData was already called, do nothing.
        //

        if (!ctxData.BegunFrame)
            return;

        //
        // Indicate the end of this frame.
        //

        ctxData.BegunFrame = false;

        //
        // Preserve viewport and render clip settings on the SDL render
        // surface.
        //

        var hasViewport = SDL_RenderViewportSet(ctxData.Renderer);
        var hasClipRect = SDL_RenderClipEnabled(ctxData.Renderer);
        var oldViewport = default(SDL_Rect);
        var oldClipRect = default(SDL_Rect);

        if (hasViewport)
        {
            if (!SDL_GetRenderViewport(ctxData.Renderer, &oldViewport))
                Debug.WriteLine("Failed to retrieve render viewport: {0}",
                    [SDL_GetError()]);
        }

        if (hasClipRect)
        {
            if (!SDL_GetRenderClipRect(ctxData.Renderer, &oldClipRect))
                Debug.WriteLine("Failed to retrieve render clip rectangle: {0}",
                    [SDL_GetError()]);
        }

        //
        // Render the draw list.
        //

        Render(ctxData, drawData);

        //
        // Restore preserved render state.
        //

        if (hasViewport)
        {
            if (!SDL_SetRenderViewport(ctxData.Renderer, &oldViewport))
                Debug.WriteLine("Failed to set render viewport after render: {0}",
                    [SDL_GetError()]);
        }
        else
        {
            if (!SDL_SetRenderViewport(ctxData.Renderer, null))
                Debug.WriteLine("Failed to set render viewport after render: {0}",
                    [SDL_GetError()]);
        }

        if (hasClipRect)
        {
            if (!SDL_SetRenderClipRect(ctxData.Renderer, &oldClipRect))
                Debug.WriteLine("Failed to set clip rectangle after render: {0}",
                    [SDL_GetError()]);
        }
        else
        {
            if (!SDL_SetRenderClipRect(ctxData.Renderer, null))
                Debug.WriteLine("Failed to set clip rectangle after render: {0}",
                    [SDL_GetError()]);
        }
    }

    /// <summary>
    /// Send SDL events to ImGui.
    /// </summary>
    /// <param name="ev">
    /// Event to process.
    /// </param>
    public static void ProcessEvent(SDL_Event* ev)
    {
        RequireContextData(out var ctxData);

        //
        // Process the event.
        //

        var io = ImGui.GetIO();

        switch (ev->Type)
        {
            //
            // Skip event IDs out of supported range.
            //

            case < SDL_EventType.SDL_EVENT_FIRST or
                > SDL_EventType.SDL_EVENT_LAST:
            {
                break;
            }

            //
            // Handle when a gamepad button is pressed down.
            //

            case SDL_EventType.SDL_EVENT_GAMEPAD_BUTTON_UP:
            {
                if (ConvertGamepadButtonEvent(ev->gbutton) is not { } key ||
                    key == ImGuiKey.None)
                    break;

                io.AddKeyEvent(key, false);
                break;
            }

            //
            // Handle when a gamepad button is released.
            //

            case SDL_EventType.SDL_EVENT_GAMEPAD_BUTTON_DOWN:
            {
                if (ConvertGamepadButtonEvent(ev->gbutton) is not { } key ||
                    key == ImGuiKey.None)
                    break;

                io.AddKeyEvent(key, true);
                break;
            }

            //
            // Handle when a gamepad axis position (such as a stick) has changed.
            //

            case SDL_EventType.SDL_EVENT_GAMEPAD_AXIS_MOTION:
            {
                var (key1, value1, key2, value2) =
                    ConvertGamepadAxisEvent(ctxData, ev->gaxis);
                if (key1 != null)
                    io.AddKeyAnalogEvent(key1.Value, value1 != 0, value1);
                if (key2 != null)
                    io.AddKeyAnalogEvent(key2.Value, value2 != 0, value2);
                break;
            }

            //
            // Handle when a mouse button has been released.
            //

            case SDL_EventType.SDL_EVENT_MOUSE_BUTTON_UP:
            {
                if (ConvertMouseButtonEvent(ev->button) is not { } button)
                    break;

                io.AddMouseButtonEvent((int)button, false);
                break;
            }

            //
            // Handle when a mouse button has been pressed.
            //

            case SDL_EventType.SDL_EVENT_MOUSE_BUTTON_DOWN:
            {
                if (ConvertMouseButtonEvent(ev->button) is not { } button)
                    break;

                io.AddMouseButtonEvent((int)button, true);
                break;
            }

            //
            // Handle when a mouse has changed position.
            //

            case SDL_EventType.SDL_EVENT_MOUSE_MOTION:
            {
                var evCopy = *ev;
                if (!SDL_ConvertEventToRenderCoordinates(ctxData.Renderer, &evCopy))
                    Debug.WriteLine("Failed to convert event coordinates for mouse movement: {0}",
                        [SDL_GetError()]);

                io.AddMouseSourceEvent(ev->motion.which == SDL_TOUCH_MOUSEID
                    ? ImGuiMouseSource.TouchScreen
                    : ImGuiMouseSource.Mouse);

                io.AddMousePosEvent(evCopy.motion.x, evCopy.motion.y);
                break;
            }

            //
            // Handle when a mouse wheel has changed position.
            //

            case SDL_EventType.SDL_EVENT_MOUSE_WHEEL:
            {
                io.AddMouseSourceEvent(ev->wheel.which == SDL_TOUCH_MOUSEID
                    ? ImGuiMouseSource.TouchScreen
                    : ImGuiMouseSource.Mouse);

                io.AddMouseWheelEvent(ev->wheel.x * HorizontalScrollFactor, ev->wheel.y);
                break;
            }

            //
            // Handle when a keyboard key has been released.
            //

            case SDL_EventType.SDL_EVENT_KEY_UP:
            {
                if (ConvertKeyboardEventKey(ev->key) is not { } nav ||
                    nav == ImGuiKey.None)
                    break;

                UpdateKeyboardModifiers(ev->key.mod);
                io.SetKeyEventNativeData(nav, (int)ev->key.key, (int)ev->key.scancode);
                io.AddKeyEvent(nav, false);
                break;
            }

            //
            // Handle when a keyboard key has been pressed down.
            //

            case SDL_EventType.SDL_EVENT_KEY_DOWN:
            {
                if (ConvertKeyboardEventKey(ev->key) is not { } nav ||
                    nav == ImGuiKey.None)
                    break;

                UpdateKeyboardModifiers(ev->key.mod);
                io.SetKeyEventNativeData(nav, (int)ev->key.key, (int)ev->key.scancode);
                io.AddKeyEvent(nav, true);
                break;
            }

            //
            // Handle when text has been typed.
            //

            case SDL_EventType.SDL_EVENT_TEXT_INPUT:
            {
                if (ev->text.GetText() is not { } text ||
                    string.IsNullOrEmpty(text))
                    break;

                io.AddInputCharactersUTF8(text);
                break;
            }
        }
    }

    /// <summary>
    /// Require the current ImGui context to be set.
    /// </summary>
    private static void RequireContext(out IntPtr ctx)
    {
        ctx = ImGui.GetCurrentContext();
        if (ctx == IntPtr.Zero)
            ImGuiSdl3Exception.ThrowNoContext();
    }

    /// <summary>
    /// Require that the backend be initialized with the specified ImGui context.
    /// </summary>
    private static void RequireContextData(IntPtr ctx, out CtxData ctxData)
    {
        if (!Contexts.TryGetValue(ctx, out ctxData!))
            ImGuiSdl3Exception.ThrowContextNotInitialized(ctx);
    }

    /// <summary>
    /// Require that the backend be initialized with the current ImGui context.
    /// </summary>
    private static void RequireContextData(out CtxData ctxData)
    {
        RequireContext(out var ctx);
        RequireContextData(ctx, out ctxData);
    }

    /// <summary>
    /// Handles when ImGui wishes to set clipboard data.
    /// </summary>
    private static void SetClipboard(IntPtr ctx, string? data)
    {
        if (!SDL_SetClipboardText(data))
            Debug.WriteLine("Failed to set clipboard: {0}",
                [SDL_GetError()]);
    }

    /// <summary>
    /// Handles when ImGui wishes to get clipboard data.
    /// </summary>
    private static string? GetClipboard(IntPtr ctx)
    {
        return SDL_GetClipboardText();
    }

    /// <summary>
    /// Handles when IME data is available for an ImGui context. This is called
    /// directly by ImGui to obtain information about an input mechanism such
    /// as a virtual keyboard, or to interact with such input mechanism.
    /// </summary>
    /// <param name="ctx">
    /// ImGui context associated with the call.
    /// </param>
    /// <param name="viewport">
    /// Viewport within which the data is requested.
    /// </param>
    /// <param name="data">
    /// Event data.
    /// </param>
    private static void PlatformSetImeData(
        IntPtr ctx,
        ImGuiViewport* viewport,
        ImGuiPlatformImeData* data)
    {
        RequireContextData(ctx, out var ctxData);

        //
        // If the current IME window should close, or the focused window has
        // changed, indicate to SDL to stop accepting input.
        //

        var window = (SDL_Window*)viewport->PlatformHandle;
        if ((data->WantVisible == 0 || ctxData.ImeWindow != window) &&
            ctxData.ImeWindow != null)
        {
            if (!SDL_StopTextInput(ctxData.ImeWindow))
                ImGuiSdl3Exception.ThrowStopTextInputFailed(ctx);
            ctxData.ImeWindow = null;
        }

        if (data->WantVisible == 0)
            return;

        //
        // If the IME window should be active, indicate to SDL to accept text
        // input.
        //

        var r = new SDL_Rect
        {
            x = (int)data->InputPos.X,
            y = (int)data->InputPos.Y,
            w = 1,
            h = (int)data->InputLineHeight
        };

        if (!SDL_SetTextInputArea(window, &r, 0))
            ImGuiSdl3Exception.ThrowSetTextInputAreaFailed(ctx);

        if (!SDL_StartTextInput(window))
            ImGuiSdl3Exception.ThrowStartTextInputFailed(ctx);

        ctxData.ImeWindow = window;
    }

    /// <summary>
    /// Normalize raw gamepad axis input.
    /// </summary>
    /// <param name="raw">
    /// Raw gamepad axis value from SDL, range -32768 to 32767.
    /// </param>
    /// <returns>
    /// Normalized gamepad axis value, range -1.0 to 1.0.
    /// </returns>
    private static float ConvertGamepadAxisValue(short raw) =>
        MathF.Min(MathF.Max(raw / 32767f, -1.0f), 1.0f);

    /// <summary>
    /// Normalize and apply dead zone scaling to raw gamepad axis input.
    /// </summary>
    /// <param name="ctxData">
    /// Data for the current ImGui context.
    /// </param>
    /// <param name="raw">
    /// Raw gamepad axis value from SDL, range -32768 to 32767.
    /// </param>
    /// <returns>
    /// Normalized gamepad axis value, range -1.0 to 1.0.
    /// </returns>
    /// <remarks>
    /// With the center at 0.0, the dead zone will ignore inputs x > 0 > -x.
    /// </remarks>
    private static float ScaleGamepadAxisValue(CtxData ctxData, short raw) =>
        ConvertGamepadAxisValue(raw) switch
        {
            var val when val <= -ctxData.StickDeadZone =>
                (val + ctxData.StickDeadZone) / ctxData.StickActiveZone,
            var val when val >= ctxData.StickDeadZone =>
                (val - ctxData.StickDeadZone) / ctxData.StickActiveZone,
            _ => 0
        };

    /// <summary>
    /// Convert a raw SDL gamepad value to bi-polar analog key data for ImGui.
    /// </summary>
    /// <param name="ctxData">
    /// ImGui context data.
    /// </param>
    /// <param name="ev">
    /// SDL event data.
    /// </param>
    /// <param name="negative">
    /// ImGui key associated with negative values on the axis.
    /// </param>
    /// <param name="positive">
    /// ImGui key associated with positive values on the axis.
    /// </param>
    /// <returns>
    /// Bi-polar analog key data.
    /// </returns>
    private static GamepadEventValue ConvertGamepadAxisValue(
        CtxData ctxData,
        SDL_GamepadAxisEvent ev,
        ImGuiKey negative,
        ImGuiKey positive) =>
        ScaleGamepadAxisValue(ctxData, ev.value) switch
        {
            var x and < 0 => (negative, -x, positive, 0),
            var x and > 0 => (positive, x, negative, 0),
            _ => (positive, 0, negative, 0)
        };

    /// <summary>
    /// Map SDL gamepad axis event data to ImGui key(s). In most cases,
    /// moving one axis should update both opposing ImGui keys associated to it.
    /// </summary>
    /// <param name="ctxData">
    /// ImGui context data.
    /// </param>
    /// <param name="ev">
    /// SDL event data.
    /// </param>
    /// <returns>
    /// Mapped gamepad event. One or both keys may be null if mappings do not
    /// exist for them.
    /// </returns>
    private static GamepadEventValue ConvertGamepadAxisEvent(
        CtxData ctxData,
        SDL_GamepadAxisEvent ev) =>
        ev.Axis switch
        {
            < SDL_GamepadAxis.SDL_GAMEPAD_AXIS_LEFTX or
                >= SDL_GamepadAxis.SDL_GAMEPAD_AXIS_COUNT =>
                default,

            SDL_GamepadAxis.SDL_GAMEPAD_AXIS_LEFTX =>
                ConvertGamepadAxisValue(ctxData, ev,
                    ImGuiKey.GamepadLStickLeft, ImGuiKey.GamepadLStickRight),

            SDL_GamepadAxis.SDL_GAMEPAD_AXIS_LEFTY =>
                ConvertGamepadAxisValue(ctxData, ev,
                    ImGuiKey.GamepadLStickUp, ImGuiKey.GamepadLStickDown),

            SDL_GamepadAxis.SDL_GAMEPAD_AXIS_RIGHTX =>
                ConvertGamepadAxisValue(ctxData, ev,
                    ImGuiKey.GamepadRStickLeft, ImGuiKey.GamepadRStickRight),

            SDL_GamepadAxis.SDL_GAMEPAD_AXIS_RIGHTY =>
                ConvertGamepadAxisValue(ctxData, ev,
                    ImGuiKey.GamepadRStickUp, ImGuiKey.GamepadRStickDown),

            SDL_GamepadAxis.SDL_GAMEPAD_AXIS_LEFT_TRIGGER =>
                ConvertGamepadAxisValue(ctxData, ev,
                    ImGuiKey.GamepadL2, ImGuiKey.GamepadL2),

            SDL_GamepadAxis.SDL_GAMEPAD_AXIS_RIGHT_TRIGGER =>
                ConvertGamepadAxisValue(ctxData, ev,
                    ImGuiKey.GamepadR2, ImGuiKey.GamepadR2)
        };

    /// <summary>
    /// Map SDL gamepad button event data to ImGui key.
    /// </summary>
    /// <param name="ev">
    /// SDL event data.
    /// </param>
    /// <returns>
    /// ImGui key. Will return null if no mapping exists.
    /// </returns>
    private static ImGuiKey? ConvertGamepadButtonEvent(
        SDL_GamepadButtonEvent ev) =>
        ev.Button switch
        {
            < SDL_GamepadButton.SDL_GAMEPAD_BUTTON_SOUTH or
                >= SDL_GamepadButton.SDL_GAMEPAD_BUTTON_COUNT => null,

            SDL_GamepadButton.SDL_GAMEPAD_BUTTON_SOUTH =>
                ImGuiKey.GamepadFaceDown,

            SDL_GamepadButton.SDL_GAMEPAD_BUTTON_EAST =>
                ImGuiKey.GamepadFaceRight,

            SDL_GamepadButton.SDL_GAMEPAD_BUTTON_WEST =>
                ImGuiKey.GamepadFaceLeft,

            SDL_GamepadButton.SDL_GAMEPAD_BUTTON_NORTH =>
                ImGuiKey.GamepadFaceUp,

            SDL_GamepadButton.SDL_GAMEPAD_BUTTON_LEFT_SHOULDER =>
                ImGuiKey.GamepadL1,

            SDL_GamepadButton.SDL_GAMEPAD_BUTTON_RIGHT_SHOULDER =>
                ImGuiKey.GamepadR1,

            SDL_GamepadButton.SDL_GAMEPAD_BUTTON_LEFT_STICK =>
                ImGuiKey.GamepadL3,

            SDL_GamepadButton.SDL_GAMEPAD_BUTTON_RIGHT_STICK =>
                ImGuiKey.GamepadR3,

            SDL_GamepadButton.SDL_GAMEPAD_BUTTON_DPAD_UP =>
                ImGuiKey.GamepadDpadUp,

            SDL_GamepadButton.SDL_GAMEPAD_BUTTON_DPAD_DOWN =>
                ImGuiKey.GamepadDpadDown,

            SDL_GamepadButton.SDL_GAMEPAD_BUTTON_DPAD_LEFT =>
                ImGuiKey.GamepadDpadLeft,

            SDL_GamepadButton.SDL_GAMEPAD_BUTTON_DPAD_RIGHT =>
                ImGuiKey.GamepadDpadRight,

            SDL_GamepadButton.SDL_GAMEPAD_BUTTON_START =>
                ImGuiKey.GamepadStart,

            SDL_GamepadButton.SDL_GAMEPAD_BUTTON_BACK =>
                ImGuiKey.GamepadBack,

            _ => null
        };

    /// <summary>
    /// Map SDL mouse button event data to an ImGui mouse button.
    /// </summary>
    /// <param name="ev">
    /// SDL event data.
    /// </param>
    /// <returns>
    /// ImGui mouse button index. Will return null if no mapping exists.
    /// </returns>
    private static ImGuiMouseButton? ConvertMouseButtonEvent(
        SDL_MouseButtonEvent ev) =>
        ev.Button switch
        {
            SDLButton.SDL_BUTTON_LEFT =>
                ImGuiMouseButton.Left,

            SDLButton.SDL_BUTTON_MIDDLE =>
                ImGuiMouseButton.Middle,

            SDLButton.SDL_BUTTON_RIGHT =>
                ImGuiMouseButton.Right,
            _ => null
        };

    /// <summary>
    /// Notify ImGui of the current state of keyboard modifier keys.
    /// </summary>
    /// <param name="mod">
    /// SDL key modifiers.
    /// </param>
    private static void UpdateKeyboardModifiers(SDL_Keymod mod)
    {
        var io = ImGui.GetIO();

        io.AddKeyEvent(ImGuiKey.ModCtrl,
            (mod & SDL_Keymod.SDL_KMOD_CTRL) != 0);

        io.AddKeyEvent(ImGuiKey.ModAlt,
            (mod & SDL_Keymod.SDL_KMOD_ALT) != 0);

        io.AddKeyEvent(ImGuiKey.ModShift,
            (mod & SDL_Keymod.SDL_KMOD_SHIFT) != 0);

        io.AddKeyEvent(ImGuiKey.ModSuper,
            (mod & SDL_Keymod.SDL_KMOD_GUI) != 0);
    }

    /// <summary>
    /// Map an SDL keyboard scan code to ImGui key.
    /// </summary>
    /// <param name="ev">
    /// SDL event data.
    /// </param>
    /// <returns>
    /// ImGui key. Will return null if no mapping exists.
    /// </returns>
    private static ImGuiKey? ConvertKeyboardEventKey(SDL_KeyboardEvent ev)
    {
        var code = ev.scancode switch
        {
            < SDL_Scancode.SDL_SCANCODE_A or
                >= SDL_Scancode.SDL_SCANCODE_COUNT => ImGuiKey.None,
            SDL_Scancode.SDL_SCANCODE_A => ImGuiKey.A,
            SDL_Scancode.SDL_SCANCODE_B => ImGuiKey.B,
            SDL_Scancode.SDL_SCANCODE_C => ImGuiKey.C,
            SDL_Scancode.SDL_SCANCODE_D => ImGuiKey.D,
            SDL_Scancode.SDL_SCANCODE_E => ImGuiKey.E,
            SDL_Scancode.SDL_SCANCODE_F => ImGuiKey.F,
            SDL_Scancode.SDL_SCANCODE_G => ImGuiKey.G,
            SDL_Scancode.SDL_SCANCODE_H => ImGuiKey.H,
            SDL_Scancode.SDL_SCANCODE_I => ImGuiKey.I,
            SDL_Scancode.SDL_SCANCODE_J => ImGuiKey.J,
            SDL_Scancode.SDL_SCANCODE_K => ImGuiKey.K,
            SDL_Scancode.SDL_SCANCODE_L => ImGuiKey.L,
            SDL_Scancode.SDL_SCANCODE_M => ImGuiKey.M,
            SDL_Scancode.SDL_SCANCODE_N => ImGuiKey.N,
            SDL_Scancode.SDL_SCANCODE_O => ImGuiKey.O,
            SDL_Scancode.SDL_SCANCODE_P => ImGuiKey.P,
            SDL_Scancode.SDL_SCANCODE_Q => ImGuiKey.Q,
            SDL_Scancode.SDL_SCANCODE_R => ImGuiKey.R,
            SDL_Scancode.SDL_SCANCODE_S => ImGuiKey.S,
            SDL_Scancode.SDL_SCANCODE_T => ImGuiKey.T,
            SDL_Scancode.SDL_SCANCODE_U => ImGuiKey.U,
            SDL_Scancode.SDL_SCANCODE_V => ImGuiKey.V,
            SDL_Scancode.SDL_SCANCODE_W => ImGuiKey.W,
            SDL_Scancode.SDL_SCANCODE_X => ImGuiKey.X,
            SDL_Scancode.SDL_SCANCODE_Y => ImGuiKey.Y,
            SDL_Scancode.SDL_SCANCODE_Z => ImGuiKey.Z,
            SDL_Scancode.SDL_SCANCODE_1 => ImGuiKey._1,
            SDL_Scancode.SDL_SCANCODE_2 => ImGuiKey._2,
            SDL_Scancode.SDL_SCANCODE_3 => ImGuiKey._3,
            SDL_Scancode.SDL_SCANCODE_4 => ImGuiKey._4,
            SDL_Scancode.SDL_SCANCODE_5 => ImGuiKey._5,
            SDL_Scancode.SDL_SCANCODE_6 => ImGuiKey._6,
            SDL_Scancode.SDL_SCANCODE_7 => ImGuiKey._7,
            SDL_Scancode.SDL_SCANCODE_8 => ImGuiKey._8,
            SDL_Scancode.SDL_SCANCODE_9 => ImGuiKey._9,
            SDL_Scancode.SDL_SCANCODE_0 => ImGuiKey._0,
            SDL_Scancode.SDL_SCANCODE_RETURN => ImGuiKey.Enter,
            SDL_Scancode.SDL_SCANCODE_ESCAPE => ImGuiKey.Escape,
            SDL_Scancode.SDL_SCANCODE_BACKSPACE => ImGuiKey.Backspace,
            SDL_Scancode.SDL_SCANCODE_TAB => ImGuiKey.Tab,
            SDL_Scancode.SDL_SCANCODE_SPACE => ImGuiKey.Space,
            SDL_Scancode.SDL_SCANCODE_MINUS => ImGuiKey.Minus,
            SDL_Scancode.SDL_SCANCODE_EQUALS => ImGuiKey.Equal,
            SDL_Scancode.SDL_SCANCODE_LEFTBRACKET => ImGuiKey.LeftBracket,
            SDL_Scancode.SDL_SCANCODE_RIGHTBRACKET => ImGuiKey.RightBracket,
            SDL_Scancode.SDL_SCANCODE_BACKSLASH => ImGuiKey.Backslash,
            SDL_Scancode.SDL_SCANCODE_NONUSHASH => ImGuiKey.Backslash,
            SDL_Scancode.SDL_SCANCODE_SEMICOLON => ImGuiKey.Semicolon,
            SDL_Scancode.SDL_SCANCODE_APOSTROPHE => ImGuiKey.Apostrophe,
            SDL_Scancode.SDL_SCANCODE_GRAVE => ImGuiKey.GraveAccent,
            SDL_Scancode.SDL_SCANCODE_COMMA => ImGuiKey.Comma,
            SDL_Scancode.SDL_SCANCODE_PERIOD => ImGuiKey.Period,
            SDL_Scancode.SDL_SCANCODE_SLASH => ImGuiKey.Slash,
            SDL_Scancode.SDL_SCANCODE_CAPSLOCK => ImGuiKey.CapsLock,
            SDL_Scancode.SDL_SCANCODE_F1 => ImGuiKey.F1,
            SDL_Scancode.SDL_SCANCODE_F2 => ImGuiKey.F2,
            SDL_Scancode.SDL_SCANCODE_F3 => ImGuiKey.F3,
            SDL_Scancode.SDL_SCANCODE_F4 => ImGuiKey.F4,
            SDL_Scancode.SDL_SCANCODE_F5 => ImGuiKey.F5,
            SDL_Scancode.SDL_SCANCODE_F6 => ImGuiKey.F6,
            SDL_Scancode.SDL_SCANCODE_F7 => ImGuiKey.F7,
            SDL_Scancode.SDL_SCANCODE_F8 => ImGuiKey.F8,
            SDL_Scancode.SDL_SCANCODE_F9 => ImGuiKey.F9,
            SDL_Scancode.SDL_SCANCODE_F10 => ImGuiKey.F10,
            SDL_Scancode.SDL_SCANCODE_F11 => ImGuiKey.F11,
            SDL_Scancode.SDL_SCANCODE_F12 => ImGuiKey.F12,
            SDL_Scancode.SDL_SCANCODE_PRINTSCREEN => ImGuiKey.PrintScreen,
            SDL_Scancode.SDL_SCANCODE_SCROLLLOCK => ImGuiKey.ScrollLock,
            SDL_Scancode.SDL_SCANCODE_PAUSE => ImGuiKey.Pause,
            SDL_Scancode.SDL_SCANCODE_INSERT => ImGuiKey.Insert,
            SDL_Scancode.SDL_SCANCODE_HOME => ImGuiKey.Home,
            SDL_Scancode.SDL_SCANCODE_PAGEUP => ImGuiKey.PageUp,
            SDL_Scancode.SDL_SCANCODE_DELETE => ImGuiKey.Delete,
            SDL_Scancode.SDL_SCANCODE_END => ImGuiKey.End,
            SDL_Scancode.SDL_SCANCODE_PAGEDOWN => ImGuiKey.PageDown,
            SDL_Scancode.SDL_SCANCODE_RIGHT => ImGuiKey.RightArrow,
            SDL_Scancode.SDL_SCANCODE_LEFT => ImGuiKey.LeftArrow,
            SDL_Scancode.SDL_SCANCODE_DOWN => ImGuiKey.DownArrow,
            SDL_Scancode.SDL_SCANCODE_UP => ImGuiKey.UpArrow,
            SDL_Scancode.SDL_SCANCODE_NUMLOCKCLEAR => ImGuiKey.NumLock,
            SDL_Scancode.SDL_SCANCODE_KP_DIVIDE => ImGuiKey.KeypadDivide,
            SDL_Scancode.SDL_SCANCODE_KP_MULTIPLY => ImGuiKey.KeypadMultiply,
            SDL_Scancode.SDL_SCANCODE_KP_MINUS => ImGuiKey.KeypadSubtract,
            SDL_Scancode.SDL_SCANCODE_KP_PLUS => ImGuiKey.KeypadAdd,
            SDL_Scancode.SDL_SCANCODE_KP_ENTER => ImGuiKey.KeypadEnter,
            SDL_Scancode.SDL_SCANCODE_KP_1 => ImGuiKey.Keypad1,
            SDL_Scancode.SDL_SCANCODE_KP_2 => ImGuiKey.Keypad2,
            SDL_Scancode.SDL_SCANCODE_KP_3 => ImGuiKey.Keypad3,
            SDL_Scancode.SDL_SCANCODE_KP_4 => ImGuiKey.Keypad4,
            SDL_Scancode.SDL_SCANCODE_KP_5 => ImGuiKey.Keypad5,
            SDL_Scancode.SDL_SCANCODE_KP_6 => ImGuiKey.Keypad6,
            SDL_Scancode.SDL_SCANCODE_KP_7 => ImGuiKey.Keypad7,
            SDL_Scancode.SDL_SCANCODE_KP_8 => ImGuiKey.Keypad8,
            SDL_Scancode.SDL_SCANCODE_KP_9 => ImGuiKey.Keypad9,
            SDL_Scancode.SDL_SCANCODE_KP_0 => ImGuiKey.Keypad0,
            SDL_Scancode.SDL_SCANCODE_KP_PERIOD => ImGuiKey.KeypadDecimal,
            SDL_Scancode.SDL_SCANCODE_NONUSBACKSLASH => ImGuiKey.GraveAccent,
            SDL_Scancode.SDL_SCANCODE_KP_EQUALS => ImGuiKey.KeypadEqual,
            SDL_Scancode.SDL_SCANCODE_LCTRL => ImGuiKey.LeftCtrl,
            SDL_Scancode.SDL_SCANCODE_LSHIFT => ImGuiKey.LeftShift,
            SDL_Scancode.SDL_SCANCODE_LALT => ImGuiKey.LeftAlt,
            SDL_Scancode.SDL_SCANCODE_LGUI => ImGuiKey.LeftSuper,
            SDL_Scancode.SDL_SCANCODE_RCTRL => ImGuiKey.RightCtrl,
            SDL_Scancode.SDL_SCANCODE_RSHIFT => ImGuiKey.RightShift,
            SDL_Scancode.SDL_SCANCODE_RALT => ImGuiKey.RightAlt,
            SDL_Scancode.SDL_SCANCODE_RGUI => ImGuiKey.RightSuper,
            _ => ImGuiKey.None
        };

        if (code == ImGuiKey.None)
            return null;

        return code;
    }

    /// <summary>
    /// Map an ImGui mouse cursor ID to an SDL mouse cursor ID.
    /// </summary>
    /// <param name="cursor">
    /// ImGui mouse cursor ID.
    /// </param>
    /// <returns>
    /// SDL mouse cursor ID.
    /// </returns>
    private static SDL_SystemCursor? GetCursorId(ImGuiMouseCursor cursor) =>
        cursor switch
        {
            ImGuiMouseCursor.Arrow =>
                SDL_SystemCursor.SDL_SYSTEM_CURSOR_DEFAULT,

            ImGuiMouseCursor.TextInput =>
                SDL_SystemCursor.SDL_SYSTEM_CURSOR_TEXT,

            ImGuiMouseCursor.ResizeAll =>
                SDL_SystemCursor.SDL_SYSTEM_CURSOR_MOVE,

            ImGuiMouseCursor.ResizeNS =>
                SDL_SystemCursor.SDL_SYSTEM_CURSOR_NS_RESIZE,

            ImGuiMouseCursor.ResizeEW =>
                SDL_SystemCursor.SDL_SYSTEM_CURSOR_EW_RESIZE,

            ImGuiMouseCursor.ResizeNESW =>
                SDL_SystemCursor.SDL_SYSTEM_CURSOR_NESW_RESIZE,

            ImGuiMouseCursor.ResizeNWSE =>
                SDL_SystemCursor.SDL_SYSTEM_CURSOR_NWSE_RESIZE,

            ImGuiMouseCursor.Hand =>
                SDL_SystemCursor.SDL_SYSTEM_CURSOR_POINTER,

            ImGuiMouseCursor.NotAllowed =>
                SDL_SystemCursor.SDL_SYSTEM_CURSOR_NOT_ALLOWED,

            _ => null
        };

    /// <summary>
    /// Set the visible mouse cursor.
    /// </summary>
    /// <param name="ctxData">
    /// ImGui context data.
    /// </param>
    /// <param name="cursor">
    /// ImGui mouse cursor ID.
    /// </param>
    private static void SetMouseCursor(
        CtxData ctxData,
        ImGuiMouseCursor cursor)
    {
        //
        // If the cursor should be hidden, do that.
        //

        var index = (int)cursor;

        if (cursor == ImGuiMouseCursor.None)
        {
            if (!SDL_HideCursor())
                Debug.WriteLine("Failed to hide cursor: {0}",
                    [SDL_GetError()]);
            return;
        }

        //
        // If we have not cached the specified cursor, create and cache it.
        //

        if (ctxData.Cursors[index] == null)
        {
            var id = GetCursorId(cursor);
            if (id != null)
            {
                var newCursor = SDL_CreateSystemCursor(id.Value);

                if (newCursor == null)
                    ImGuiSdl3Exception.ThrowCreateSystemCursorFailed(
                        ctxData.Context,
                        cursor,
                        id.Value);

                ctxData.Cursors[index] = newCursor;
            }
        }

        //
        // If there is no mouse cursor for the requested ID, just hide the
        // cursor instead.
        //

        if (ctxData.Cursors[index] == null)
        {
            if (!SDL_HideCursor())
                Debug.WriteLine("Failed to hide cursor: {0}",
                    [SDL_GetError()]);
            return;
        }

        //
        // Switch the currently shown cursor.
        //

        if (!SDL_ShowCursor())
            Debug.WriteLine("Failed to show cursor: {0}",
                [SDL_GetError()]);

        if (!SDL_SetCursor(ctxData.Cursors[index]))
            Debug.WriteLine("Failed to set cursor: {0}",
                [SDL_GetError()]);
    }

    /// <summary>
    /// Interpret draw data into geometry rendering calls to SDL.
    /// </summary>
    /// <param name="ctxData">
    /// ImGui context data.
    /// </param>
    /// <param name="drawData">
    /// ImGui draw data.
    /// </param>
    private static void Render(CtxData ctxData, ImDrawDataPtr drawData)
    {
        //
        // Determine the window dimensions. DisplayPos is a 2D position that
        // ImGui indicates all rendering shall be relative to. We initialize
        // this as a Vector4 here so that it the arithmetic is trivial later.
        //

        var displayPos = drawData.DisplayPos;

        var clipOff = new Vector4(
            displayPos.X,
            displayPos.Y,
            displayPos.X,
            displayPos.Y);

        //
        // Find the maximum number of vertices to allocate data buffers for.
        // Only vertex color conversion is needed; vertices and indices are
        // directly referenced. This works because those tables are allocated
        // in unmanaged memory and are organized by ImGui.
        //

        var maxNumVertices = 0;
        for (var n = 0; n < drawData.CmdListsCount; n++)
        {
            var numVertices = drawData.CmdLists[n].VtxBuffer.Size;
            if (maxNumVertices < numVertices)
                maxNumVertices = numVertices;
        }

        //
        // Element counts can get rather large; previous implementations of
        // this used the stack, but that can lead to overflow with particularly
        // complex UIs. We will use MemoryPool to recycle memory spans.
        //

        using var colors = MemoryPool<Vector4>.Shared.Rent(maxNumVertices);

        //
        // Process command lists.
        //

        for (var n = 0; n < drawData.CmdListsCount; n++)
        {
            var cmdList = drawData.CmdLists[n];
            var vtxBuffer = cmdList.VtxBuffer;
            var idxBuffer = cmdList.IdxBuffer;

            for (var cmdI = 0; cmdI < cmdList.CmdBuffer.Size; cmdI++)
            {
                var pcmd = cmdList.CmdBuffer[cmdI];
                if (pcmd.UserCallback != IntPtr.Zero)
                {
                    //
                    // If a user callback is specified, call it instead of
                    // the standard render pipeline below.
                    //

                    Marshal
                        .GetDelegateForFunctionPointer<ImGuiUserCallback>(pcmd.UserCallback)
                        .Invoke(cmdList.NativePtr, pcmd.NativePtr);
                }
                else
                {
                    //
                    // If a user callback is not specified, proceed to the
                    // standard render pipeline.
                    //

                    var bounds = pcmd.ClipRect - clipOff;

                    if (bounds.Z <= bounds.X || bounds.W <= bounds.Y)
                        continue;

                    //
                    // SDL clip rectangles do not use floats; these values
                    // must be converted here.
                    //

                    var clip = new SDL_Rect
                    {
                        x = (int)bounds.X,
                        y = (int)bounds.Y,
                        w = (int)(bounds.Z - bounds.X),
                        h = (int)(bounds.W - bounds.Y)
                    };

                    //
                    // If the clip rect can't be set, skip rendering.
                    //

                    if (!SDL_SetRenderClipRect(ctxData.Renderer, &clip))
                        continue;

                    //
                    // Retrieve render properties from the command.
                    //

                    var sdlTexture = (SDL_Texture*)pcmd.TextureId;
                    var idxBufferPtr = (ushort*)idxBuffer.Data + pcmd.IdxOffset;
                    var vtxBufferPtr = (ImDrawVert*)vtxBuffer.Data + pcmd.VtxOffset;

                    fixed (Vector4* colorPtr = colors.Memory.Span)
                    {
                        //
                        // Convert vertex color data from RGBA32 to SDL_FColor.
                        //

                        for (var i = 0; i < vtxBuffer.Size; i++)
                        {
                            var col = (byte*)&vtxBufferPtr[i].col;
                            colorPtr[i] = new Vector4(col[0], col[1], col[2], col[3]) / 255f;
                        }

                        //
                        // Perform the render. Vertex and index data is used
                        // directly from the source as it needs no conversion.
                        //

                        if (!SDL_RenderGeometryRaw(
                                ctxData.Renderer,
                                sdlTexture,
                                (float*)&vtxBufferPtr->pos,
                                sizeof(ImDrawVert),
                                (SDL_FColor*)colorPtr,
                                sizeof(SDL_FColor),
                                (float*)&vtxBufferPtr->uv,
                                sizeof(ImDrawVert),
                                (int)(vtxBuffer.Size - pcmd.VtxOffset),
                                (IntPtr)idxBufferPtr,
                                (int)pcmd.ElemCount,
                                sizeof(ushort)))
                            Debug.WriteLine("Failed to render geometry: {0}", [SDL_GetError()]);
                    }
                }
            }
        }
    }
}