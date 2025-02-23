#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
namespace CopperDevs.Windowing.SDL3;

public enum PowerState
{
    Error = SDL_PowerState.SDL_POWERSTATE_ERROR,
    Unknown = SDL_PowerState.SDL_POWERSTATE_UNKNOWN,
    OnBattery = SDL_PowerState.SDL_POWERSTATE_ON_BATTERY,
    NoBattery = SDL_PowerState.SDL_POWERSTATE_NO_BATTERY,
    Charging = SDL_PowerState.SDL_POWERSTATE_CHARGING,
    Charged = SDL_PowerState.SDL_POWERSTATE_CHARGED,
}