using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void DateTimeToTime() => SDL_DateTimeToTime();
    public static void GetCurrentTime() => SDL_GetCurrentTime();
    public static void GetDateTimeLocalePreferences() => SDL_GetDateTimeLocalePreferences();
    public static void GetDayOfWeek() => SDL_GetDayOfWeek();
    public static void GetDayOfYear() => SDL_GetDayOfYear();
    public static void GetDaysInMonth() => SDL_GetDaysInMonth();
    public static void TimeFromWindows() => SDL_TimeFromWindows();
    public static void TimeToDateTime() => SDL_TimeToDateTime();
    public static void TimeToWindows() => SDL_TimeToWindows();
}