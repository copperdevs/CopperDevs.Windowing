using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void BroadcastCondition() => SDL_BroadcastCondition();
    public static void CreateCondition() => SDL_CreateCondition();
    public static void CreateMutex() => SDL_CreateMutex();
    public static void CreateRWLock() => SDL_CreateRWLock();
    public static void CreateSemaphore() => SDL_CreateSemaphore();
    public static void DestroyCondition() => SDL_DestroyCondition();
    public static void DestroyMutex() => SDL_DestroyMutex();
    public static void DestroyRWLock() => SDL_DestroyRWLock();
    public static void DestroySemaphore() => SDL_DestroySemaphore();
    public static void GetSemaphoreValue() => SDL_GetSemaphoreValue();
    public static void LockMutex() => SDL_LockMutex();
    public static void LockRWLockForReading() => SDL_LockRWLockForReading();
    public static void LockRWLockForWriting() => SDL_LockRWLockForWriting();
    public static void SetInitialized() => SDL_SetInitialized();
    public static void ShouldInit() => SDL_ShouldInit();
    public static void ShouldQuit() => SDL_ShouldQuit();
    public static void SignalCondition() => SDL_SignalCondition();
    public static void SignalSemaphore() => SDL_SignalSemaphore();
    public static void TryLockMutex() => SDL_TryLockMutex();
    public static void TryLockRWLockForReading() => SDL_TryLockRWLockForReading();
    public static void TryLockRWLockForWriting() => SDL_TryLockRWLockForWriting();
    public static void TryWaitSemaphore() => SDL_TryWaitSemaphore();
    public static void UnlockMutex() => SDL_UnlockMutex();
    public static void UnlockRWLock() => SDL_UnlockRWLock();
    public static void WaitCondition() => SDL_WaitCondition();
    public static void WaitConditionTimeout() => SDL_WaitConditionTimeout();
    public static void WaitSemaphore() => SDL_WaitSemaphore();
    public static void WaitSemaphoreTimeout() => SDL_WaitSemaphoreTimeout();
}