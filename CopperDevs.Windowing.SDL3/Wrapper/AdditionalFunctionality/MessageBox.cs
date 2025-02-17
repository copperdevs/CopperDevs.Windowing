using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void ShowMessageBox(SDL_MessageBoxData* messageboxdata, int* buttonid) => SDL_ShowMessageBox(messageboxdata, buttonid);

    public static void ShowSimpleMessageBox(SDL_MessageBoxFlags flags, string title, string message, SDL_Window* window) => SDL_ShowSimpleMessageBox(flags, title, message, window);
}