#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace CopperDevs.Windowing.SDL3.Data;

/// <summary>
/// Wrapper for <see cref="InitFlags"/>
/// </summary>
[Flags]
public enum InitFlags : uint
{
    Audio = SDL_InitFlags.SDL_INIT_AUDIO,
    Video = SDL_InitFlags.SDL_INIT_VIDEO,
    Joystick = SDL_InitFlags.SDL_INIT_JOYSTICK,
    Haptic = SDL_InitFlags.SDL_INIT_HAPTIC,
    Gamepad = SDL_InitFlags.SDL_INIT_GAMEPAD,
    Events = SDL_InitFlags.SDL_INIT_EVENTS,
    Sensor = SDL_InitFlags.SDL_INIT_SENSOR,
    Camera = SDL_InitFlags.SDL_INIT_CAMERA,
}