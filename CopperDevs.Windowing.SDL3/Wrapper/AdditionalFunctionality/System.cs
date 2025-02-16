using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void GetAndroidActivity() => SDL_GetAndroidActivity();
    public static void GetAndroidCachePath() => SDL_GetAndroidCachePath();
    public static void GetAndroidExternalStoragePath() => SDL_GetAndroidExternalStoragePath();
    public static void GetAndroidExternalStorageState() => SDL_GetAndroidExternalStorageState();
    public static void GetAndroidInternalStoragePath() => SDL_GetAndroidInternalStoragePath();
    public static void GetAndroidJNIEnv() => SDL_GetAndroidJNIEnv();
    public static void GetAndroidSDKVersion() => SDL_GetAndroidSDKVersion();
    public static void GetDirect3D9AdapterIndex() => SDL_GetDirect3D9AdapterIndex();
    public static void GetDXGIOutputInfo() => SDL_GetDXGIOutputInfo();
    public static void GetGDKDefaultUser() => SDL_GetGDKDefaultUser();
    public static void GetGDKTaskQueue() => SDL_GetGDKTaskQueue();
    public static void GetSandbox() => SDL_GetSandbox();
    public static void IsChromebook() => SDL_IsChromebook();
    public static void IsDeXMode() => SDL_IsDeXMode();
    public static void IsTablet() => SDL_IsTablet();
    public static void IsTV() => SDL_IsTV();
    public static void OnApplicationDidChangeStatusBarOrientation() => SDL_OnApplicationDidChangeStatusBarOrientation();
    public static void OnApplicationDidEnterBackground() => SDL_OnApplicationDidEnterBackground();
    public static void OnApplicationDidEnterForeground() => SDL_OnApplicationDidEnterForeground();
    public static void OnApplicationDidReceiveMemoryWarning() => SDL_OnApplicationDidReceiveMemoryWarning();
    public static void OnApplicationWillEnterBackground() => SDL_OnApplicationWillEnterBackground();
    public static void OnApplicationWillEnterForeground() => SDL_OnApplicationWillEnterForeground();
    public static void OnApplicationWillTerminate() => SDL_OnApplicationWillTerminate();
    public static void RequestAndroidPermission() => SDL_RequestAndroidPermission();
    public static void SendAndroidBackButton() => SDL_SendAndroidBackButton();
    public static void SendAndroidMessage() => SDL_SendAndroidMessage();
    public static void SetiOSAnimationCallback() => SDL_SetiOSAnimationCallback();
    public static void SetiOSEventPump() => SDL_SetiOSEventPump();
    public static void SetLinuxThreadPriority() => SDL_SetLinuxThreadPriority();
    public static void SetLinuxThreadPriorityAndPolicy() => SDL_SetLinuxThreadPriorityAndPolicy();
    public static void SetWindowsMessageHook() => SDL_SetWindowsMessageHook();
    public static void SetX11EventHook() => SDL_SetX11EventHook();
    public static void ShowAndroidToast() => SDL_ShowAndroidToast();
}