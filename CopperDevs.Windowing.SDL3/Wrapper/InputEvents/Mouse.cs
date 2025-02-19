using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static bool CaptureMouse(bool enabled) => SDL_CaptureMouse(enabled);
    public static SDL_Cursor* CreateColorCursor(SDL_Surface* surface, int hot_x, int hot_y) => SDL_CreateColorCursor(surface, hot_x, hot_y);
    public static SDL_Cursor* CreateCursor(byte* data, byte* mask, int w, int h, int hot_x, int hot_y) => SDL_CreateCursor(data, mask, w, h, hot_x, hot_y);
    public static SDL_Cursor* CreateSystemCursor(SDL_SystemCursor cursor) => SDL_CreateSystemCursor(cursor);
    public static bool CursorVisible() => SDL_CursorVisible();
    public static void DestroyCursor(SDL_Cursor* cursor) => SDL_DestroyCursor(cursor);
    public static SDL_Cursor* GetCursor() => SDL_GetCursor();
    public static SDL_Cursor* GetDefaultCursor() => SDL_GetDefaultCursor();
    public static SDL_MouseButtonFlags GetGlobalMouseState(float* x, float* y) => SDL_GetGlobalMouseState(x, y);
    public static SDL_MouseID[] GetMice() => SDLUtil.ToArray(SDL_GetMice());
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