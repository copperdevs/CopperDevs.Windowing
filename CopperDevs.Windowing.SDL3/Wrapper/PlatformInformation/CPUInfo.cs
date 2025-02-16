using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void GetCPUCacheLineSize() => SDL_GetCPUCacheLineSize();
    public static void GetNumLogicalCPUCores() => SDL_GetNumLogicalCPUCores();
    public static void GetSIMDAlignment() => SDL_GetSIMDAlignment();
    public static void GetSystemRAM() => SDL_GetSystemRAM();
    public static void HasAltiVec() => SDL_HasAltiVec();
    public static void HasARMSIMD() => SDL_HasARMSIMD();
    public static void HasAVX() => SDL_HasAVX();
    public static void HasAVX2() => SDL_HasAVX2();
    public static void HasAVX512F() => SDL_HasAVX512F();
    public static void HasLASX() => SDL_HasLASX();
    public static void HasLSX() => SDL_HasLSX();
    public static void HasMMX() => SDL_HasMMX();
    public static void HasNEON() => SDL_HasNEON();
    public static void HasSSE() => SDL_HasSSE();
    public static void HasSSE2() => SDL_HasSSE2();
    public static void HasSSE3() => SDL_HasSSE3();
    public static void HasSSE41() => SDL_HasSSE41();
    public static void HasSSE42() => SDL_HasSSE42();
}