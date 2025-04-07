using System.Drawing;
using System.Numerics;

namespace CopperDevs.Windowing;

/// <summary>
/// Utility Extensions
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Create a new vector4 from a color
    /// </summary>
    /// <param name="value">Color to create from</param>
    /// <returns>The created vector4</returns>
    public static Vector4 ToVector4(this Color value) => new(value.R, value.G, value.B, value.A);

    /// <summary>
    /// Rounds both values to the nearest amount of digits
    /// </summary>
    /// <returns>Both numbers rounded to the numbers nearest to them that contains a number of fractional digits equal to digits.</returns>
    public static Vector2 Round(this Vector2 vector, int digits)
    {
        return new Vector2(MathF.Round(vector.X, digits), MathF.Round(vector.Y, digits));
    }
}
