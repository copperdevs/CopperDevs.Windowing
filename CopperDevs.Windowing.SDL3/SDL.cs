using System.Text;
using CopperDevs.Core.Data;
using CopperDevs.Windowing.SDL3.Data;

namespace CopperDevs.Windowing.SDL3;

// ReSharper disable once InconsistentNaming
internal static unsafe class SDL
{
    public static Vector2Int GetWindowSize(SDL_Window* window)
    {
        var value = new Vector2Int(0);

        if (SDL_GetWindowSize(window, &value.X, &value.Y))
            return value;
        return value with { X = 0, Y = 0 };
    }

    public static Vector2Int GetWindowMaximumSize(SDL_Window* window)
    {
        var value = new Vector2Int(0);

        if (SDL_GetWindowMaximumSize(window, &value.X, &value.Y))
            return value;
        return value with { X = 0, Y = 0 };
    }

    public static Vector2Int GetWindowMinimumSize(SDL_Window* window)
    {
        var value = new Vector2Int(0);

        if (SDL_GetWindowMaximumSize(window, &value.X, &value.Y))
            return value;
        return value with { X = 0, Y = 0 };
    }

    public static Vector2Int GetWindowPosition(SDL_Window* window)
    {
        var value = new Vector2Int(0);
        
        if(SDL_GetWindowPosition(window, &value.X, &value.Y))
            return value;
        return value with { X = 0, Y = 0 };
    }

    public static bool InitSubSystem(InitFlags flags) => SDL_InitSubSystem((SDL_InitFlags)flags);
    public static string GetError() => SDL_GetError() ?? string.Empty;
    public static SDL_Window* CreateWindow(string title, Vector2Int size, WindowFlags flags) => SDL_CreateWindow(title, size.X, size.Y, (SDL_WindowFlags)flags);
    public static SDL_Renderer* CreateRenderer(SDL_Window* window) => SDL_CreateRenderer(window, (Utf8String)null);
    public static void Quit() => SDL_Quit();
    public static void QuitSubSystem(InitFlags flags) => SDL_QuitSubSystem((SDL_InitFlags)flags);
    public static void PumpEvents() => SDL_PumpEvents();
    public static int PeepEvents(SDL_Event[] events, SDL_EventAction action, SDL_EventType minType, SDL_EventType maxType) => SDL_PeepEvents(events, action, minType, maxType);
    public static bool SetHint(string name, string value) => SetHint((Utf8String)name, (Utf8String)value);
    public static bool SetHint(Utf8String name, string value) => SetHint(name, (Utf8String)value);
    public static bool SetHint(Utf8String name, Utf8String value) => SDL_SetHint(name, value);
    public static void SetRenderDrawColor(SDL_Renderer* renderer, float r, float g, float b, float a) => SDL_SetRenderDrawColorFloat(renderer, r, g, b, a);
    public static void RenderClear(SDL_Renderer* renderer) => SDL_RenderClear(renderer);
    public static void RenderPresent(SDL_Renderer* renderer) => SDL_RenderPresent(renderer);
    public static ulong GetTicks() => SDL_GetTicks();
    public static void SetWindowSize(SDL_Window* window, Vector2Int size) => SDL_SetWindowSize(window, size.X, size.Y);
    public static void SetWindowTitle(SDL_Window* window, string title) => SDL_SetWindowTitle(window, title);
    public static string GetWindowTitle(SDL_Window* window) => SDL_GetWindowTitle(window) ?? string.Empty;
    public static void SetFullscreen(SDL_Window* window, bool fullscreen) => SDL_SetWindowFullscreen(window, fullscreen);
    public static WindowFlags GetFlags(SDL_Window* window) => (WindowFlags)SDL_GetWindowFlags(window);
    public static void SetAlwaysOnTop(SDL_Window* window, bool onTop) => SDL_SetWindowAlwaysOnTop(window, onTop);
    public static void Minimize(SDL_Window* window) => SDL_MinimizeWindow(window);
    public static void Maximize(SDL_Window* window) => SDL_MaximizeWindow(window);
    public static void SetWindowMaximumSize(SDL_Window* window, Vector2Int size) => SDL_SetWindowMaximumSize(window, size.X, size.Y);
    public static void SetWindowMinimumSize(SDL_Window* window, Vector2Int size) => SDL_SetWindowMinimumSize(window, size.X, size.Y);
    public static void SetWindowPosition(SDL_Window* window, Vector2Int position) => SDL_SetWindowPosition(window, position.X, position.Y);
    public static void FlashWindow(SDL_Window* window, SDL_FlashOperation operation) => SDL_FlashWindow(window, operation);
    public static void ShowCursor() => SDL_ShowCursor();
    public static void HideCursor() => SDL_HideCursor();
    public static void SetMouseRelativeMode(SDL_Window* window, bool enabled) => SDL_SetWindowRelativeMouseMode(window, enabled);
    public static void WarpMouseInWindow(SDL_Window* window, Vector2Int position) => SDL_WarpMouseInWindow(window, position.X, position.Y);
}