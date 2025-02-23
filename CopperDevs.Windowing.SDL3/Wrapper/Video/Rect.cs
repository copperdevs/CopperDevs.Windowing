using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

//TODO: Change this to properly use arrays
public static unsafe partial class SDLAPI
{
    public static bool GetRectAndLineIntersection(SDL_Rect* rect, int* x1, int* y1, int* x2, int* y2) => SDL_GetRectAndLineIntersection(rect, x1, y1, x2, y2);

    public static bool GetRectAndLineIntersectionFloat(SDL_FRect* rect, float* x1, float* y1, float* x2, float* y2) => SDL_GetRectAndLineIntersectionFloat(rect, x1, y1, x2, y2);

    public static bool GetRectEnclosingPoints(SDL_Point* points, int count, SDL_Rect* clip, SDL_Rect* result) => SDL_GetRectEnclosingPoints(points, count, clip, result);

    public static bool GetRectEnclosingPointsFloat(SDL_FPoint* points, int count, SDL_FRect* clip, SDL_FRect* result) => SDL_GetRectEnclosingPointsFloat(points, count, clip, result);

    public static bool GetRectIntersection(SDL_Rect* rectA, SDL_Rect* rectB, SDL_Rect* result) => SDL_GetRectIntersection(rectA, rectB, result);

    public static bool GetRectIntersectionFloat(SDL_FRect* rectA, SDL_FRect* rectB, SDL_FRect* result) => SDL_GetRectIntersectionFloat(rectA, rectB, result);

    public static void GetRectUnion(SDL_Rect* rectA, SDL_Rect* rectB, SDL_Rect* result) => SDL_GetRectUnion(rectA, rectB, result);

    public static void GetRectUnionFloat(SDL_FRect* rectA, SDL_FRect* rectB, SDL_FRect* result) => SDL_GetRectUnionFloat(rectA, rectB, result);

    public static bool HasRectIntersection(SDL_Rect* rectA, SDL_Rect* rectB) => SDL_HasRectIntersection(rectA, rectB);

    public static bool HasRectIntersectionFloat(SDL_FRect* rectA, SDL_FRect* rectB) => SDL_HasRectIntersectionFloat(rectA, rectB);

    public static bool PointInRect(SDL_Point* point, SDL_Rect* rect) => SDL_PointInRect(point, rect);

    public static bool PointInRectFloat(SDL_FPoint* point, SDL_FRect* rect) => SDL_PointInRectFloat(point, rect);

    public static bool RectEmpty(SDL_Rect* rect) => SDL_RectEmpty(rect);

    public static bool RectEmptyFloat(SDL_FRect* rect) => SDL_RectEmptyFloat(rect);

    public static bool RectsEqual(SDL_Rect* rectA, SDL_Rect* rectB) => SDL_RectsEqual(rectA, rectB);

    public static bool RectsEqualEpsilon(SDL_FRect* rectA, SDL_FRect* rectB, float epsilon) => SDL_RectsEqualEpsilon(rectA, rectB, epsilon);

    public static bool RectsEqualFloat(SDL_FRect* rectA, SDL_FRect* rectB) => SDL_RectsEqualFloat(rectA, rectB);

    public static void RectToFRect(SDL_Rect* rect, SDL_FRect* result) => SDL_RectToFRect(rect, result);
}