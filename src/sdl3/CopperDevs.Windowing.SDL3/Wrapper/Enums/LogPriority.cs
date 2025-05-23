#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
namespace CopperDevs.Windowing.SDL3;

public enum LogPriority
{
    Invalid = SDL_LogPriority.SDL_LOG_PRIORITY_INVALID,
    Trace = SDL_LogPriority.SDL_LOG_PRIORITY_TRACE,
    Verbose = SDL_LogPriority.SDL_LOG_PRIORITY_VERBOSE,
    Debug = SDL_LogPriority.SDL_LOG_PRIORITY_DEBUG,
    Info = SDL_LogPriority.SDL_LOG_PRIORITY_INFO,
    Warn = SDL_LogPriority.SDL_LOG_PRIORITY_WARN,
    Error = SDL_LogPriority.SDL_LOG_PRIORITY_ERROR,
    Critical = SDL_LogPriority.SDL_LOG_PRIORITY_CRITICAL,
    Count = SDL_LogPriority.SDL_LOG_PRIORITY_COUNT,
}