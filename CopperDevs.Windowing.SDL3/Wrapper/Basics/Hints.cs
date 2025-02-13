using CopperDevs.Windowing.SDL3.Data;
using CopperDevs.Windowing.SDL3.Wrapper.Enums;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static string GetHint(string value) => SDL_GetHint(value) ?? string.Empty;

    public static bool GetHint(string value, bool defaultValue) => SDL_GetHintBoolean(value, defaultValue);

    public static bool ResetHint(string value) => SDL_ResetHint(value);

    public static void ResetHints() => SDL_ResetHints();

    public static bool SetHint(string name, string value) => SDL_SetHint(name, value);

    public static bool SetHint(byte* name, byte* value) => SDL_SetHint(name, value);

    public static bool SetHint(string name, string value, HintPriority priority) => SDL_SetHintWithPriority(name, value, (SDL_HintPriority)priority);

    public static bool SetHint(byte* name, byte* value, HintPriority priority) => SDL_SetHintWithPriority(name, value, (SDL_HintPriority)priority);

}