using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void Metal_CreateView() => SDL_Metal_CreateView();
    public static void Metal_DestroyView() => SDL_Metal_DestroyView();
    public static void Metal_GetLayer() => SDL_Metal_GetLayer();
}