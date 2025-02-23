using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

// TODO: wrap this so it doesn't have to be unsafe perchance
public static unsafe partial class SDLAPI
{
    public static bool AddEventWatch(delegate* unmanaged[Cdecl]<IntPtr, SDL_Event*, SDLBool> watcher, IntPtr userData) => SDL_AddEventWatch(watcher, userData);
    public static bool EventEnabled(EventType type) => SDL_EventEnabled((uint)type);
    public static void FilterEvents(delegate* unmanaged[Cdecl]<IntPtr, SDL_Event*, SDLBool> filter, IntPtr userData) => SDL_FilterEvents(filter, userData);
    public static void FlushEvent(EventType type) => SDL_FlushEvent((uint)type);
    public static void FlushEvents(EventType minType, EventType maxType) => SDL_FlushEvents((uint)minType, (uint)maxType);
    public static bool GetEventFilter(delegate* unmanaged[Cdecl]<IntPtr, SDL_Event*, SDLBool>* filter, IntPtr* userData) => SDL_GetEventFilter(filter, userData);
    public static SDL_Window* GetWindowFromEvent(SDL_Event* @event) => SDL_GetWindowFromEvent(@event);
    public static bool HasEvent(EventType type) => SDL_HasEvent((SDL_EventType)type);
    public static bool HasEvents(EventType minType, EventType maxType) => SDL_HasEvents((uint)minType, (uint)maxType);
    public static int PeepEvents(SDL_Event[] events, SDL_EventAction action, SDL_EventType minType, SDL_EventType maxType) => SDL_PeepEvents(events, action, minType, maxType);
    public static bool PollEvent(SDL_Event* @event) => SDL_PollEvent(@event);
    public static void PumpEvents() => SDL_PumpEvents();
    public static bool PushEvent(SDL_Event* @event) => SDL_PushEvent(@event);
    public static uint RegisterEvents(int numEvents) => SDL_RegisterEvents(numEvents);
    public static void RemoveEventWatch(delegate* unmanaged[Cdecl]<IntPtr, SDL_Event*, SDLBool> watcher, IntPtr userData) => SDL_RemoveEventWatch(watcher, userData);
    public static void SetEventEnabled(EventType type, bool enabled) => SDL_SetEventEnabled((SDL_EventType)type, enabled);
    public static void SetEventFilter(delegate* unmanaged[Cdecl]<IntPtr, SDL_Event*, SDLBool> watcher, IntPtr userData) => SDL_SetEventFilter(watcher, userData);
    public static bool WaitEvent(SDL_Event* @event) => SDL_WaitEvent(@event);
    public static bool WaitEventTimeout(SDL_Event* @event, int timeout) => SDL_WaitEventTimeout(@event, timeout);
}