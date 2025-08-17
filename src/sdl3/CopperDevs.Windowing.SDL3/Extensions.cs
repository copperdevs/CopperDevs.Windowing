using CopperDevs.Windowing.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace CopperDevs.Windowing.SDL3;

public static class Extensions
{
    // ReSharper disable once InconsistentNaming
    public static SDLColor AsSDLColor(this Color color)
    {
        return new SDLColor { R = (byte)color.R, G = (byte)color.G, B = (byte)color.B, A = (byte)color.A };
    }

    public static Color AsColor(this SDLColor color)
    {
        return new Color(color.R, color.G, color.B, color.A);
    }
}