using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDLAPI
{
    public static SDL_Surface* AcquireCameraFrame(SDL_Camera* camera, ulong* timestampNS) => SDL_AcquireCameraFrame(camera, timestampNS);
    public static void CloseCamera(SDL_Camera* camera) => SDL_CloseCamera(camera);
    public static string GetCameraDriver(int index) => SDL_GetCameraDriver(index) ?? string.Empty;
    public static bool GetCameraFormat(SDL_Camera* camera, SDL_CameraSpec* spec) => SDL_GetCameraFormat(camera, spec);
    public static SDL_CameraID GetCameraID(SDL_Camera* camera) => SDL_GetCameraID(camera);
    public static string GetCameraName(SDL_CameraID instanceId) => SDL_GetCameraName(instanceId) ?? string.Empty;
    public static int GetCameraPermissionState(SDL_Camera* camera) => SDL_GetCameraPermissionState(camera);
    public static SDL_CameraPosition GetCameraPosition(SDL_CameraID instanceId) => SDL_GetCameraPosition(instanceId);
    public static SDL_PropertiesID GetCameraProperties(SDL_Camera* camera) => SDL_GetCameraProperties(camera);
    public static SDL_CameraID[] GetCameras() => SDLUtil.ToArray(SDL_GetCameras());
    public static SDL_CameraSpec[] GetCameraSupportedFormats(SDL_CameraID devid) => SDLUtil.ToArray(SDL_GetCameraSupportedFormats(devid));
    public static string GetCurrentCameraDriver() => SDL_GetCurrentCameraDriver() ?? string.Empty;
    public static int GetNumCameraDrivers() => SDL_GetNumCameraDrivers();

    public static SDL_Camera* OpenCamera(SDL_CameraID instanceId, SDL_CameraSpec* spec) => SDL_OpenCamera(instanceId, spec);

    public static void ReleaseCameraFrame(SDL_Camera* camera, SDL_Surface* frame) => SDL_ReleaseCameraFrame(camera, frame);
}