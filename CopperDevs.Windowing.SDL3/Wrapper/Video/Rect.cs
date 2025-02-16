using CopperDevs.Windowing.SDL3.Data;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void GetRectAndLineIntersection() => SDL_GetRectAndLineIntersection();
    public static void GetRectAndLineIntersectionFloat() => SDL_GetRectAndLineIntersectionFloat();
    public static void GetRectEnclosingPoints() => SDL_GetRectEnclosingPoints();
    public static void GetRectEnclosingPointsFloat() => SDL_GetRectEnclosingPointsFloat();
    public static void GetRectIntersection() => SDL_GetRectIntersection();
    public static void GetRectIntersectionFloat() => SDL_GetRectIntersectionFloat();
    public static void GetRectUnion() => SDL_GetRectUnion();
    public static void GetRectUnionFloat() => SDL_GetRectUnionFloat();
    public static void HasRectIntersection() => SDL_HasRectIntersection();
    public static void HasRectIntersectionFloat() => SDL_HasRectIntersectionFloat();
    public static void PointInRect() => SDL_PointInRect();
    public static void PointInRectFloat() => SDL_PointInRectFloat();
    public static void RectEmpty() => SDL_RectEmpty();
    public static void RectEmptyFloat() => SDL_RectEmptyFloat();
    public static void RectsEqual() => SDL_RectsEqual();
    public static void RectsEqualEpsilon() => SDL_RectsEqualEpsilon();
    public static void RectsEqualFloat() => SDL_RectsEqualFloat();
    public static void RectToFRect() => SDL_RectToFRect();
}