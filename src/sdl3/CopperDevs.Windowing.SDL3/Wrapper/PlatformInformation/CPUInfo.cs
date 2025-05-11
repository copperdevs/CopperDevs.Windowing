#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDLAPI
{
    public static int GetCpuCacheLineSize() => SDL_GetCPUCacheLineSize();
    public static int GetNumLogicalCpuCores() => SDL_GetNumLogicalCPUCores();
    public static nuint GetSimdAlignment() => SDL_GetSIMDAlignment();
    public static int GetSystemRam() => SDL_GetSystemRAM();
    public static bool HasAltiVec() => SDL_HasAltiVec();
    public static bool HasArmsimd() => SDL_HasARMSIMD();
    public static bool HasAvx() => SDL_HasAVX();
    public static bool HasAvx2() => SDL_HasAVX2();
    public static bool HasAvx512F() => SDL_HasAVX512F();
    public static bool HasLasx() => SDL_HasLASX();
    public static bool HasLsx() => SDL_HasLSX();
    public static bool HasMmx() => SDL_HasMMX();
    public static bool HasNeon() => SDL_HasNEON();
    public static bool HasSse() => SDL_HasSSE();
    public static bool HasSse2() => SDL_HasSSE2();
    public static bool HasSse3() => SDL_HasSSE3();
    public static bool HasSse41() => SDL_HasSSE41();
    public static bool HasSse42() => SDL_HasSSE42();
}