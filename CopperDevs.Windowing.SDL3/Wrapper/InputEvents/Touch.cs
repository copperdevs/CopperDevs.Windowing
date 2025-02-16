using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void GetTouchDeviceName() => SDL_GetTouchDeviceName();
    public static void GetTouchDevices() => SDL_GetTouchDevices();
    public static void GetTouchDeviceType() => SDL_GetTouchDeviceType();
    public static void GetTouchFingers() => SDL_GetTouchFingers();
}