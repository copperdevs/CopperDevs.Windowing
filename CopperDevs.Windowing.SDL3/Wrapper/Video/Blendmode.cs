using CopperDevs.Windowing.SDL3.Wrapper.Enums;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static BlendFactor ComposeCustomBlendMode(
        BlendFactor srcColorFactor,
        BlendFactor dstColorFactor,
        BlendOperation colorOperation,
        BlendFactor srcAlphaFactor,
        BlendFactor dstAlphaFactor,
        BlendOperation alphaOperation) => (BlendFactor)SDL_ComposeCustomBlendMode(
        (SDL_BlendFactor)srcColorFactor,
        (SDL_BlendFactor)dstColorFactor,
        (SDL_BlendOperation)colorOperation,
        (SDL_BlendFactor)srcAlphaFactor,
        (SDL_BlendFactor)dstAlphaFactor,
        (SDL_BlendOperation)alphaOperation);
}