#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace CopperDevs.Windowing.SDL3.Data;

/// <summary>
/// Wrapper for <see cref="WindowFlags"/>
/// </summary>
[Flags]
public enum WindowFlags : ulong
{
    Fullscreen = SDL_WindowFlags.SDL_WINDOW_FULLSCREEN,
    OpenGl = SDL_WindowFlags.SDL_WINDOW_OPENGL,
    Occluded = SDL_WindowFlags.SDL_WINDOW_OCCLUDED,
    Hidden = SDL_WindowFlags.SDL_WINDOW_HIDDEN,
    Borderless = SDL_WindowFlags.SDL_WINDOW_BORDERLESS,
    Resizable = SDL_WindowFlags.SDL_WINDOW_RESIZABLE,
    Minimized = SDL_WindowFlags.SDL_WINDOW_MINIMIZED,
    Maximized = SDL_WindowFlags.SDL_WINDOW_MAXIMIZED,
    MouseGrabbed = SDL_WindowFlags.SDL_WINDOW_MOUSE_GRABBED,
    InputFocus = SDL_WindowFlags.SDL_WINDOW_INPUT_FOCUS,
    MouseFocus = SDL_WindowFlags.SDL_WINDOW_MOUSE_FOCUS,
    External = SDL_WindowFlags.SDL_WINDOW_EXTERNAL,
    HighPixelDensity = SDL_WindowFlags.SDL_WINDOW_HIGH_PIXEL_DENSITY,
    MouseCapture = SDL_WindowFlags.SDL_WINDOW_MOUSE_CAPTURE,
    AlwaysOnTop = SDL_WindowFlags.SDL_WINDOW_ALWAYS_ON_TOP,
    Utility = SDL_WindowFlags.SDL_WINDOW_UTILITY,
    Tooltip = SDL_WindowFlags.SDL_WINDOW_TOOLTIP,
    PopupMenu = SDL_WindowFlags.SDL_WINDOW_POPUP_MENU,
    KeyboardGrabbed = SDL_WindowFlags.SDL_WINDOW_KEYBOARD_GRABBED,
    Vulkan = SDL_WindowFlags.SDL_WINDOW_VULKAN,
    Metal = SDL_WindowFlags.SDL_WINDOW_METAL,
    Transparent = SDL_WindowFlags.SDL_WINDOW_TRANSPARENT,
    NotFocusable = SDL_WindowFlags.SDL_WINDOW_NOT_FOCUSABLE,
}