#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDLAPI
{
    public static bool AddVulkanRenderSemaphores(SDL_Renderer* renderer, uint waitStageMask, long waitSemaphore, long signalSemaphore) =>
        SDL_AddVulkanRenderSemaphores(renderer, waitStageMask, waitSemaphore, signalSemaphore);

    public static bool ConvertEventToRenderCoordinates(SDL_Renderer* renderer, SDL_Event* @event) => SDL_ConvertEventToRenderCoordinates(renderer, @event);
    public static SDL_Renderer* CreateRenderer(SDL_Window* window, byte* name) => SDL_CreateRenderer(window, name);
    public static SDL_Renderer* CreateRenderer(SDL_Window* window, string name) => SDL_CreateRenderer(window, name);
    public static SDL_Renderer* CreateRendererWithProperties(SDL_PropertiesID props) => SDL_CreateRendererWithProperties(props);
    public static SDL_Renderer* CreateSoftwareRenderer(SDL_Surface* surface) => SDL_CreateSoftwareRenderer(surface);
    public static SDL_Texture* CreateTexture(SDL_Renderer* renderer, SDL_PixelFormat format, SDL_TextureAccess access, int w, int h) => SDL_CreateTexture(renderer, format, access, w, h);
    public static SDL_Texture* CreateTextureFromSurface(SDL_Renderer* renderer, SDL_Surface* surface) => SDL_CreateTextureFromSurface(renderer, surface);
    public static SDL_Texture* CreateTextureWithProperties(SDL_Renderer* renderer, SDL_PropertiesID props) => SDL_CreateTextureWithProperties(renderer, props);

    public static bool CreateWindowAndRenderer(byte* title, int width, int height, SDL_WindowFlags windowFlags, SDL_Window** window, SDL_Renderer** renderer) =>
        SDL_CreateWindowAndRenderer(title, width, height, windowFlags, window, renderer);

    public static bool CreateWindowAndRenderer(string title, int width, int height, SDL_WindowFlags windowFlags, SDL_Window** window, SDL_Renderer** renderer) =>
        SDL_CreateWindowAndRenderer(title, width, height, windowFlags, window, renderer);

    public static void DestroyRenderer(SDL_Renderer* renderer) => SDL_DestroyRenderer(renderer);
    public static void DestroyTexture(SDL_Texture* texture) => SDL_DestroyTexture(texture);
    public static bool FlushRenderer(SDL_Renderer* renderer) => SDL_FlushRenderer(renderer);
    public static bool GetCurrentRenderOutputSize(SDL_Renderer* renderer, int* w, int* h) => SDL_GetCurrentRenderOutputSize(renderer, w, h);
    public static int GetNumRenderDrivers() => SDL_GetNumRenderDrivers();
    public static bool GetRenderClipRect(SDL_Renderer* renderer, SDL_Rect* rect) => SDL_GetRenderClipRect(renderer, rect);
    public static bool GetRenderColorScale(SDL_Renderer* renderer, float* scale) => SDL_GetRenderColorScale(renderer, scale);
    public static bool GetRenderDrawBlendMode(SDL_Renderer* renderer, SDL_BlendMode* blendMode) => SDL_GetRenderDrawBlendMode(renderer, blendMode);
    public static bool GetRenderDrawColor(SDL_Renderer* renderer, byte* r, byte* g, byte* b, byte* a) => SDL_GetRenderDrawColor(renderer, r, g, b, a);
    public static bool GetRenderDrawColorFloat(SDL_Renderer* renderer, float* r, float* g, float* b, float* a) => SDL_GetRenderDrawColorFloat(renderer, r, g, b, a);
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
    public static bool GetRenderSafeArea(SDL_Renderer* renderer, SDL_Rect* rect) => SDL_GetRenderSafeArea(renderer, rect);
    public static bool GetRenderScale(SDL_Renderer* renderer, float* scaleX, float* scaleY) => SDL_GetRenderScale(renderer, scaleX, scaleY);
    public static SDL_Texture* GetRenderTarget(SDL_Renderer* renderer) => SDL_GetRenderTarget(renderer);
    public static bool GetRenderViewport(SDL_Renderer* renderer, SDL_Rect* rect) => SDL_GetRenderViewport(renderer, rect);
    public static bool GetRenderVSync(SDL_Renderer* renderer, int* vsync) => SDL_GetRenderVSync(renderer, vsync);
    public static SDL_Window* GetRenderWindow(SDL_Renderer* renderer) => SDL_GetRenderWindow(renderer);
    public static bool GetTextureAlphaMod(SDL_Texture* texture, byte* alpha) => SDL_GetTextureAlphaMod(texture, alpha);
    public static bool GetTextureAlphaModFloat(SDL_Texture* texture, float* alpha) => SDL_GetTextureAlphaModFloat(texture, alpha);
    public static bool GetTextureBlendMode(SDL_Texture* texture, SDL_BlendMode* blendMode) => SDL_GetTextureBlendMode(texture, blendMode);
    public static bool GetTextureColorMod(SDL_Texture* texture, byte* r, byte* g, byte* b) => SDL_GetTextureColorMod(texture, r, g, b);
    public static bool GetTextureColorModFloat(SDL_Texture* texture, float* r, float* g, float* b) => SDL_GetTextureColorModFloat(texture, r, g, b);
    public static SDL_PropertiesID GetTextureProperties(SDL_Texture* texture) => SDL_GetTextureProperties(texture);
    public static bool GetTextureScaleMode(SDL_Texture* texture, SDL_ScaleMode* scaleMode) => SDL_GetTextureScaleMode(texture, scaleMode);
    public static bool GetTextureSize(SDL_Texture* texture, float* w, float* h) => SDL_GetTextureSize(texture, w, h);
    public static bool LockTexture(SDL_Texture* texture, SDL_Rect* rect, IntPtr* pixels, int* pitch) => SDL_LockTexture(texture, rect, pixels, pitch);
    public static bool LockTextureToSurface(SDL_Texture* texture, SDL_Rect* rect, SDL_Surface** surface) => SDL_LockTextureToSurface(texture, rect, surface);
    public static bool RenderClear(SDL_Renderer* renderer) => SDL_RenderClear(renderer);
    public static bool RenderClipEnabled(SDL_Renderer* renderer) => SDL_RenderClipEnabled(renderer);

    public static bool RenderCoordinatesFromWindow(SDL_Renderer* renderer, float windowX, float windowY, float* x, float* y) =>
        SDL_RenderCoordinatesFromWindow(renderer, windowX, windowY, x, y);

    public static bool RenderCoordinatesToWindow(SDL_Renderer* renderer, float x, float y, float* windowX, float* windowY) =>
        SDL_RenderCoordinatesToWindow(renderer, x, y, windowX, windowY);

    public static bool RenderDebugText(SDL_Renderer* renderer, float x, float y, byte* str) => SDL_RenderDebugText(renderer, x, y, str);
    public static bool RenderDebugText(SDL_Renderer* renderer, float x, float y, string str) => SDL_RenderDebugText(renderer, x, y, str);
    public static bool RenderDebugTextFormat(SDL_Renderer* renderer, float x, float y, byte* fmt) => SDL_RenderDebugTextFormat(renderer, x, y, fmt, __arglist());
    public static bool RenderFillRect(SDL_Renderer* renderer, SDL_FRect* rect) => SDL_RenderFillRect(renderer, rect);
    public static bool RenderFillRects(SDL_Renderer* renderer, SDL_FRect* rects, int count) => SDL_RenderFillRects(renderer, rects, count);

    public static bool RenderGeometry(SDL_Renderer* renderer, SDL_Texture* texture, SDL_Vertex* vertices, int numVertices, int* indices, int numIndices) =>
        SDL_RenderGeometry(renderer, texture, vertices, numVertices, indices, numIndices);

    public static bool RenderGeometryRaw(SDL_Renderer* renderer, SDL_Texture* texture, float* xy, int xyStride, SDL_FColor* color, int colorStride, float* uv, int uvStride, int numVertices,
        IntPtr indices, int numIndices, int sizeIndices) =>
        SDL_RenderGeometryRaw(renderer, texture, xy, xyStride, color, colorStride, uv, uvStride, numVertices, indices, numIndices, sizeIndices);

    public static bool RenderLine(SDL_Renderer* renderer, float x1, float y1, float x2, float y2) => SDL_RenderLine(renderer, x1, y1, x2, y2);
    public static bool RenderLines(SDL_Renderer* renderer, SDL_FPoint* points, int count) => SDL_RenderLines(renderer, points, count);
    public static bool RenderPoint(SDL_Renderer* renderer, float x, float y) => SDL_RenderPoint(renderer, x, y);
    public static bool RenderPoints(SDL_Renderer* renderer, SDL_FPoint* points, int count) => SDL_RenderPoints(renderer, points, count);
    public static bool RenderPresent(SDL_Renderer* renderer) => SDL_RenderPresent(renderer);
    public static SDL_Surface* RenderReadPixels(SDL_Renderer* renderer, SDL_Rect* rect) => SDL_RenderReadPixels(renderer, rect);
    public static bool RenderRect(SDL_Renderer* renderer, SDL_FRect* rect) => SDL_RenderRect(renderer, rect);
    public static bool RenderRects(SDL_Renderer* renderer, SDL_FRect* rects, int count) => SDL_RenderRects(renderer, rects, count);
    public static bool RenderTexture(SDL_Renderer* renderer, SDL_Texture* texture, SDL_FRect* srcrect, SDL_FRect* dstrect) => SDL_RenderTexture(renderer, texture, srcrect, dstrect);

    public static bool RenderTexture9Grid(SDL_Renderer* renderer, SDL_Texture* texture, SDL_FRect* srcrect, float leftWidth, float rightWidth, float topHeight, float bottomHeight, float scale,
        SDL_FRect* dstrect) => SDL_RenderTexture9Grid(renderer, texture, srcrect, leftWidth, rightWidth, topHeight, bottomHeight, scale, dstrect);

    public static bool RenderTextureAffine(SDL_Renderer* renderer, SDL_Texture* texture, SDL_FRect* srcrect, SDL_FPoint* origin, SDL_FPoint* right, SDL_FPoint* down) =>
        SDL_RenderTextureAffine(renderer, texture, srcrect, origin, right, down);

    public static bool RenderTextureRotated(SDL_Renderer* renderer, SDL_Texture* texture, SDL_FRect* srcrect, SDL_FRect* dstrect, double angle, SDL_FPoint* center, SDL_FlipMode flip) =>
        SDL_RenderTextureRotated(renderer, texture, srcrect, dstrect, angle, center, flip);

    public static bool RenderTextureTiled(SDL_Renderer* renderer, SDL_Texture* texture, SDL_FRect* srcrect, float scale, SDL_FRect* dstrect) =>
        SDL_RenderTextureTiled(renderer, texture, srcrect, scale, dstrect);

    public static bool RenderViewportSet(SDL_Renderer* renderer) => SDL_RenderViewportSet(renderer);
    public static bool SetRenderClipRect(SDL_Renderer* renderer, SDL_Rect* rect) => SDL_SetRenderClipRect(renderer, rect);
    public static bool SetRenderColorScale(SDL_Renderer* renderer, float scale) => SDL_SetRenderColorScale(renderer, scale);
    public static bool SetRenderDrawBlendMode(SDL_Renderer* renderer, SDL_BlendMode blendMode) => SDL_SetRenderDrawBlendMode(renderer, blendMode);
    public static bool SetRenderDrawColor(SDL_Renderer* renderer, byte r, byte g, byte b, byte a) => SDL_SetRenderDrawColor(renderer, r, g, b, a);
    public static bool SetRenderDrawColorFloat(SDL_Renderer* renderer, float r, float g, float b, float a) => SDL_SetRenderDrawColorFloat(renderer, r, g, b, a);
    public static bool SetRenderLogicalPresentation(SDL_Renderer* renderer, int w, int h, SDL_RendererLogicalPresentation mode) => SDL_SetRenderLogicalPresentation(renderer, w, h, mode);
    public static bool SetRenderScale(SDL_Renderer* renderer, float scaleX, float scaleY) => SDL_SetRenderScale(renderer, scaleX, scaleY);
    public static bool SetRenderTarget(SDL_Renderer* renderer, SDL_Texture* texture) => SDL_SetRenderTarget(renderer, texture);
    public static bool SetRenderViewport(SDL_Renderer* renderer, SDL_Rect* rect) => SDL_SetRenderViewport(renderer, rect);
    public static bool SetRenderVSync(SDL_Renderer* renderer, int vsync) => SDL_SetRenderVSync(renderer, vsync);
    public static bool SetTextureAlphaMod(SDL_Texture* texture, byte alpha) => SDL_SetTextureAlphaMod(texture, alpha);
    public static bool SetTextureAlphaModFloat(SDL_Texture* texture, float alpha) => SDL_SetTextureAlphaModFloat(texture, alpha);
    public static bool SetTextureBlendMode(SDL_Texture* texture, SDL_BlendMode blendMode) => SDL_SetTextureBlendMode(texture, blendMode);
    public static bool SetTextureColorMod(SDL_Texture* texture, byte r, byte g, byte b) => SDL_SetTextureColorMod(texture, r, g, b);
    public static bool SetTextureColorModFloat(SDL_Texture* texture, float r, float g, float b) => SDL_SetTextureColorModFloat(texture, r, g, b);
    public static bool SetTextureScaleMode(SDL_Texture* texture, SDL_ScaleMode scaleMode) => SDL_SetTextureScaleMode(texture, scaleMode);
    public static void UnlockTexture(SDL_Texture* texture) => SDL_UnlockTexture(texture);

    public static bool UpdateNvTexture(SDL_Texture* texture, SDL_Rect* rect, byte* yplane, int ypitch, byte* uVplane, int uVpitch) =>
        SDL_UpdateNVTexture(texture, rect, yplane, ypitch, uVplane, uVpitch);

    public static bool UpdateTexture(SDL_Texture* texture, SDL_Rect* rect, IntPtr pixels, int pitch) => SDL_UpdateTexture(texture, rect, pixels, pitch);

    public static bool UpdateYuvTexture(SDL_Texture* texture, SDL_Rect* rect, byte* yplane, int ypitch, byte* uplane, int upitch, byte* vplane, int vpitch) =>
        SDL_UpdateYUVTexture(texture, rect, yplane, ypitch, uplane, upitch, vplane, vpitch);
}