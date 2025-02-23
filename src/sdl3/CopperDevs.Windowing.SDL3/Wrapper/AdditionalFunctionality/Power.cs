using CopperDevs.Windowing.SDL3.Wrapper.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDLAPI
{
    public static PowerInfo GetPowerInfo()
    {
        int* seconds = null;
        int* percent = null;
        
        var state = SDL_GetPowerInfo(seconds, percent);

        return new PowerInfo()
        {
            Percent = *percent,
            Seconds = *seconds,
            State = (PowerState)state
        };
    }
}