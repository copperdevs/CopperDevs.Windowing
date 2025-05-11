#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDLAPI
{
    public static bool CaptureMouse(bool enabled) => SDL_CaptureMouse(enabled);
    public static SDL_Cursor* CreateColorCursor(SDL_Surface* surface, int hotX, int hotY) => SDL_CreateColorCursor(surface, hotX, hotY);
    public static SDL_Cursor* CreateCursor(byte* data, byte* mask, int w, int h, int hotX, int hotY) => SDL_CreateCursor(data, mask, w, h, hotX, hotY);
    public static SDL_Cursor* CreateSystemCursor(SDL_SystemCursor cursor) => SDL_CreateSystemCursor(cursor);
    public static bool CursorVisible() => SDL_CursorVisible();
    public static void DestroyCursor(SDL_Cursor* cursor) => SDL_DestroyCursor(cursor);
    public static SDL_Cursor* GetCursor() => SDL_GetCursor();
    public static SDL_Cursor* GetDefaultCursor() => SDL_GetDefaultCursor();
    public static SDL_MouseButtonFlags GetGlobalMouseState(float* x, float* y) => SDL_GetGlobalMouseState(x, y);
    public static SDL_MouseID[] GetMice() => SDLUtil.ToArray(SDL_GetMice());
    public static SDL_Window* GetMouseFocus() => SDL_GetMouseFocus();
    public static string GetMouseNameForId(SDL_MouseID id) => SDL_GetMouseNameForID(id) ?? string.Empty;
    public static SDL_MouseButtonFlags GetMouseState(float* x, float* y) => SDL_GetMouseState(x, y);
    public static SDL_MouseButtonFlags GetRelativeMouseState(float* x, float* y) => SDL_GetRelativeMouseState(x, y);
    public static bool GetWindowMouseGrab(SDL_Window* window) => SDL_GetWindowMouseGrab(window);
    public static SDL_Rect* GetWindowMouseRect(SDL_Window* window) => SDL_GetWindowMouseRect(window);
    public static bool GetWindowRelativeMouseMode(SDL_Window* window) => SDL_GetWindowRelativeMouseMode(window);
    public static bool HasMouse() => SDL_HasMouse();
    public static bool HideCursor() => SDL_HideCursor();
    public static bool SetCursor(SDL_Cursor* cursor) => SDL_SetCursor(cursor);
    public static bool SetWindowMouseGrab(SDL_Window* window, bool grabbed) => SDL_SetWindowMouseGrab(window, grabbed);
    public static bool SetWindowMouseRect(SDL_Window* window, SDL_Rect* rect) => SDL_SetWindowMouseRect(window, rect);
    public static bool SetWindowRelativeMouseMode(SDL_Window* window, bool enabled) => SDL_SetWindowRelativeMouseMode(window, enabled);
    public static bool ShowCursor() => SDL_ShowCursor();
    public static bool WarpMouseGlobal(float x, float y) => SDL_WarpMouseGlobal(x, y);
    public static void WarpMouseInWindow(SDL_Window* window, float x, float y) => SDL_WarpMouseInWindow(window, x, y);
}