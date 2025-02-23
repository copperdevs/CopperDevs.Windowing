using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDLAPI
{
    public static string GetTouchDeviceName(SDL_TouchID id) => SDL_GetTouchDeviceName(id) ?? string.Empty;

    public static SDL_TouchID[] GetTouchDevices()
    {
        using var sdlArray = SDL_GetTouchDevices();

        if (sdlArray is null)
            return [];

        var array = new SDL_TouchID[sdlArray.Count];

        for (var i = 0; i < sdlArray.Count; i++)
            array[i] = sdlArray[i];

        return array;
    }

    public static SDL_TouchDeviceType GetTouchDeviceType(SDL_TouchID id) => SDL_GetTouchDeviceType(id);

    public static SDL_Finger[] GetTouchFingers(SDL_TouchID id)
    {
        using var sdlArray = SDL_GetTouchFingers(id);

        if (sdlArray is null)
            return [];

        var array = new SDL_Finger[sdlArray.Count];

        for (var i = 0; i < sdlArray.Count; i++)
            array[i] = sdlArray[i];

        return array;
        
    }
}