using CopperDevs.Windowing.Data;
using Hexa.NET.SDL3;

namespace CopperDevs.Windowing.SDL3.Data;

internal class SdlMouseMap : Dictionary<MouseButton, SDLMouseButtonFlags>
{
    public SdlMouseMap()
    {
        this[MouseButton.Left] = SDLMouseButtonFlags.Left;
        this[MouseButton.Middle] = SDLMouseButtonFlags.Middle;
        this[MouseButton.Right] = SDLMouseButtonFlags.Right;
    }
}