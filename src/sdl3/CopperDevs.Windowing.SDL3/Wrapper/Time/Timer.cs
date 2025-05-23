#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDLAPI
{
    public static ulong GetTicks() => SDL_GetTicks();
    public static ulong GetTicksNs() => SDL_GetTicksNS();
}