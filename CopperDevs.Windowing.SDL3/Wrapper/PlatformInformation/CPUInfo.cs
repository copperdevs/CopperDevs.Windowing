using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDLAPI
{
    public static int GetCPUCacheLineSize() => SDL_GetCPUCacheLineSize();
    public static int GetNumLogicalCPUCores() => SDL_GetNumLogicalCPUCores();
    public static nuint GetSIMDAlignment() => SDL_GetSIMDAlignment();
    public static int GetSystemRAM() => SDL_GetSystemRAM();
    public static bool HasAltiVec() => SDL_HasAltiVec();
    public static bool HasARMSIMD() => SDL_HasARMSIMD();
    public static bool HasAVX() => SDL_HasAVX();
    public static bool HasAVX2() => SDL_HasAVX2();
    public static bool HasAVX512F() => SDL_HasAVX512F();
    public static bool HasLASX() => SDL_HasLASX();
    public static bool HasLSX() => SDL_HasLSX();
    public static bool HasMMX() => SDL_HasMMX();
    public static bool HasNEON() => SDL_HasNEON();
    public static bool HasSSE() => SDL_HasSSE();
    public static bool HasSSE2() => SDL_HasSSE2();
    public static bool HasSSE3() => SDL_HasSSE3();
    public static bool HasSSE41() => SDL_HasSSE41();
    public static bool HasSSE42() => SDL_HasSSE42();
}