using System.Text;
using CopperDevs.Core.Data;
using CopperDevs.Windowing.SDL3.Data;

namespace CopperDevs.Windowing.SDL3;

// ReSharper disable once InconsistentNaming
internal static class SDL
{
    public static bool InitSubSystem(InitFlags flags) => SDL_InitSubSystem((SDL_InitFlags)flags);

    public static string GetError() => SDL_GetError() ?? string.Empty;

    public static unsafe SDL_Window* CreateWindow(string title, Vector2Int size, WindowFlags flags)
    {
        fixed (byte* titlePtr = Encoding.UTF8.GetBytes(title))
        {
            return SDL_CreateWindow(titlePtr, size.X, size.Y, (SDL_WindowFlags)flags);
        }
    }

    public static unsafe SDL_Renderer* CreateRenderer(SDL_Window* window) => SDL_CreateRenderer(window, (Utf8String)null);

    public static void Quit() => SDL_Quit();
    public static void QuitSubSystem(InitFlags flags) => SDL_QuitSubSystem((SDL_InitFlags)flags);

    public static void PumpEvents() => SDL_PumpEvents();

    public static int PeepEvents(SDL_Event[] events, SDL_EventAction action, SDL_EventType minType, SDL_EventType maxType) => SDL_PeepEvents(events, action, minType, maxType);

    public static unsafe Vector2Int GetWindowSize(SDL_Window* window)
    {
        int width;
        int height;

        var value = new Vector2Int(0);

        if (!SDL_GetWindowSize(window, &width, &height))
            return value;

        value.X = width;
        value.Y = height;

        return value;
    }

    public static bool SetHint(string name, string value) => SetHint((Utf8String)name, (Utf8String)value);
    public static bool SetHint(Utf8String name, string value) => SetHint(name, (Utf8String)value);

    public static bool SetHint(Utf8String name, Utf8String value) => SDL_SetHint(name, value);

    public static unsafe void SetRenderDrawColor(SDL_Renderer* renderer, float r, float g, float b, float a) => SDL_SetRenderDrawColorFloat(renderer, r, g, b, a);
    public static unsafe void RenderClear(SDL_Renderer* renderer) => SDL_RenderClear(renderer);
    public static unsafe void RenderPresent(SDL_Renderer* renderer) => SDL_RenderPresent(renderer);

    public static ulong GetTicks() => SDL_GetTicks();
}