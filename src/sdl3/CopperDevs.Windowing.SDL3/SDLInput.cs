using System.Numerics;
using CopperDevs.Logger;
using CopperDevs.Windowing.Data;
using CopperDevs.Windowing.SDL3.Data;

namespace CopperDevs.Windowing.SDL3;

// ReSharper disable once InconsistentNaming
internal class SDLInput : IInput
{
    private const bool InputLogs = false;

    private SDL3Window connectedWindow;

    private readonly SdlKeyMap keyMap = new();
    private readonly SdlMouseMap mouseMap = new();

    private readonly Dictionary<SDLScancode, bool> keyCurrentlyPressed = new();
    private readonly Dictionary<SDLMouseButtonFlags, bool> buttonCurrentlyPressed = new();

    private Dictionary<SDLScancode, bool> previousFrameKeyCurrentlyPressed = new();
    private Dictionary<SDLMouseButtonFlags, bool> previousFrameButtonCurrentlyPressed = new();

    private Vector2 mousePosition;
    private Vector2 previousMousePosition;

    private Vector2 mouseScroll;

    private CursorMode cursorMode = CursorMode.Normal;

    private bool GetKeyPressState(InputKey key, bool previousFrame)
    {
        return previousFrame ? previousFrameKeyCurrentlyPressed.GetValueOrDefault(keyMap[key], false) : keyCurrentlyPressed.GetValueOrDefault(keyMap[key], false);
    }

    private bool GetButtonPressState(MouseButton button, bool previousFrame)
    {
        return previousFrame ? previousFrameButtonCurrentlyPressed.GetValueOrDefault(mouseMap[button], false) : buttonCurrentlyPressed.GetValueOrDefault(mouseMap[button], false);
    }

    private readonly List<SDLEventType> targetEvents =
    [
        // EventType.WindowMouseEnter,
        // EventType.WindowMouseLeave,
        SDLEventType.MouseButtonDown,
        SDLEventType.MouseButtonUp,
        SDLEventType.MouseWheel,
        // EventType.MouseAdded,
        // EventType.MouseRemoved,
        SDLEventType.KeyDown,
        SDLEventType.KeyUp,
        // EventType.KeymapChanged,
        // EventType.KeyboardAdded,
        // EventType.KeyboardRemoved,
    ];

    public SDLInput(SDL3Window connectedWindow)
    {
        this.connectedWindow = connectedWindow;

        connectedWindow.GetManagedSDLWindow().HandleEvent += EventHandler;
    }

    private void EventHandler(SDLEventType eventType, SDLEvent eventData)
    {
        if (!targetEvents.Contains(eventType))
            return;

        // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
        switch (eventType)
        {
            case SDLEventType.MouseMotion:
                mousePosition = mousePosition with
                {
                    X = eventData.Motion.X,
                    Y = eventData.Motion.Y,
                };
                if (InputLogs)
                    Log.Debug($"Mouse Motion: <{eventData.Motion.X},{eventData.Motion.Y}> | Mouse Motion Relative: <{eventData.Motion.Xrel},{eventData.Motion.Yrel}>");
                break;
            case SDLEventType.MouseButtonDown:
                buttonCurrentlyPressed[(SDLMouseButtonFlags)eventData.Button.Button] = true;

                if (InputLogs)
                    Log.Debug($"Mouse Button Down: {eventData.Button.Button}");
                break;
            case SDLEventType.MouseButtonUp:
                buttonCurrentlyPressed[(SDLMouseButtonFlags)eventData.Button.Button] = false;

                if (InputLogs)
                    Log.Debug($"Mouse Button Up: {eventData.Button.Button}");
                break;
            case SDLEventType.MouseWheel:
                // lol invert moment
                mouseScroll = mouseScroll with
                {
                    X = eventData.Wheel.X * -1,
                    Y = eventData.Wheel.Y * -1,
                };

                if (InputLogs)
                    Log.Debug($"Mouse Wheel: <{eventData.Wheel.X},{eventData.Wheel.Y}> | Direction: <{eventData.Wheel.Direction}>");
                break;
            case SDLEventType.KeyDown:
                keyCurrentlyPressed[(SDLScancode)eventData.Key.Key] = true;

                if (InputLogs)
                    Log.Debug($"Key Down: {(SDLScancode)eventData.Key.Key} | Modifier: {eventData.Key.Mod}");
                break;
            case SDLEventType.KeyUp:
                keyCurrentlyPressed[(SDLScancode)eventData.Key.Key] = false;

                if (InputLogs)
                    Log.Debug($"Key Up: {(SDLScancode)eventData.Key.Key} | Modifier: {eventData.Key.Mod}");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(eventType), eventType, null);
        }
    }

    public void UpdateInput()
    {
        // TODO: fix this shit bro
        previousFrameKeyCurrentlyPressed = new Dictionary<SDLScancode, bool>(keyCurrentlyPressed);
        previousFrameButtonCurrentlyPressed = new Dictionary<SDLMouseButtonFlags, bool>(buttonCurrentlyPressed);

        previousMousePosition = previousMousePosition with
        {
            X = mousePosition.X,
            Y = mousePosition.Y,
        };

        mouseScroll = Vector2.Zero;


        if (cursorMode == CursorMode.Locked)
        {
            unsafe
            {
                
                NativeSDL.WarpMouseInWindow(connectedWindow.GetNativeWindow(), connectedWindow.Size.X / 2f, connectedWindow.Size.Y / 2f);
            }
        }
    }

    public bool SupportsInputKey(InputKey inputKey)
    {
        return keyMap[inputKey] != SDLScancode.Unknown;
    }

    public bool IsKeyPressed(InputKey key)
    {
        return !GetKeyPressState(key, true) && GetKeyPressState(key, false);
    }

    public bool IsKeyDown(InputKey key)
    {
        return GetKeyPressState(key, false);
    }

    public bool IsKeyReleased(InputKey key)
    {
        return GetKeyPressState(key, true) && !GetKeyPressState(key, false);
    }

    public bool IsKeyUp(InputKey key)
    {
        return !GetKeyPressState(key, false);
    }

    public bool IsMouseButtonPressed(MouseButton button)
    {
        return !GetButtonPressState(button, true) && GetButtonPressState(button, false);
    }

    public bool IsMouseButtonDown(MouseButton button)
    {
        return GetButtonPressState(button, false);
    }

    public bool IsMouseButtonReleased(MouseButton button)
    {
        return GetButtonPressState(button, true) && !GetButtonPressState(button, false);
    }

    public bool IsMouseButtonUp(MouseButton button)
    {
        return !GetButtonPressState(button, false);
    }

    public Vector2 GetMousePosition()
    {
        return mousePosition;
    }

    public Vector2 GetMouseDelta()
    {
        return mousePosition - previousMousePosition;
    }

    public Vector2 GetMouseScroll()
    {
        return mouseScroll;
    }

    public unsafe void SetCursorMode(CursorMode newMode)
    {
        cursorMode = newMode;

        switch (cursorMode)
        {
            case CursorMode.Normal:
                NativeSDL.ShowCursor();
                NativeSDL.SetWindowRelativeMouseMode(connectedWindow.GetNativeWindow(), false);
                break;
            case CursorMode.Hidden:
                NativeSDL.HideCursor();
                NativeSDL.SetWindowRelativeMouseMode(connectedWindow.GetNativeWindow(), false);
                break;
            case CursorMode.Locked:
                NativeSDL.HideCursor();
                NativeSDL.SetWindowRelativeMouseMode(connectedWindow.GetNativeWindow(), true);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(cursorMode), cursorMode, null);
        }
    }
}