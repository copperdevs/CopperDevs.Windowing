using SDL;

namespace CopperDevs.Windowing.SDL3.Data;

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