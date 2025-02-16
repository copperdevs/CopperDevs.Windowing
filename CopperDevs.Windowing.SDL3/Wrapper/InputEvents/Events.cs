using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void AddEventWatch() => SDL_AddEventWatch();
    public static void EventEnabled() => SDL_EventEnabled();
    public static void FilterEvents() => SDL_FilterEvents();
    public static void FlushEvent() => SDL_FlushEvent();
    public static void FlushEvents() => SDL_FlushEvents();
    public static void GetEventFilter() => SDL_GetEventFilter();
    public static void GetWindowFromEvent() => SDL_GetWindowFromEvent();
    public static void HasEvent() => SDL_HasEvent();
    public static void HasEvents() => SDL_HasEvents();
    public static void PeepEvents() => SDL_PeepEvents();
    public static void PollEvent() => SDL_PollEvent();
    public static void PumpEvents() => SDL_PumpEvents();
    public static void PushEvent() => SDL_PushEvent();
    public static void RegisterEvents() => SDL_RegisterEvents();
    public static void RemoveEventWatch() => SDL_RemoveEventWatch();
    public static void SetEventEnabled() => SDL_SetEventEnabled();
    public static void SetEventFilter() => SDL_SetEventFilter();
    public static void WaitEvent() => SDL_WaitEvent();
    public static void WaitEventTimeout() => SDL_WaitEventTimeout();
}