#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDLAPI
{
    public static nint Metal_CreateView(SDL_Window* window) => SDL_Metal_CreateView(window);
    public static void Metal_DestroyView(nint view) => SDL_Metal_DestroyView(view);
    public static nint Metal_GetLayer(nint view) => SDL_Metal_GetLayer(view);
}