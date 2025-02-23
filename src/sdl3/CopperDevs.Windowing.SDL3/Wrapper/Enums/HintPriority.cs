#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
namespace CopperDevs.Windowing.SDL3;

public enum HintPriority
{
    HintDefault = SDL_HintPriority.SDL_HINT_DEFAULT,
    HintNormal = SDL_HintPriority.SDL_HINT_NORMAL,
    HintOverride = SDL_HintPriority.SDL_HINT_OVERRIDE,
}