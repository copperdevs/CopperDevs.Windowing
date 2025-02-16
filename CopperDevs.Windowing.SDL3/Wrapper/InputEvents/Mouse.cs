using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void CaptureMouse() => SDL_CaptureMouse();
    public static void CreateColorCursor() => SDL_CreateColorCursor();
    public static void CreateCursor() => SDL_CreateCursor();
    public static void CreateSystemCursor() => SDL_CreateSystemCursor();
    public static void CursorVisible() => SDL_CursorVisible();
    public static void DestroyCursor() => SDL_DestroyCursor();
    public static void GetCursor() => SDL_GetCursor();
    public static void GetDefaultCursor() => SDL_GetDefaultCursor();
    public static void GetGlobalMouseState() => SDL_GetGlobalMouseState();
    public static void GetMice() => SDL_GetMice();
    public static void GetMouseFocus() => SDL_GetMouseFocus();
    public static void GetMouseNameForID() => SDL_GetMouseNameForID();
    public static void GetMouseState() => SDL_GetMouseState();
    public static void GetRelativeMouseState() => SDL_GetRelativeMouseState();
    public static void GetWindowMouseGrab() => SDL_GetWindowMouseGrab();
    public static void GetWindowMouseRect() => SDL_GetWindowMouseRect();
    public static void GetWindowRelativeMouseMode() => SDL_GetWindowRelativeMouseMode();
    public static void HasMouse() => SDL_HasMouse();
    public static void HideCursor() => SDL_HideCursor();
    public static void SetCursor() => SDL_SetCursor();
    public static void SetWindowMouseGrab() => SDL_SetWindowMouseGrab();
    public static void SetWindowMouseRect() => SDL_SetWindowMouseRect();
    public static void SetWindowRelativeMouseMode() => SDL_SetWindowRelativeMouseMode();
    public static void ShowCursor() => SDL_ShowCursor();
    public static void WarpMouseGlobal() => SDL_WarpMouseGlobal();
    public static void WarpMouseInWindow() => SDL_WarpMouseInWindow();
}