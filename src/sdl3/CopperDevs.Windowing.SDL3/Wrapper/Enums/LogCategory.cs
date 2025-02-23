#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
namespace CopperDevs.Windowing.SDL3;

public enum LogCategory
{
    Application = SDL_LogCategory.SDL_LOG_CATEGORY_APPLICATION,
    Error = SDL_LogCategory.SDL_LOG_CATEGORY_ERROR,
    Assert = SDL_LogCategory.SDL_LOG_CATEGORY_ASSERT,
    System = SDL_LogCategory.SDL_LOG_CATEGORY_SYSTEM,
    Audio = SDL_LogCategory.SDL_LOG_CATEGORY_AUDIO,
    Video = SDL_LogCategory.SDL_LOG_CATEGORY_VIDEO,
    Render = SDL_LogCategory.SDL_LOG_CATEGORY_RENDER,
    Input = SDL_LogCategory.SDL_LOG_CATEGORY_INPUT,
    Test = SDL_LogCategory.SDL_LOG_CATEGORY_TEST,
    Gpu = SDL_LogCategory.SDL_LOG_CATEGORY_GPU,

    /* Reserved for future SDL library use */

    Reserved2 = SDL_LogCategory.SDL_LOG_CATEGORY_RESERVED2,
    Reserved3 = SDL_LogCategory.SDL_LOG_CATEGORY_RESERVED3,
    Reserved4 = SDL_LogCategory.SDL_LOG_CATEGORY_RESERVED4,
    Reserved5 = SDL_LogCategory.SDL_LOG_CATEGORY_RESERVED5,
    Reserved6 = SDL_LogCategory.SDL_LOG_CATEGORY_RESERVED6,
    Reserved7 = SDL_LogCategory.SDL_LOG_CATEGORY_RESERVED7,
    Reserved8 = SDL_LogCategory.SDL_LOG_CATEGORY_RESERVED8,
    Reserved9 = SDL_LogCategory.SDL_LOG_CATEGORY_RESERVED9,
    Reserved10 = SDL_LogCategory.SDL_LOG_CATEGORY_RESERVED10,

    /* Beyond this point is reserved for application use, e.g.
       enum {
           MYAPP_CATEGORY_AWESOME1 = SDL_LOG_CATEGORY_CUSTOM,
           MYAPP_CATEGORY_AWESOME2,
           MYAPP_CATEGORY_AWESOME3,
           ...
       };
     */

    Custom = SDL_LogCategory.SDL_LOG_CATEGORY_CUSTOM,
}