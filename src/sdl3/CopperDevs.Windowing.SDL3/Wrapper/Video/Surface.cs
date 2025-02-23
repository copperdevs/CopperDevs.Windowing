using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDLAPI
{
    public static bool AddSurfaceAlternateImage(SDL_Surface* surface, SDL_Surface* image) => SDL_AddSurfaceAlternateImage(surface, image);
    public static bool BlitSurface(SDL_Surface* src, SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect) => SDL_BlitSurface(src, srcrect, dst, dstrect);

    public static bool BlitSurface9Grid(SDL_Surface* src, SDL_Rect* srcrect, int leftWidth, int rightWidth, int topHeight, int bottomHeight, float scale, SDL_ScaleMode scaleMode, SDL_Surface* dst, SDL_Rect* dstrect) =>
        SDL_BlitSurface9Grid(src, srcrect, leftWidth, rightWidth, topHeight, bottomHeight, scale, scaleMode, dst, dstrect);

    public static bool BlitSurfaceScaled(SDL_Surface* src, SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect, SDL_ScaleMode scaleMode) => SDL_BlitSurfaceScaled(src, srcrect, dst, dstrect, scaleMode);
    public static bool BlitSurfaceTiled(SDL_Surface* src, SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect) => SDL_BlitSurfaceTiled(src, srcrect, dst, dstrect);

    public static bool BlitSurfaceTiledWithScale(SDL_Surface* src, SDL_Rect* srcrect, float scale, SDL_ScaleMode scaleMode, SDL_Surface* dst, SDL_Rect* dstrect) =>
        SDL_BlitSurfaceTiledWithScale(src, srcrect, scale, scaleMode, dst, dstrect);

    public static bool BlitSurfaceUnchecked(SDL_Surface* src, SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect) => SDL_BlitSurfaceUnchecked(src, srcrect, dst, dstrect);
    public static bool BlitSurfaceUncheckedScaled(SDL_Surface* src, SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect, SDL_ScaleMode scaleMode) => SDL_BlitSurfaceUncheckedScaled(src, srcrect, dst, dstrect, scaleMode);
    public static bool ClearSurface(SDL_Surface* surface, float r, float g, float b, float a) => SDL_ClearSurface(surface, r, g, b, a);

    public static bool ConvertPixels(int width, int height, SDL_PixelFormat srcFormat, IntPtr src, int srcPitch, SDL_PixelFormat dstFormat, IntPtr dst, int dstPitch) =>
        SDL_ConvertPixels(width, height, srcFormat, src, srcPitch, dstFormat, dst, dstPitch);

    public static bool ConvertPixelsAndColorspace(int width, int height, SDL_PixelFormat srcFormat, SDL_Colorspace srcColorspace, SDL_PropertiesID srcProperties, IntPtr src, int srcPitch, SDL_PixelFormat dstFormat,
        SDL_Colorspace dstColorspace, SDL_PropertiesID dstProperties, IntPtr dst, int dstPitch) =>
        SDL_ConvertPixelsAndColorspace(width, height, srcFormat, srcColorspace, srcProperties, src, srcPitch, dstFormat, dstColorspace, dstProperties, dst, dstPitch);

    public static SDL_Surface* ConvertSurface(SDL_Surface* surface, SDL_PixelFormat format) => SDL_ConvertSurface(surface, format);

    public static SDL_Surface* ConvertSurfaceAndColorspace(SDL_Surface* surface, SDL_PixelFormat format, SDL_Palette* palette, SDL_Colorspace colorspace, SDL_PropertiesID props) =>
        SDL_ConvertSurfaceAndColorspace(surface, format, palette, colorspace, props);

    public static SDL_Surface* CreateSurface(int width, int height, SDL_PixelFormat format) => SDL_CreateSurface(width, height, format);
    public static SDL_Surface* CreateSurfaceFrom(int width, int height, SDL_PixelFormat format, IntPtr pixels, int pitch) => SDL_CreateSurfaceFrom(width, height, format, pixels, pitch);
    public static SDL_Palette* CreateSurfacePalette(SDL_Surface* surface) => SDL_CreateSurfacePalette(surface);
    public static void DestroySurface(SDL_Surface* surface) => SDL_DestroySurface(surface);
    public static SDL_Surface* DuplicateSurface(SDL_Surface* surface) => SDL_DuplicateSurface(surface);
    public static bool FillSurfaceRect(SDL_Surface* dst, SDL_Rect* rect, uint color) => SDL_FillSurfaceRect(dst, rect, color);
    public static bool FillSurfaceRects(SDL_Surface* dst, SDL_Rect* rects, int count, uint color) => SDL_FillSurfaceRects(dst, rects, count, color);
    public static bool FlipSurface(SDL_Surface* surface, SDL_FlipMode flip) => SDL_FlipSurface(surface, flip);
    public static bool GetSurfaceAlphaMod(SDL_Surface* surface, byte* alpha) => SDL_GetSurfaceAlphaMod(surface, alpha);
    public static bool GetSurfaceBlendMode(SDL_Surface* surface, SDL_BlendMode* blendMode) => SDL_GetSurfaceBlendMode(surface, blendMode);
    public static bool GetSurfaceClipRect(SDL_Surface* surface, SDL_Rect* rect) => SDL_GetSurfaceClipRect(surface, rect);
    public static bool GetSurfaceColorKey(SDL_Surface* surface, uint* key) => SDL_GetSurfaceColorKey(surface, key);
    public static bool GetSurfaceColorMod(SDL_Surface* surface, byte* r, byte* g, byte* b) => SDL_GetSurfaceColorMod(surface, r, g, b);
    public static SDL_Colorspace GetSurfaceColorspace(SDL_Surface* surface) => SDL_GetSurfaceColorspace(surface);
    public static SDL_Surface** GetSurfaceImages(SDL_Surface* surface, int* count) => SDL_GetSurfaceImages(surface, count);
    public static SDL_Palette* GetSurfacePalette(SDL_Surface* surface) => SDL_GetSurfacePalette(surface);
    public static SDL_PropertiesID GetSurfaceProperties(SDL_Surface* surface) => SDL_GetSurfaceProperties(surface);
    public static SDL_Surface* LoadBmp(byte* file) => SDL_LoadBMP(file);
    public static SDL_Surface* LoadBmp(string file) => SDL_LoadBMP(file);
    public static SDL_Surface* LoadBMP_IO(SDL_IOStream* src, bool closeio) => SDL_LoadBMP_IO(src, closeio);
    public static bool LockSurface(SDL_Surface* surface) => SDL_LockSurface(surface);
    public static uint MapSurfaceRgb(SDL_Surface* surface, byte r, byte g, byte b) => SDL_MapSurfaceRGB(surface, r, g, b);
    public static uint MapSurfaceRgba(SDL_Surface* surface, byte r, byte g, byte b, byte a) => SDL_MapSurfaceRGBA(surface, r, g, b, a);

    public static bool PremultiplyAlpha(int width, int height, SDL_PixelFormat srcFormat, IntPtr src, int srcPitch, SDL_PixelFormat dstFormat, IntPtr dst, int dstPitch, bool linear) =>
        SDL_PremultiplyAlpha(width, height, srcFormat, src, srcPitch, dstFormat, dst, dstPitch, linear);

    public static bool PremultiplySurfaceAlpha(SDL_Surface* surface, bool linear) => SDL_PremultiplySurfaceAlpha(surface, linear);
    public static bool ReadSurfacePixel(SDL_Surface* surface, int x, int y, byte* r, byte* g, byte* b, byte* a) => SDL_ReadSurfacePixel(surface, x, y, r, g, b, a);
    public static bool ReadSurfacePixelFloat(SDL_Surface* surface, int x, int y, float* r, float* g, float* b, float* a) => SDL_ReadSurfacePixelFloat(surface, x, y, r, g, b, a);
    public static void RemoveSurfaceAlternateImages(SDL_Surface* surface) => SDL_RemoveSurfaceAlternateImages(surface);
    public static bool SaveBmp(SDL_Surface* surface, byte* file) => SDL_SaveBMP(surface, file);
    public static bool SaveBmp(SDL_Surface* surface, string file) => SDL_SaveBMP(surface, file);
    public static bool SaveBMP_IO(SDL_Surface* surface, SDL_IOStream* dst, bool closeio) => SDL_SaveBMP_IO(surface, dst, closeio);
    public static SDL_Surface* ScaleSurface(SDL_Surface* surface, int width, int height, SDL_ScaleMode scaleMode) => SDL_ScaleSurface(surface, width, height, scaleMode);
    public static bool SetSurfaceAlphaMod(SDL_Surface* surface, byte alpha) => SDL_SetSurfaceAlphaMod(surface, alpha);
    public static bool SetSurfaceBlendMode(SDL_Surface* surface, SDL_BlendMode blendMode) => SDL_SetSurfaceBlendMode(surface, blendMode);
    public static bool SetSurfaceClipRect(SDL_Surface* surface, SDL_Rect* rect) => SDL_SetSurfaceClipRect(surface, rect);
    public static bool SetSurfaceColorKey(SDL_Surface* surface, bool enabled, uint key) => SDL_SetSurfaceColorKey(surface, enabled, key);
    public static bool SetSurfaceColorMod(SDL_Surface* surface, byte r, byte g, byte b) => SDL_SetSurfaceColorMod(surface, r, g, b);
    public static bool SetSurfaceColorspace(SDL_Surface* surface, SDL_Colorspace colorspace) => SDL_SetSurfaceColorspace(surface, colorspace);
    public static bool SetSurfacePalette(SDL_Surface* surface, SDL_Palette* palette) => SDL_SetSurfacePalette(surface, palette);
    public static bool SetSurfaceRle(SDL_Surface* surface, bool enabled) => SDL_SetSurfaceRLE(surface, enabled);
    public static bool SurfaceHasAlternateImages(SDL_Surface* surface) => SDL_SurfaceHasAlternateImages(surface);
    public static bool SurfaceHasColorKey(SDL_Surface* surface) => SDL_SurfaceHasColorKey(surface);
    public static bool SurfaceHasRle(SDL_Surface* surface) => SDL_SurfaceHasRLE(surface);
    public static void UnlockSurface(SDL_Surface* surface) => SDL_UnlockSurface(surface);
    public static bool WriteSurfacePixel(SDL_Surface* surface, int x, int y, byte r, byte g, byte b, byte a) => SDL_WriteSurfacePixel(surface, x, y, r, g, b, a);
    public static bool WriteSurfacePixelFloat(SDL_Surface* surface, int x, int y, float r, float g, float b, float a) => SDL_WriteSurfacePixelFloat(surface, x, y, r, g, b, a);
}