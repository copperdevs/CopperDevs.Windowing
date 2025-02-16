using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void CleanupTLS() => SDL_CleanupTLS();
    public static void CreateThread() => SDL_CreateThreadRuntime();
    public static void CreateThreadWithProperties() => SDL_CreateThreadWithPropertiesRuntime();
    public static void DetachThread() => SDL_DetachThread();
    public static void GetCurrentThreadID() => SDL_GetCurrentThreadID();
    public static void GetThreadID() => SDL_GetThreadID();
    public static void GetThreadName() => SDL_GetThreadName();
    public static void GetThreadState() => SDL_GetThreadState();
    public static void GetTLS() => SDL_GetTLS();
    public static void SetCurrentThreadPriority() => SDL_SetCurrentThreadPriority();
    public static void SetTLS() => SDL_SetTLS();
    public static void WaitThread() => SDL_WaitThread();
}