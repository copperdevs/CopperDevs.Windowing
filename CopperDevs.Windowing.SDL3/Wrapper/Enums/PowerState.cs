namespace CopperDevs.Windowing.SDL3.Wrapper.Enums;

public enum PowerState
{
    Error = SDL_PowerState.SDL_POWERSTATE_ERROR,
    Unknown = SDL_PowerState.SDL_POWERSTATE_UNKNOWN,
    OnBattery = SDL_PowerState.SDL_POWERSTATE_ON_BATTERY,
    NoBattery = SDL_PowerState.SDL_POWERSTATE_NO_BATTERY,
    Charging = SDL_PowerState.SDL_POWERSTATE_CHARGING,
    Charged = SDL_PowerState.SDL_POWERSTATE_CHARGED,
}