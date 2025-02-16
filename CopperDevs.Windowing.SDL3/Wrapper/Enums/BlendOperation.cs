namespace CopperDevs.Windowing.SDL3.Wrapper.Enums;

public enum BlendOperation
{
    Add = SDL_BlendOperation.SDL_BLENDOPERATION_ADD,
    Subtract = SDL_BlendOperation.SDL_BLENDOPERATION_SUBTRACT,
    RevSubtract = SDL_BlendOperation.SDL_BLENDOPERATION_REV_SUBTRACT,
    Minimum = SDL_BlendOperation.SDL_BLENDOPERATION_MINIMUM,
    Maximum = SDL_BlendOperation.SDL_BLENDOPERATION_MAXIMUM,
}