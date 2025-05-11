#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDLAPI
{
    public static SDL_Window* CreatePopupWindow(SDL_Window* parent, int offsetX, int offsetY, int w, int h, SDL_WindowFlags flags) => SDL_CreatePopupWindow(parent, offsetX, offsetY, w, h, flags);
    public static SDL_Window* CreateWindow(byte* title, int w, int h, SDL_WindowFlags flags) => SDL_CreateWindow(title, w, h, flags);
    public static SDL_Window* CreateWindow(string title, int w, int h, SDL_WindowFlags flags) => SDL_CreateWindow(title, w, h, flags);
    public static SDL_Window* CreateWindowWithProperties(SDL_PropertiesID props) => SDL_CreateWindowWithProperties(props);
    public static void DestroyWindow(SDL_Window* window) => SDL_DestroyWindow(window);
    public static bool DestroyWindowSurface(SDL_Window* window) => SDL_DestroyWindowSurface(window);
    public static bool DisableScreenSaver() => SDL_DisableScreenSaver();
    public static IntPtr EGL_GetCurrentConfig() => SDL_EGL_GetCurrentConfig();
    public static IntPtr EGL_GetCurrentDisplay() => SDL_EGL_GetCurrentDisplay();
    public static IntPtr EGL_GetProcAddress(byte* proc) => SDL_EGL_GetProcAddress(proc);
    public static IntPtr EGL_GetProcAddress(string proc) => SDL_EGL_GetProcAddress(proc);

    public static IntPtr EGL_GetWindowSurface(SDL_Window* window) => SDL_EGL_GetWindowSurface(window);

    public static void EGL_SetAttributeCallbacks(delegate*unmanaged[Cdecl]<IntPtr, IntPtr*> platformAttribCallback, delegate*unmanaged[Cdecl]<IntPtr, IntPtr, IntPtr, int*> surfaceAttribCallback,
        delegate*unmanaged[Cdecl]<IntPtr, IntPtr, IntPtr, int*> contextAttribCallback, IntPtr userdata) =>
        SDL_EGL_SetAttributeCallbacks(platformAttribCallback, surfaceAttribCallback, contextAttribCallback, userdata);

    public static bool EnableScreenSaver() => SDL_EnableScreenSaver();
    public static bool FlashWindow(SDL_Window* window, SDL_FlashOperation operation) => SDL_FlashWindow(window, operation);

    public static bool GetClosestFullscreenDisplayMode(SDL_DisplayID displayId, int w, int h, float refreshRate, bool includeHighDensityModes, SDL_DisplayMode* closest) =>
        SDL_GetClosestFullscreenDisplayMode(displayId, w, h, refreshRate, includeHighDensityModes, closest);

    public static SDL_DisplayMode* GetCurrentDisplayMode(SDL_DisplayID displayId) => SDL_GetCurrentDisplayMode(displayId);
    public static SDL_DisplayOrientation GetCurrentDisplayOrientation(SDL_DisplayID displayId) => SDL_GetCurrentDisplayOrientation(displayId);
    public static string GetCurrentVideoDriver() => SDL_GetCurrentVideoDriver() ?? string.Empty;
    public static SDL_DisplayMode* GetDesktopDisplayMode(SDL_DisplayID displayId) => SDL_GetDesktopDisplayMode(displayId);
    public static bool GetDisplayBounds(SDL_DisplayID displayId, SDL_Rect* rect) => SDL_GetDisplayBounds(displayId, rect);
    public static float GetDisplayContentScale(SDL_DisplayID displayId) => SDL_GetDisplayContentScale(displayId);
    public static SDL_DisplayID GetDisplayForPoint(SDL_Point* point) => SDL_GetDisplayForPoint(point);
    public static SDL_DisplayID GetDisplayForRect(SDL_Rect* rect) => SDL_GetDisplayForRect(rect);
    public static SDL_DisplayID GetDisplayForWindow(SDL_Window* window) => SDL_GetDisplayForWindow(window);
    public static string GetDisplayName(SDL_DisplayID displayId) => SDL_GetDisplayName(displayId) ?? string.Empty;
    public static SDL_PropertiesID GetDisplayProperties(SDL_DisplayID displayId) => SDL_GetDisplayProperties(displayId);
    public static SDL_DisplayID* GetDisplays(int* count) => SDL_GetDisplays(count);
    public static SDL_DisplayID[] GetDisplays() => SDLUtil.ToArray(SDL_GetDisplays());
    public static bool GetDisplayUsableBounds(SDL_DisplayID displayId, SDL_Rect* rect) => SDL_GetDisplayUsableBounds(displayId, rect);
    public static SDL_DisplayMode** GetFullscreenDisplayModes(SDL_DisplayID displayId, int* count) => SDL_GetFullscreenDisplayModes(displayId, count);
    public static SDL_DisplayMode[] GetFullscreenDisplayModes(SDL_DisplayID displayId) => SDLUtil.ToArray(SDL_GetFullscreenDisplayModes(displayId));
    public static SDL_Window* GetGrabbedWindow() => SDL_GetGrabbedWindow();
    public static SDL_DisplayOrientation GetNaturalDisplayOrientation(SDL_DisplayID displayId) => SDL_GetNaturalDisplayOrientation(displayId);
    public static int GetNumVideoDrivers() => SDL_GetNumVideoDrivers();
    public static SDL_DisplayID GetPrimaryDisplay() => SDL_GetPrimaryDisplay();
    public static string GetVideoDriver(int index) => SDL_GetVideoDriver(index) ?? string.Empty;
    public static bool GetWindowAspectRatio(SDL_Window* window, float* minAspect, float* maxAspect) => SDL_GetWindowAspectRatio(window, minAspect, maxAspect);
    public static bool GetWindowBordersSize(SDL_Window* window, int* top, int* left, int* bottom, int* right) => SDL_GetWindowBordersSize(window, top, left, bottom, right);
    public static float GetWindowDisplayScale(SDL_Window* window) => SDL_GetWindowDisplayScale(window);
    public static SDL_WindowFlags GetWindowFlags(SDL_Window* window) => SDL_GetWindowFlags(window);
    public static SDL_Window* GetWindowFromId(SDL_WindowID id) => SDL_GetWindowFromID(id);
    public static SDL_DisplayMode* GetWindowFullscreenMode(SDL_Window* window) => SDL_GetWindowFullscreenMode(window);
    public static IntPtr GetWindowIccProfile(SDL_Window* window, UIntPtr* size) => SDL_GetWindowICCProfile(window, size);
    public static SDL_WindowID GetWindowId(SDL_Window* window) => SDL_GetWindowID(window);
    public static bool GetWindowKeyboardGrab(SDL_Window* window) => SDL_GetWindowKeyboardGrab(window);
    public static bool GetWindowMaximumSize(SDL_Window* window, int* w, int* h) => SDL_GetWindowMaximumSize(window, w, h);
    public static bool GetWindowMinimumSize(SDL_Window* window, int* w, int* h) => SDL_GetWindowMinimumSize(window, w, h);
    public static float GetWindowOpacity(SDL_Window* window) => SDL_GetWindowOpacity(window);
    public static SDL_Window* GetWindowParent(SDL_Window* window) => SDL_GetWindowParent(window);
    public static float GetWindowPixelDensity(SDL_Window* window) => SDL_GetWindowPixelDensity(window);
    public static SDL_PixelFormat GetWindowPixelFormat(SDL_Window* window) => SDL_GetWindowPixelFormat(window);
    public static bool GetWindowPosition(SDL_Window* window, int* x, int* y) => SDL_GetWindowPosition(window, x, y);
    public static SDL_PropertiesID GetWindowProperties(SDL_Window* window) => SDL_GetWindowProperties(window);
    public static SDL_Window** GetWindows(int* count) => SDL_GetWindows(count);
    public static SDL_Window[] GetWindows() => SDLUtil.ToArray(SDL_GetWindows());
    public static bool GetWindowSafeArea(SDL_Window* window, SDL_Rect* rect) => SDL_GetWindowSafeArea(window, rect);
    public static bool GetWindowSize(SDL_Window* window, int* w, int* h) => SDL_GetWindowSize(window, w, h);
    public static bool GetWindowSizeInPixels(SDL_Window* window, int* w, int* h) => SDL_GetWindowSizeInPixels(window, w, h);
    public static SDL_Surface* GetWindowSurface(SDL_Window* window) => SDL_GetWindowSurface(window);
    public static bool GetWindowSurfaceVSync(SDL_Window* window, int* vsync) => SDL_GetWindowSurfaceVSync(window, vsync);
    public static string GetWindowTitle(SDL_Window* window) => SDL_GetWindowTitle(window) ?? string.Empty;
    public static SDL_GLContextState* GL_CreateContext(SDL_Window* window) => SDL_GL_CreateContext(window);
    public static bool GL_DestroyContext(SDL_GLContextState* context) => SDL_GL_DestroyContext(context);
    public static bool GL_ExtensionSupported(byte* extension) => SDL_GL_ExtensionSupported(extension);
    public static bool GL_ExtensionSupported(string extension) => SDL_GL_ExtensionSupported(extension);
    public static bool GL_GetAttribute(SDL_GLAttr attr, int* value) => SDL_GL_GetAttribute(attr, value);
    public static SDL_GLContextState* GL_GetCurrentContext() => SDL_GL_GetCurrentContext();
    public static SDL_Window* GL_GetCurrentWindow() => SDL_GL_GetCurrentWindow();
    public static IntPtr GL_GetProcAddress(byte* proc) => SDL_GL_GetProcAddress(proc);
    public static IntPtr GL_GetProcAddress(string proc) => SDL_GL_GetProcAddress(proc);
    public static bool GL_GetSwapInterval(int* interval) => SDL_GL_GetSwapInterval(interval);
    public static bool GL_LoadLibrary(byte* path) => SDL_GL_LoadLibrary(path);
    public static bool GL_LoadLibrary(string path) => SDL_GL_LoadLibrary(path);
    public static bool GL_MakeCurrent(SDL_Window* window, SDL_GLContextState* context) => SDL_GL_MakeCurrent(window, context);
    public static void GL_ResetAttributes() => SDL_GL_ResetAttributes();
    public static bool GL_SetAttribute(SDL_GLAttr attr, int value) => SDL_GL_SetAttribute(attr, value);
    public static bool GL_SetSwapInterval(int interval) => SDL_GL_SetSwapInterval(interval);
    public static bool GL_SwapWindow(SDL_Window* window) => SDL_GL_SwapWindow(window);
    public static void GL_UnloadLibrary() => SDL_GL_UnloadLibrary();
    public static bool HideWindow(SDL_Window* window) => SDL_HideWindow(window);
    public static bool MaximizeWindow(SDL_Window* window) => SDL_MaximizeWindow(window);
    public static bool MinimizeWindow(SDL_Window* window) => SDL_MinimizeWindow(window);
    public static bool RaiseWindow(SDL_Window* window) => SDL_RaiseWindow(window);
    public static bool RestoreWindow(SDL_Window* window) => SDL_RestoreWindow(window);
    public static bool ScreenSaverEnabled() => SDL_ScreenSaverEnabled();
    public static bool SetWindowAlwaysOnTop(SDL_Window* window, bool onTop) => SDL_SetWindowAlwaysOnTop(window, onTop);
    public static bool SetWindowAspectRatio(SDL_Window* window, float minAspect, float maxAspect) => SDL_SetWindowAspectRatio(window, minAspect, maxAspect);
    public static bool SetWindowBordered(SDL_Window* window, bool bordered) => SDL_SetWindowBordered(window, bordered);
    public static bool SetWindowFocusable(SDL_Window* window, bool focusable) => SDL_SetWindowFocusable(window, focusable);
    public static bool SetWindowFullscreen(SDL_Window* window, bool fullscreen) => SDL_SetWindowFullscreen(window, fullscreen);

    public static bool SetWindowFullscreenMode(SDL_Window* window, SDL_DisplayMode* mode) => SDL_SetWindowFullscreenMode(window, mode);

    public static bool SetWindowHitTest(SDL_Window* window, delegate*unmanaged[Cdecl]<SDL_Window*, SDL_Point*, IntPtr, SDL_HitTestResult> callback, IntPtr callback_data) => SDL_SetWindowHitTest(window, callback, callback_data);
    public static bool SetWindowIcon(SDL_Window* window, SDL_Surface* icon) => SDL_SetWindowIcon(window, icon);
    public static bool SetWindowKeyboardGrab(SDL_Window* window, bool grabbed) => SDL_SetWindowKeyboardGrab(window, grabbed);
    public static bool SetWindowMaximumSize(SDL_Window* window, int maxW, int maxH) => SDL_SetWindowMaximumSize(window, maxW, maxH);
    public static bool SetWindowMinimumSize(SDL_Window* window, int minW, int minH) => SDL_SetWindowMinimumSize(window, minW, minH);
    public static bool SetWindowModal(SDL_Window* window, bool modal) => SDL_SetWindowModal(window, modal);
    public static bool SetWindowOpacity(SDL_Window* window, float opacity) => SDL_SetWindowOpacity(window, opacity);
    public static bool SetWindowParent(SDL_Window* window, SDL_Window* parent) => SDL_SetWindowParent(window, parent);
    public static bool SetWindowPosition(SDL_Window* window, int x, int y) => SDL_SetWindowPosition(window, x, y);
    public static bool SetWindowResizable(SDL_Window* window, bool resizable) => SDL_SetWindowResizable(window, resizable);
    public static bool SetWindowShape(SDL_Window* window, SDL_Surface* shape) => SDL_SetWindowShape(window, shape);
    public static bool SetWindowSize(SDL_Window* window, int w, int h) => SDL_SetWindowSize(window, w, h);
    public static bool SetWindowSurfaceVSync(SDL_Window* window, int vsync) => SDL_SetWindowSurfaceVSync(window, vsync);
    public static bool SetWindowTitle(SDL_Window* window, byte* title) => SDL_SetWindowTitle(window, title);
    public static bool SetWindowTitle(SDL_Window* window, string title) => SDL_SetWindowTitle(window, title);
    public static bool ShowWindow(SDL_Window* window) => SDL_ShowWindow(window);
    public static bool ShowWindowSystemMenu(SDL_Window* window, int x, int y) => SDL_ShowWindowSystemMenu(window, x, y);
    public static bool SyncWindow(SDL_Window* window) => SDL_SyncWindow(window);
    public static bool UpdateWindowSurface(SDL_Window* window) => SDL_UpdateWindowSurface(window);
    public static bool UpdateWindowSurfaceRects(SDL_Window* window, SDL_Rect* rects, int numrects) => SDL_UpdateWindowSurfaceRects(window, rects, numrects);
    public static bool WindowHasSurface(SDL_Window* window) => SDL_WindowHasSurface(window);
}