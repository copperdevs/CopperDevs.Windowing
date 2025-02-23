using CopperDevs.Windowing.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace CopperDevs.Windowing.SDL3;

public static class Extensions
{
    // ReSharper disable once InconsistentNaming
    public static SDL_FColor AsSDLColor(this Color color)
    {
        return new SDL_FColor { r = color.R /= 255f, g = color.G /= 255f, b = color.B /= 255f, a = color.A /= 255f };
    }

    public static Color AsColor(this SDL_FColor color)
    {
        return new Color(color.r *= 255f, color.g *= 255f, color.b *= 255f, color.a *= 255f);
    }
}