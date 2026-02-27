using System.Numerics;
using CopperDevs.Celesium;
using CopperDevs.Windowing.Data;
using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

// thin layer above direct sdl for some methods
// mainly here for legacy reasons before the main wrapper was massively expanded
public static unsafe partial class SDLAPI
{
    public static Vector2Int GetWindowSize(SDL_Window* window)
    {
        var value = new Vector2Int(0);

        if (GetWindowSize(window, &value.X, &value.Y))
            return value;
        return value with { X = 0, Y = 0 };
    }

    public static Vector2Int GetWindowMaximumSize(SDL_Window* window)
    {
        var value = new Vector2Int(0);

        if (GetWindowMaximumSize(window, &value.X, &value.Y))
            return value;
        return value with { X = 0, Y = 0 };
    }

    public static Vector2Int GetWindowMinimumSize(SDL_Window* window)
    {
        var value = new Vector2Int(0);

        if (GetWindowMaximumSize(window, &value.X, &value.Y))
            return value;
        return value with { X = 0, Y = 0 };
    }

    public static Vector2Int GetWindowPosition(SDL_Window* window)
    {
        var value = new Vector2Int(0);

        if (GetWindowPosition(window, &value.X, &value.Y))
            return value;
        return value with { X = 0, Y = 0 };
    }

    public static Vector2 GetRenderScale(SDL_Renderer* renderer)
    {
        var value = new Vector2(0);

        if (GetRenderScale(renderer, &value.X, &value.Y))
            return value;
        return value with { X = 0, Y = 0 };
    }

    /// <summary>
    /// Get a point in render coordinates when given a point in window coordinates
    /// </summary>
    /// <param name="renderer">The rendering context</param>
    /// <param name="pos">The coordinates in window coordinates</param>
    /// <returns>The coordinates in render coordinates</returns>
    public static Vector2 RenderCoordinatesFromWindow(SDL_Renderer* renderer, Vector2 pos)
    {
        var value = new Vector2(0);

        if (RenderCoordinatesFromWindow(renderer, pos.X, pos.Y, &value.X, &value.Y))
            return value;
        return value with { X = 0, Y = 0 };
    }

    /// <summary>
    /// Get a point in window coordinates when given a point in render coordinates
    /// </summary>
    /// <param name="renderer">The rendering context</param>
    /// <param name="pos">The coordinates in render coordinates</param>
    /// <returns>Coordinates in window coordinates</returns>
    public static Vector2 RenderCoordinatesToWindow(SDL_Renderer* renderer, Vector2 pos)
    {
        var value = new Vector2(0);

        if (RenderCoordinatesToWindow(renderer, pos.X, pos.Y, &value.X, &value.Y))
            return value;
        return value with { X = 0, Y = 0 };
    }

    public static SDL_Window* CreateWindow(string title, Vector2Int size, WindowFlags flags) => CreateWindow(title, size.X, size.Y, (SDL_WindowFlags)flags);

    public static SDL_Renderer* CreateRenderer(SDL_Window* window) => CreateRenderer(window, (byte*)null);
    public static bool SetHint(Utf8String name, string value) => SetHint(name, (Utf8String)value);
    public static bool SetHint(Utf8String name, Utf8String value) => SDL_SetHint(name, value);
    public static void SetRenderDrawColor(SDL_Renderer* renderer, float r, float g, float b, float a) => SetRenderDrawColorFloat(renderer, r, g, b, a);
    public static void SetWindowSize(SDL_Window* window, Vector2Int size) => SetWindowSize(window, size.X, size.Y);
    public static void SetFullscreen(SDL_Window* window, bool fullscreen) => SetWindowFullscreen(window, fullscreen);
    public static WindowFlags GetFlags(SDL_Window* window) => (WindowFlags)GetWindowFlags(window);
    public static void SetAlwaysOnTop(SDL_Window* window, bool onTop) => SetWindowAlwaysOnTop(window, onTop);
    public static void Minimize(SDL_Window* window) => MinimizeWindow(window);
    public static void Maximize(SDL_Window* window) => MaximizeWindow(window);
    public static void SetWindowMaximumSize(SDL_Window* window, Vector2Int size) => SetWindowMaximumSize(window, size.X, size.Y);
    public static void SetWindowMinimumSize(SDL_Window* window, Vector2Int size) => SetWindowMinimumSize(window, size.X, size.Y);
    public static void SetWindowPosition(SDL_Window* window, Vector2Int position) => SetWindowPosition(window, position.X, position.Y);
    public static void SetMouseRelativeMode(SDL_Window* window, bool enabled) => SetWindowRelativeMouseMode(window, enabled);
    public static void WarpMouseInWindow(SDL_Window* window, Vector2Int position) => WarpMouseInWindow(window, position.X, position.Y);
    public static void SetRenderScale(SDL_Renderer* renderer, Vector2 scale) => SetRenderScale(renderer, scale.X, scale.Y);
    public static void RenderDebugText(SDL_Renderer* renderer, string text, Vector2 position) => RenderDebugText(renderer, position.X, position.Y, text);
    public static void RenderLine(SDL_Renderer* renderer, Vector2 positionOne, Vector2 positionTwo) => RenderLine(renderer, positionOne.X, positionOne.Y, positionTwo.X, positionTwo.Y);

    public static void RenderLines(SDL_Renderer* renderer, List<Vector2> points) =>
        RenderLines(renderer, SDLUtil.ToPointer(points, static vector => new SDL_FPoint { x = vector.X, y = vector.Y }), points.Count);

    public static void RenderPoint(SDL_Renderer* renderer, Vector2 position) => RenderPoint(renderer, position.X, position.Y);

    public static void RenderPoints(SDL_Renderer* renderer, List<Vector2> points) =>
        RenderPoints(renderer, SDLUtil.ToPointer(points, static vector => new SDL_FPoint { x = vector.X, y = vector.Y }), points.Count);

    public static SystemTheme GetSystemTheme()
    {
        return SDL_GetSystemTheme() switch
        {
            SDL_SystemTheme.SDL_SYSTEM_THEME_UNKNOWN => SystemTheme.Unknown,
            SDL_SystemTheme.SDL_SYSTEM_THEME_LIGHT => SystemTheme.Light,
            SDL_SystemTheme.SDL_SYSTEM_THEME_DARK => SystemTheme.Dark,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public static void RenderRect(SDL_Renderer* renderer, SDL_FRect rect) => RenderRect(renderer, &rect);
    public static void RenderRects(SDL_Renderer* renderer, List<SDL_FRect> rect) => RenderRects(renderer, SDLUtil.ToPointer(rect), rect.Count);
    public static void RenderFillRect(SDL_Renderer* renderer, SDL_FRect rect) => RenderFillRect(renderer, &rect);
    public static void RenderFillRects(SDL_Renderer* renderer, List<SDL_FRect> rect) => RenderFillRects(renderer, SDLUtil.ToPointer(rect), rect.Count);
}
