using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void CreateProcess() => SDL_CreateProcess();
    public static void CreateProcessWithProperties() => SDL_CreateProcessWithProperties();
    public static void DestroyProcess() => SDL_DestroyProcess();
    public static void GetProcessInput() => SDL_GetProcessInput();
    public static void GetProcessOutput() => SDL_GetProcessOutput();
    public static void GetProcessProperties() => SDL_GetProcessProperties();
    public static void KillProcess() => SDL_KillProcess();
    public static void ReadProcess() => SDL_ReadProcess();
    public static void WaitProcess() => SDL_WaitProcess();
}