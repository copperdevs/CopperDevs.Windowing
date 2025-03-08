using System.Collections;
using System.Diagnostics.CodeAnalysis;
using ImGuiNET;
using SDL;
using static SDL.SDL3;

namespace CopperDevs.Windowing.Testing;

public class ImGuiSdl3Exception(
    string message,
    Dictionary<string, object?>? data = null,
    Exception? innerException = null) : Exception(message, innerException)
{
    public override IDictionary Data { get; } = data ?? [];

    [DoesNotReturn]
    private static void Throw(
        string message,
        Dictionary<string, object?>? data = null,
        Exception? innerException = null) =>
        throw new ImGuiSdl3Exception(
            message: message,
            data: data,
            innerException: innerException);

    [DoesNotReturn]
    internal static void ThrowNoContext() =>
        Throw(
            message: "There is no current ImGui context."
        );

    [DoesNotReturn]
    internal static void ThrowAlreadyInitialized(IntPtr ctx) =>
        Throw(
            message: "This context is already initialized with a different window or renderer.",
            data: new Dictionary<string, object?>
            {
                ["Context"] = ctx
            }
        );

    [DoesNotReturn]
    internal static void ThrowSurfaceFailed(IntPtr ctx) =>
        Throw(
            message: "Failed to create the surface for the ImGui texture atlas.",
            innerException: new Exception(SDL_GetError()),
            data: new Dictionary<string, object?>
            {
                ["Context"] = ctx
            }
        );
    
    [DoesNotReturn]
    internal static void ThrowTextureFailed(IntPtr ctx, IntPtr surface) =>
        Throw(
            message: "Failed to create the texture for the ImGui texture atlas.",
            innerException: new Exception(SDL_GetError()),
            data: new Dictionary<string, object?>
            {
                ["Context"] = ctx,
                ["Surface"] = surface
            }
        );
    
    [DoesNotReturn]
    internal static void ThrowBlendModeFailed(IntPtr ctx, IntPtr texture) =>
        Throw(
            message: "Failed to set the blend mode for the ImGui texture atlas.",
            innerException: new Exception(SDL_GetError()),
            data: new Dictionary<string, object?>
            {
                ["Context"] = ctx,
                ["Texture"] = texture
            }
        );
    
    [DoesNotReturn]
    internal static void ThrowScaleModeFailed(IntPtr ctx, IntPtr texture) =>
        Throw(
            message: "Failed to set the scale mode for the ImGui texture atlas.",
            innerException: new Exception(SDL_GetError()),
            data: new Dictionary<string, object?>
            {
                ["Context"] = ctx,
                ["Texture"] = texture
            }
        );

    [DoesNotReturn]
    internal static void ThrowContextNotInitialized(IntPtr ctx) =>
        Throw(
            message: "The SDL3 backend was not initialized for the current ImGui context.",
            innerException: new Exception(SDL_GetError()),
            data: new Dictionary<string, object?>
            {
                ["Context"] = ctx
            }
        );

    [DoesNotReturn]
    public static void ThrowStopTextInputFailed(IntPtr ctx)
    {
        Throw(
            message: "Failed to stop IME text input.",
            innerException: new Exception(SDL_GetError()),
            data: new Dictionary<string, object?>
            {
                ["Context"] = ctx
            }
        );
    }

    [DoesNotReturn]
    public static void ThrowSetTextInputAreaFailed(IntPtr ctx)
    {
        Throw(
            message: "Failed to set the input text area for IME text input.",
            innerException: new Exception(SDL_GetError()),
            data: new Dictionary<string, object?>
            {
                ["Context"] = ctx
            }
        );
    }

    [DoesNotReturn]
    public static void ThrowStartTextInputFailed(IntPtr ctx)
    {
        Throw(
            message: "Failed to start IME text input.",
            innerException: new Exception(SDL_GetError()),
            data: new Dictionary<string, object?>
            {
                ["Context"] = ctx
            }
        );
    }

    [DoesNotReturn]
    public static void ThrowCreateSystemCursorFailed(
        IntPtr ctx, 
        ImGuiMouseCursor imGuiCursor,
        SDL_SystemCursor sdlCursor)
    {
        Throw(
            message: "Failed to create a system cursor.",
            innerException: new Exception(SDL_GetError()),
            data: new Dictionary<string, object?>
            {
                ["Context"] = ctx,
                ["ImGuiMouseCursor"] = imGuiCursor,
                ["SdlMouseCursor"] = sdlCursor
            }
        );
    }
}