using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static bool AddVulkanRenderSemaphores(SDL_Renderer* renderer, uint waitStageMask, long waitSemaphore, long signalSemaphore)
        => SDL_AddVulkanRenderSemaphores(renderer, waitStageMask, waitSemaphore, signalSemaphore);

    public static bool ConvertEventToRenderCoordinates(SDL_Renderer* renderer, SDL_Event* @event) => SDL_ConvertEventToRenderCoordinates(renderer, @event);

    public static SDL_Renderer* CreateRenderer(SDL_Window* window, string name) => SDL_CreateRenderer(window, name);

    public static SDL_Renderer* CreateRendererWithProperties(SDL_PropertiesID props) => SDL_CreateRendererWithProperties(props);

    public static SDL_Renderer* CreateSoftwareRenderer(SDL_Surface* surface) => SDL_CreateSoftwareRenderer(surface);

    public static SDL_Texture* CreateTexture(SDL_Renderer* renderer, SDL_PixelFormat format, SDL_TextureAccess access, int w, int h) => SDL_CreateTexture(renderer, format, access, w, h);

    public static SDL_Texture* CreateTextureFromSurface(SDL_Renderer* renderer, SDL_Surface* surface) => SDL_CreateTextureFromSurface(renderer, surface);

    public static SDL_Texture* CreateTextureWithProperties(SDL_Renderer* renderer, SDL_PropertiesID props) => SDL_CreateTextureWithProperties(renderer, props);

    public static bool CreateWindowAndRenderer(string title, int width, int height, SDL_WindowFlags windowFlags, SDL_Window** window, SDL_Renderer** renderer) =>
        SDL_CreateWindowAndRenderer(title, width, height, windowFlags, window, renderer);

    public static void DestroyRenderer(SDL_Renderer* renderer) => SDL_DestroyRenderer(renderer);

    public static void DestroyTexture(SDL_Texture* texture) => SDL_DestroyTexture(texture);

    public static bool FlushRenderer(SDL_Renderer* renderer) => SDL_FlushRenderer(renderer);

    public static bool GetCurrentRenderOutputSize(SDL_Renderer* renderer, int* w, int* h) => SDL_GetCurrentRenderOutputSize(renderer, w, h);

    public static int GetNumRenderDrivers() => SDL_GetNumRenderDrivers();

    public static bool GetRenderClipRect(SDL_Renderer* renderer, SDL_Rect* rect) => SDL_GetRenderClipRect(renderer, rect);

    public static void GetRenderColorScale(SDL_Renderer* renderer, float* scale) => SDL_GetRenderColorScale(renderer, scale);

    public static bool GetRenderDrawBlendMode(SDL_Renderer* renderer, SDL_BlendMode* blendMode)
        => SDL_GetRenderDrawBlendMode(renderer, blendMode);

    public static bool GetRenderDrawColor(SDL_Renderer* renderer, byte* r, byte* g, byte* b, byte* a)
        => SDL_GetRenderDrawColor(renderer, r, g, b, a);

    public static bool GetRenderDrawColorFloat(SDL_Renderer* renderer, float* r, float* g, float* b, float* a)
        => SDL_GetRenderDrawColorFloat(renderer, r, g, b, a);

    public static string GetRenderDriver(int index) => SDL_GetRenderDriver(index) ?? string.Empty;

    public static SDL_Renderer* GetRenderer(SDL_Window* window) => SDL_GetRenderer(window);

    public static SDL_Renderer* GetRendererFromTexture(SDL_Texture* texture) => SDL_GetRendererFromTexture(texture);

    public static string GetRendererName(SDL_Renderer* renderer) => SDL_GetRendererName(renderer) ?? string.Empty;

    public static SDL_PropertiesID GetRendererProperties(SDL_Renderer* renderer) => SDL_GetRendererProperties(renderer);

    public static bool GetRenderLogicalPresentation(SDL_Renderer* renderer, int* w, int* h, SDL_RendererLogicalPresentation* mode) => SDL_GetRenderLogicalPresentation(renderer, w, h, mode);

    public static bool GetRenderLogicalPresentationRect(SDL_Renderer* renderer, SDL_FRect* rect) => SDL_GetRenderLogicalPresentationRect(renderer, rect);

    public static IntPtr GetRenderMetalCommandEncoder(SDL_Renderer* renderer) => SDL_GetRenderMetalCommandEncoder(renderer);

    public static IntPtr GetRenderMetalLayer(SDL_Renderer* renderer) => SDL_GetRenderMetalLayer(renderer);

    public static bool GetRenderOutputSize(SDL_Renderer* renderer, int* w, int* h) => SDL_GetRenderOutputSize(renderer, w, h);

    public static void GetRenderSafeArea(SDL_Renderer* renderer, SDL_Rect* rect) => SDL_GetRenderSafeArea(renderer, rect);

    public static bool GetRenderScale(SDL_Renderer* renderer, float* scaleX, float* scaleY) => SDL_GetRenderScale(renderer, scaleX, scaleY);

    public static SDL_Texture* GetRenderTarget(SDL_Renderer* renderer) => SDL_GetRenderTarget(renderer);

    public static void GetRenderViewport(SDL_Renderer* renderer, SDL_Rect* rect) => SDL_GetRenderViewport(renderer, rect);

    public static bool GetRenderVSync(SDL_Renderer* renderer, int* vsync) => SDL_GetRenderVSync(renderer, vsync);

    public static SDL_Window* GetRenderWindow(SDL_Renderer* renderer) => SDL_GetRenderWindow(renderer);

    public static bool GetTextureAlphaMod(SDL_Texture* texture, byte* alpha) => SDL_GetTextureAlphaMod(texture, alpha);

    public static bool GetTextureAlphaModFloat(SDL_Texture* texture, float* alpha) => SDL_GetTextureAlphaModFloat(texture, alpha);

    public static bool GetTextureBlendMode(SDL_Texture* texture, SDL_BlendMode* blendMode) => SDL_GetTextureBlendMode(texture, blendMode);

    public static bool GetTextureColorMod(SDL_Texture* texture, byte* r, byte* g, byte* b) => SDL_GetTextureColorMod(texture, r, g, b);

    public static bool GetTextureColorModFloat(SDL_Texture* texture, float* r, float* g, float* b) => SDL_GetTextureColorModFloat(texture, r, g, b);

    public static SDL_PropertiesID GetTextureProperties(SDL_Texture* texture) => SDL_GetTextureProperties(texture);

    public static bool GetTextureScaleMode(SDL_Texture* texture, SDL_ScaleMode* mode) => SDL_GetTextureScaleMode(texture, mode);

    public static bool GetTextureSize(SDL_Texture* texture, float* w, float* h) => SDL_GetTextureSize(texture, w, h);

    public static bool LockTexture(SDL_Texture* texture, SDL_Rect* rect, nint* pixels, int* pitch) => SDL_LockTexture(texture, rect, pixels, pitch);

    public static bool LockTextureToSurface(SDL_Texture* texture, SDL_Rect* rect, SDL_Surface** surface) => SDL_LockTextureToSurface(texture, rect, surface);

    public static void RenderClear(SDL_Renderer* renderer) => SDL_RenderClear(renderer);

    public static void RenderPresent(SDL_Renderer* renderer) => SDL_RenderPresent(renderer);

    public static void UnlockTexture(SDL_Texture* texture) => SDL_UnlockTexture(texture);

    public static void UpdateTexture(SDL_Texture* texture, SDL_Rect* rect, nint pixels, int pitch) => SDL_UpdateTexture(texture, rect, pixels, pitch);

    public static void UpdateNvTexture(SDL_Texture* texture, SDL_Rect* rect, byte* yplane, int ypitch, byte* uVplane, int uVpitch) => SDL_UpdateNVTexture(texture, rect, yplane, ypitch, uVplane, uVpitch);

    public static void UpdateYuvTexture(SDL_Texture* texture, SDL_Rect* rect, byte* yplane, int ypitch, byte* uplane, int upitch, byte* vplane, int vpitch) => SDL_UpdateYUVTexture(texture, rect, yplane, ypitch, uplane, upitch, vplane, vpitch);
}