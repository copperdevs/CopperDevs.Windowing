using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void AddSurfaceAlternateImage() => SDL_AddSurfaceAlternateImage();
    public static void BlitSurface() => SDL_BlitSurface();
    public static void BlitSurface9Grid() => SDL_BlitSurface9Grid();
    public static void BlitSurfaceScaled() => SDL_BlitSurfaceScaled();
    public static void BlitSurfaceTiled() => SDL_BlitSurfaceTiled();
    public static void BlitSurfaceTiledWithScale() => SDL_BlitSurfaceTiledWithScale();
    public static void BlitSurfaceUnchecked() => SDL_BlitSurfaceUnchecked();
    public static void BlitSurfaceUncheckedScaled() => SDL_BlitSurfaceUncheckedScaled();
    public static void ClearSurface() => SDL_ClearSurface();
    public static void ConvertPixels() => SDL_ConvertPixels();
    public static void ConvertPixelsAndColorspace() => SDL_ConvertPixelsAndColorspace();
    public static void ConvertSurface() => SDL_ConvertSurface();
    public static void ConvertSurfaceAndColorspace() => SDL_ConvertSurfaceAndColorspace();
    public static void CreateSurface() => SDL_CreateSurface();
    public static void CreateSurfaceFrom() => SDL_CreateSurfaceFrom();
    public static void CreateSurfacePalette() => SDL_CreateSurfacePalette();
    public static void DestroySurface() => SDL_DestroySurface();
    public static void DuplicateSurface() => SDL_DuplicateSurface();
    public static void FillSurfaceRect() => SDL_FillSurfaceRect();
    public static void FillSurfaceRects() => SDL_FillSurfaceRects();
    public static void FlipSurface() => SDL_FlipSurface();
    public static void GetSurfaceAlphaMod() => SDL_GetSurfaceAlphaMod();
    public static void GetSurfaceBlendMode() => SDL_GetSurfaceBlendMode();
    public static void GetSurfaceClipRect() => SDL_GetSurfaceClipRect();
    public static void GetSurfaceColorKey() => SDL_GetSurfaceColorKey();
    public static void GetSurfaceColorMod() => SDL_GetSurfaceColorMod();
    public static void GetSurfaceColorspace() => SDL_GetSurfaceColorspace();
    public static void GetSurfaceImages() => SDL_GetSurfaceImages();
    public static void GetSurfacePalette() => SDL_GetSurfacePalette();
    public static void GetSurfaceProperties() => SDL_GetSurfaceProperties();
    public static void LoadBMP() => SDL_LoadBMP();
    public static void LoadBMP_IO() => SDL_LoadBMP_IO();
    public static void LockSurface() => SDL_LockSurface();
    public static void MapSurfaceRGB() => SDL_MapSurfaceRGB();
    public static void MapSurfaceRGBA() => SDL_MapSurfaceRGBA();
    public static void PremultiplyAlpha() => SDL_PremultiplyAlpha();
    public static void PremultiplySurfaceAlpha() => SDL_PremultiplySurfaceAlpha();
    public static void ReadSurfacePixel() => SDL_ReadSurfacePixel();
    public static void ReadSurfacePixelFloat() => SDL_ReadSurfacePixelFloat();
    public static void RemoveSurfaceAlternateImages() => SDL_RemoveSurfaceAlternateImages();
    public static void SaveBMP() => SDL_SaveBMP();
    public static void SaveBMP_IO() => SDL_SaveBMP_IO();
    public static void ScaleSurface() => SDL_ScaleSurface();
    public static void SetSurfaceAlphaMod() => SDL_SetSurfaceAlphaMod();
    public static void SetSurfaceBlendMode() => SDL_SetSurfaceBlendMode();
    public static void SetSurfaceClipRect() => SDL_SetSurfaceClipRect();
    public static void SetSurfaceColorKey() => SDL_SetSurfaceColorKey();
    public static void SetSurfaceColorMod() => SDL_SetSurfaceColorMod();
    public static void SetSurfaceColorspace() => SDL_SetSurfaceColorspace();
    public static void SetSurfacePalette() => SDL_SetSurfacePalette();
    public static void SetSurfaceRLE() => SDL_SetSurfaceRLE();
    public static void SoftStretch() => SDL_SoftStretch();
    public static void StretchSurface() => SDL_StretchSurface();
    public static void SurfaceHasAlternateImages() => SDL_SurfaceHasAlternateImages();
    public static void SurfaceHasColorKey() => SDL_SurfaceHasColorKey();
    public static void SurfaceHasRLE() => SDL_SurfaceHasRLE();
    public static void UnlockSurface() => SDL_UnlockSurface();
    public static void WriteSurfacePixel() => SDL_WriteSurfacePixel();
    public static void WriteSurfacePixelFloat() => SDL_WriteSurfacePixelFloat();
}