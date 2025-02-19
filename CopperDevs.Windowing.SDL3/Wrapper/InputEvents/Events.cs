using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    // TODO: wrap this so it doesn't have to be unsafe
    public static bool AddEventWatch(delegate* unmanaged[Cdecl]<IntPtr, SDL_Event*, SDLBool> watcher, IntPtr userData) => SDL_AddEventWatch(watcher, userData);
    public static bool EventEnabled(EventType type) => SDL_EventEnabled((uint)type);
    public static void FilterEvents(delegate* unmanaged[Cdecl]<IntPtr, SDL_Event*, SDLBool> filter, IntPtr userData) => SDL_FilterEvents(filter, userData);
    public static void FlushEvent(EventType type) => SDL_FlushEvent((uint)type);
    public static void FlushEvents(EventType minType, EventType maxType) => SDL_FlushEvents((uint)minType, (uint)maxType);
    public static bool GetEventFilter(delegate* unmanaged[Cdecl]<IntPtr, SDL_Event*, SDLBool>* filter, IntPtr* userData) => SDL_GetEventFilter(filter, userData);
    public static SDL_Window* GetWindowFromEvent(SDL_Event* @event) => SDL_GetWindowFromEvent(@event);
    public static bool HasEvent(EventType type) => SDL_HasEvent((SDL_EventType)type);
    public static bool HasEvents(EventType minType, EventType maxType) => SDL_HasEvents((uint)minType, (uint)maxType);
    public static void PeepEvents(SDL_Event[] events, SDL_EventAction action, SDL_EventType minType, SDL_EventType maxType) => SDL_PeepEvents();
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