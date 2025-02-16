using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void ClearClipboardData() => SDL_ClearClipboardData();
    public static void GetClipboardData() => SDL_GetClipboardData();
    public static void GetClipboardMimeTypes() => SDL_GetClipboardMimeTypes();
    public static void GetClipboardText() => SDL_GetClipboardText();
    public static void GetPrimarySelectionText() => SDL_GetPrimarySelectionText();
    public static void HasClipboardData() => SDL_HasClipboardData();
    public static void HasClipboardText() => SDL_HasClipboardText();
    public static void HasPrimarySelectionText() => SDL_HasPrimarySelectionText();
    public static void SetClipboardData() => SDL_SetClipboardData();
    public static void SetClipboardText() => SDL_SetClipboardText();
    public static void SetPrimarySelectionText() => SDL_SetPrimarySelectionText();
}