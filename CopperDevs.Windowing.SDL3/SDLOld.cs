using System.Numerics;
using CopperDevs.Core.Data;
using CopperDevs.Windowing.Data;
using CopperDevs.Windowing.SDL3.Data;

namespace CopperDevs.Windowing.SDL3;

// ReSharper disable once InconsistentNaming
internal static unsafe class SDLOld
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

        if (SDL_GetWindowPosition(window, &value.X, &value.Y))
            return value;
        return value with { X = 0, Y = 0 };
    }

    public static Vector2 GetRenderScale(SDL_Renderer* renderer)
    {
        var value = new Vector2(0);

        if (SDL_GetRenderScale(renderer, &value.X, &value.Y))
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

        if (SDL_RenderCoordinatesFromWindow(renderer, pos.X, pos.Y, &value.X, &value.Y))
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

        if (SDL_RenderCoordinatesToWindow(renderer, pos.X, pos.Y, &value.X, &value.Y))
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
    public static void DestroyRenderer(SDL_Renderer* renderer) => SDL_DestroyRenderer(renderer);
    public static void SetRenderScale(SDL_Renderer* renderer, Vector2 scale) => SDL_SetRenderScale(renderer, scale.X, scale.Y);
    public static void RenderDebugText(SDL_Renderer* renderer, string text, Vector2 position) => SDL_RenderDebugText(renderer, position.X, position.Y, text);
    public static void RenderLine(SDL_Renderer* renderer, Vector2 positionOne, Vector2 positionTwo) => SDL_RenderLine(renderer, positionOne.X, positionOne.Y, positionTwo.X, positionTwo.Y);
    public static void RenderLines(SDL_Renderer* renderer, List<Vector2> points) => SDL_RenderLines(renderer, SDLUtil.ToPointer(points, static vector => new SDL_FPoint { x = vector.X, y = vector.Y }), points.Count);
    public static void RenderPoint(SDL_Renderer* renderer, Vector2 position) => SDL_RenderPoint(renderer, position.X, position.Y);
    public static void RenderPoints(SDL_Renderer* renderer, List<Vector2> points) => SDL_RenderPoints(renderer, SDLUtil.ToPointer(points, static vector => new SDL_FPoint { x = vector.X, y = vector.Y }), points.Count);

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

    private static ReadOnlySpan<byte> GetAppMetadataPropertyProp(AppMetadata.MetadataProperty property)
    {
        var prop = property switch
        {
            AppMetadata.MetadataProperty.Name => SDL_PROP_APP_METADATA_NAME_STRING,
            AppMetadata.MetadataProperty.Version => SDL_PROP_APP_METADATA_VERSION_STRING,
            AppMetadata.MetadataProperty.Identifier => SDL_PROP_APP_METADATA_IDENTIFIER_STRING,
            AppMetadata.MetadataProperty.Creator => SDL_PROP_APP_METADATA_CREATOR_STRING,
            AppMetadata.MetadataProperty.Copyright => SDL_PROP_APP_METADATA_COPYRIGHT_STRING,
            AppMetadata.MetadataProperty.Url => SDL_PROP_APP_METADATA_URL_STRING,
            AppMetadata.MetadataProperty.Type => SDL_PROP_APP_METADATA_TYPE_STRING,
            _ => throw new ArgumentOutOfRangeException(nameof(property), property, null)
        };

        return prop;
    }

    public static bool SetAppMetadataProperty(AppMetadata.MetadataProperty property, string? value) => SDL_SetAppMetadataProperty(GetAppMetadataPropertyProp(property), value);

    public static string GetAppMetadataProperty(AppMetadata.MetadataProperty property) => SDL_GetAppMetadataProperty(GetAppMetadataPropertyProp(property)) ?? string.Empty;

    public static SDL_Surface* RenderReadPixels(SDL_Renderer* renderer, SDL_Rect* rect) => SDL_RenderReadPixels(renderer, rect);

    public static bool SaveBmp(SDL_Surface* surface, string filename) => SDL_SaveBMP(surface, filename);
    public static void DestroySurface(SDL_Surface* surface) => SDL_DestroySurface(surface);

    public static void RenderRect(SDL_Renderer* renderer, SDL_FRect rect) => SDL_RenderRect(renderer, &rect);
    public static void RenderRects(SDL_Renderer* renderer, List<SDL_FRect> rect) => SDL_RenderRects(renderer, SDLUtil.ToPointer(rect), rect.Count);

    public static void RenderFillRect(SDL_Renderer* renderer, SDL_FRect rect) => SDL_RenderFillRect(renderer, &rect);
    public static void RenderFillRects(SDL_Renderer* renderer, List<SDL_FRect> rect) => SDL_RenderFillRects(renderer, SDLUtil.ToPointer(rect), rect.Count);
}