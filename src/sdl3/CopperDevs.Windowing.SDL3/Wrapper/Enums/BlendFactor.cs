#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
namespace CopperDevs.Windowing.SDL3;

public enum BlendFactor
{
    Zero = SDL_BlendFactor.SDL_BLENDFACTOR_ZERO,
    One = SDL_BlendFactor.SDL_BLENDFACTOR_ONE,
    SrcColor = SDL_BlendFactor.SDL_BLENDFACTOR_SRC_COLOR,
    OneMinusSrcColor = SDL_BlendFactor.SDL_BLENDFACTOR_ONE_MINUS_SRC_COLOR,
    SrcAlpha = SDL_BlendFactor.SDL_BLENDFACTOR_SRC_ALPHA,
    OneMinusSrcAlpha = SDL_BlendFactor.SDL_BLENDFACTOR_ONE_MINUS_SRC_ALPHA,
    DstColor = SDL_BlendFactor.SDL_BLENDFACTOR_DST_COLOR,
    OneMinusDstColor = SDL_BlendFactor.SDL_BLENDFACTOR_ONE_MINUS_DST_COLOR,
    DstAlpha = SDL_BlendFactor.SDL_BLENDFACTOR_DST_ALPHA,
    OneMinusDstAlpha = SDL_BlendFactor.SDL_BLENDFACTOR_ONE_MINUS_DST_ALPHA,
}