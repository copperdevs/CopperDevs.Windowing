using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void AddVulkanRenderSemaphores() => SDL_AddVulkanRenderSemaphores();
    public static void ConvertEventToRenderCoordinates() => SDL_ConvertEventToRenderCoordinates();
    public static void CreateRenderer() => SDL_CreateRenderer();
    public static void CreateRendererWithProperties() => SDL_CreateRendererWithProperties();
    public static void CreateSoftwareRenderer() => SDL_CreateSoftwareRenderer();
    public static void CreateTexture() => SDL_CreateTexture();
    public static void CreateTextureFromSurface() => SDL_CreateTextureFromSurface();
    public static void CreateTextureWithProperties() => SDL_CreateTextureWithProperties();
    public static void CreateWindowAndRenderer() => SDL_CreateWindowAndRenderer();
    public static void DestroyRenderer() => SDL_DestroyRenderer();
    public static void DestroyTexture() => SDL_DestroyTexture();
    public static void FlushRenderer() => SDL_FlushRenderer();
    public static void GetCurrentRenderOutputSize() => SDL_GetCurrentRenderOutputSize();
    public static void GetNumRenderDrivers() => SDL_GetNumRenderDrivers();
    public static void GetRenderClipRect() => SDL_GetRenderClipRect();
    public static void GetRenderColorScale() => SDL_GetRenderColorScale();
    public static void GetRenderDrawBlendMode() => SDL_GetRenderDrawBlendMode();
    public static void GetRenderDrawColor() => SDL_GetRenderDrawColor();
    public static void GetRenderDrawColorFloat() => SDL_GetRenderDrawColorFloat();
    public static void GetRenderDriver() => SDL_GetRenderDriver();
    public static void GetRenderer() => SDL_GetRenderer();
    public static void GetRendererFromTexture() => SDL_GetRendererFromTexture();
    public static void GetRendererName() => SDL_GetRendererName();
    public static void GetRendererProperties() => SDL_GetRendererProperties();
    public static void GetRenderLogicalPresentation() => SDL_GetRenderLogicalPresentation();
    public static void GetRenderLogicalPresentationRect() => SDL_GetRenderLogicalPresentationRect();
    public static void GetRenderMetalCommandEncoder() => SDL_GetRenderMetalCommandEncoder();
    public static void GetRenderMetalLayer() => SDL_GetRenderMetalLayer();
    public static void GetRenderOutputSize() => SDL_GetRenderOutputSize();
    public static void GetRenderSafeArea() => SDL_GetRenderSafeArea();
    public static void GetRenderScale() => SDL_GetRenderScale();
    public static void GetRenderTarget() => SDL_GetRenderTarget();
    public static void GetRenderViewport() => SDL_GetRenderViewport();
    public static void GetRenderVSync() => SDL_GetRenderVSync();
    public static void GetRenderWindow() => SDL_GetRenderWindow();
    public static void GetTextureAlphaMod() => SDL_GetTextureAlphaMod();
    public static void GetTextureAlphaModFloat() => SDL_GetTextureAlphaModFloat();
    public static void GetTextureBlendMode() => SDL_GetTextureBlendMode();
    public static void GetTextureColorMod() => SDL_GetTextureColorMod();
    public static void GetTextureColorModFloat() => SDL_GetTextureColorModFloat();
    public static void GetTextureProperties() => SDL_GetTextureProperties();
    public static void GetTextureScaleMode() => SDL_GetTextureScaleMode();
    public static void GetTextureSize() => SDL_GetTextureSize();
    public static void LockTexture() => SDL_LockTexture();
    public static void LockTextureToSurface() => SDL_LockTextureToSurface();
    public static void RenderClear() => SDL_RenderClear();
    public static void RenderClipEnabled() => SDL_RenderClipEnabled();
    public static void RenderCoordinatesFromWindow() => SDL_RenderCoordinatesFromWindow();
    public static void RenderCoordinatesToWindow() => SDL_RenderCoordinatesToWindow();
    public static void RenderDebugText() => SDL_RenderDebugText();
    public static void RenderDebugTextFormat() => SDL_RenderDebugTextFormat();
    public static void RenderFillRect() => SDL_RenderFillRect();
    public static void RenderFillRects() => SDL_RenderFillRects();
    public static void RenderGeometry() => SDL_RenderGeometry();
    public static void RenderGeometryRaw() => SDL_RenderGeometryRaw();
    public static void RenderLine() => SDL_RenderLine();
    public static void RenderLines() => SDL_RenderLines();
    public static void RenderPoint() => SDL_RenderPoint();
    public static void RenderPoints() => SDL_RenderPoints();
    public static void RenderPresent() => SDL_RenderPresent();
    public static void RenderReadPixels() => SDL_RenderReadPixels();
    public static void RenderRect() => SDL_RenderRect();
    public static void RenderRects() => SDL_RenderRects();
    public static void RenderTexture() => SDL_RenderTexture();
    public static void RenderTexture9Grid() => SDL_RenderTexture9Grid();
    public static void RenderTextureAffine() => SDL_RenderTextureAffine();
    public static void RenderTextureRotated() => SDL_RenderTextureRotated();
    public static void RenderTextureTiled() => SDL_RenderTextureTiled();
    public static void RenderViewportSet() => SDL_RenderViewportSet();
    public static void SetRenderClipRect() => SDL_SetRenderClipRect();
    public static void SetRenderColorScale() => SDL_SetRenderColorScale();
    public static void SetRenderDrawBlendMode() => SDL_SetRenderDrawBlendMode();
    public static void SetRenderDrawColor() => SDL_SetRenderDrawColor();
    public static void SetRenderDrawColorFloat() => SDL_SetRenderDrawColorFloat();
    public static void SetRenderLogicalPresentation() => SDL_SetRenderLogicalPresentation();
    public static void SetRenderScale() => SDL_SetRenderScale();
    public static void SetRenderTarget() => SDL_SetRenderTarget();
    public static void SetRenderViewport() => SDL_SetRenderViewport();
    public static void SetRenderVSync() => SDL_SetRenderVSync();
    public static void SetTextureAlphaMod() => SDL_SetTextureAlphaMod();
    public static void SetTextureAlphaModFloat() => SDL_SetTextureAlphaModFloat();
    public static void SetTextureBlendMode() => SDL_SetTextureBlendMode();
    public static void SetTextureColorMod() => SDL_SetTextureColorMod();
    public static void SetTextureColorModFloat() => SDL_SetTextureColorModFloat();
    public static void SetTextureScaleMode() => SDL_SetTextureScaleMode();
    public static void UnlockTexture() => SDL_UnlockTexture();
    public static void UpdateNVTexture() => SDL_UpdateNVTexture();
    public static void UpdateTexture() => SDL_UpdateTexture();
    public static void UpdateYUVTexture() => SDL_UpdateYUVTexture();
}