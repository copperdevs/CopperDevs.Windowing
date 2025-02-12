using System.Numerics;
using CopperDevs.Core.Data;

namespace CopperDevs.Windowing.SDL3;

// ReSharper disable once InconsistentNaming
internal static unsafe class SDLUtil
{
    public static SDL_FPoint* ToPointer(List<Vector2> points)
    {
        var nativePoint = new SDL_FPoint[points.Count];

        for (var i = 0; i < points.Count; i++)
            nativePoint[i] = new SDL_FPoint { x = points[i].X, y = points[i].Y };

        fixed (SDL_FPoint* pointsPtr = nativePoint)
            return pointsPtr;
    }
}