using CopperDevs.Windowing.SDL3.Data;
using CopperDevs.Windowing.SDL3.Wrapper.Enums;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static LogCategory GetLogPriority(LogCategory category) => (LogCategory)SDL_GetLogPriority((int)category);
    
    public static void SetLogPriorities(LogPriority priority) => SDL_SetLogPriorities((SDL_LogPriority)priority);
}