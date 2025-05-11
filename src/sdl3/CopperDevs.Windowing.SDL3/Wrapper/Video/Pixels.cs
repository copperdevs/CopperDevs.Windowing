#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDLAPI
{
    public static SDL_Palette* CreatePalette(int colors) => SDL_CreatePalette(colors);
    public static void DestroyPalette(SDL_Palette* palette) => SDL_DestroyPalette(palette);

    public static bool GetMasksForPixelFormat(SDL_PixelFormat format, int* bpp, uint* rmask, uint* gmask, uint* bmask, uint* amask) =>
        SDL_GetMasksForPixelFormat(format, bpp, rmask, gmask, bmask, amask);

    public static SDL_PixelFormatDetails* GetPixelFormatDetails(SDL_PixelFormat format) => SDL_GetPixelFormatDetails(format);

    public static void GetPixelFormatForMasks(int bpp, uint rmask, uint gmask, uint bmask, uint amask) => SDL_GetPixelFormatForMasks(bpp, rmask, gmask, bmask, amask);

    public static string GetPixelFormatName(SDL_PixelFormat format) => SDL_GetPixelFormatName(format) ?? string.Empty;

    public static void GetRgb(uint pixel, SDL_PixelFormatDetails* format, SDL_Palette* palette, byte* r, byte* g, byte* b) => SDL_GetRGB(pixel, format, palette, r, g, b);

    public static void GetRgba(uint pixel, SDL_PixelFormatDetails* format, SDL_Palette* palette, byte* r, byte* g, byte* b, byte* a) => SDL_GetRGBA(pixel, format, palette, r, g, b, a);
    public static uint MapRgb(SDL_PixelFormatDetails* format, SDL_Palette* palette, byte r, byte g, byte b) => SDL_MapRGB(format, palette, r, g, b);
    public static void MapRgba(SDL_PixelFormatDetails* format, SDL_Palette* palette, byte r, byte g, byte b, byte a) => SDL_MapRGBA(format, palette, r, g, b, a);
    public static void SetPaletteColors(SDL_Palette* palette, SDL_Color* colors, int firstcolor, int ncolors) => SDL_SetPaletteColors(palette, colors, firstcolor, ncolors);
}