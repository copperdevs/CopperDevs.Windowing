using System.Numerics;

namespace CopperDevs.Windowing;

public static class Extensions
{
    public static Vector2 Round(this Vector2 vector, int digits)
    {
        return new Vector2(MathF.Round(vector.X, digits), MathF.Round(vector.Y, digits));
    }
}