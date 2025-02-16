using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void AddAtomicInt() => SDL_AddAtomicInt();
    public static void CompareAndSwapAtomicInt() => SDL_CompareAndSwapAtomicInt();
    public static void CompareAndSwapAtomicPointer() => SDL_CompareAndSwapAtomicPointer();
    public static void CompareAndSwapAtomicU32() => SDL_CompareAndSwapAtomicU32();
    public static void GetAtomicInt() => SDL_GetAtomicInt();
    public static void GetAtomicPointer() => SDL_GetAtomicPointer();
    public static void GetAtomicU32() => SDL_GetAtomicU32();
    public static void LockSpinlock() => SDL_LockSpinlock();
    public static void MemoryBarrierAcquireFunction() => SDL_MemoryBarrierAcquireFunction();
    public static void MemoryBarrierReleaseFunction() => SDL_MemoryBarrierReleaseFunction();
    public static void SetAtomicInt() => SDL_SetAtomicInt();
    public static void SetAtomicPointer() => SDL_SetAtomicPointer();
    public static void SetAtomicU32() => SDL_SetAtomicU32();
    public static void TryLockSpinlock() => SDL_TryLockSpinlock();
    public static void UnlockSpinlock() => SDL_UnlockSpinlock();
}