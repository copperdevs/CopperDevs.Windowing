#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDLAPI
{
    // ReSharper disable once InconsistentNaming
    public static bool OpenURL(string path) => SDL_OpenURL(path);
}