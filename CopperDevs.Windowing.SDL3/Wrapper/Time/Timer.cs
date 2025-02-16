using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void AddTimer() => SDL_AddTimer();
    public static void AddTimerNS() => SDL_AddTimerNS();
    public static void Delay() => SDL_Delay();
    public static void DelayNS() => SDL_DelayNS();
    public static void DelayPrecise() => SDL_DelayPrecise();
    public static void GetPerformanceCounter() => SDL_GetPerformanceCounter();
    public static void GetPerformanceFrequency() => SDL_GetPerformanceFrequency();
    public static void GetTicks() => SDL_GetTicks();
    public static void GetTicksNS() => SDL_GetTicksNS();
    public static void RemoveTimer() => SDL_RemoveTimer();
}