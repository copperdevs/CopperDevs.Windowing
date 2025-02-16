using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void AcquireCameraFrame() => SDL_AcquireCameraFrame();
    public static void CloseCamera() => SDL_CloseCamera();
    public static void GetCameraDriver() => SDL_GetCameraDriver();
    public static void GetCameraFormat() => SDL_GetCameraFormat();
    public static void GetCameraID() => SDL_GetCameraID();
    public static void GetCameraName() => SDL_GetCameraName();
    public static void GetCameraPermissionState() => SDL_GetCameraPermissionState();
    public static void GetCameraPosition() => SDL_GetCameraPosition();
    public static void GetCameraProperties() => SDL_GetCameraProperties();
    public static void GetCameras() => SDL_GetCameras();
    public static void GetCameraSupportedFormats() => SDL_GetCameraSupportedFormats();
    public static void GetCurrentCameraDriver() => SDL_GetCurrentCameraDriver();
    public static void GetNumCameraDrivers() => SDL_GetNumCameraDrivers();
    public static void OpenCamera() => SDL_OpenCamera();
    public static void ReleaseCameraFrame() => SDL_ReleaseCameraFrame();
}