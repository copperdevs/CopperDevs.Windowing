using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static SDL_Palette* CreatePalette(int colors) => SDL_CreatePalette(colors);
    public static void DestroyPalette(SDL_Palette* palette) => SDL_DestroyPalette(palette);
    public static void GetMasksForPixelFormat() => SDL_GetMasksForPixelFormat();
    public static void GetPixelFormatDetails() => SDL_GetPixelFormatDetails();
    public static void GetPixelFormatForMasks() => SDL_GetPixelFormatForMasks();
    public static void GetPixelFormatName() => SDL_GetPixelFormatName();
    public static void GetRGB() => SDL_GetRGB();
    public static void GetRGBA() => SDL_GetRGBA();
    public static void MapRGB() => SDL_MapRGB();
    public static void MapRGBA() => SDL_MapRGBA();
    public static void SetPaletteColors() => SDL_SetPaletteColors();
}