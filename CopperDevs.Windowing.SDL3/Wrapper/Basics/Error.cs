#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDLAPI
{
    public static bool ClearError() => SDL_ClearError();

    public static string GetError() => SDL_GetError() ?? string.Empty;

    public static bool OutOfMemory() => SDL_OutOfMemory();
}