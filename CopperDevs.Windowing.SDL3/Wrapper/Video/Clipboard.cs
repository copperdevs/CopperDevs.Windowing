using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static bool ClearClipboardData() => SDL_ClearClipboardData();
    public static void GetClipboardData(string mimeType, UIntPtr* size) => SDL_GetClipboardData(mimeType, size);
    public static byte** GetClipboardMimeTypes(UIntPtr* numMimeTypes) => SDL_GetClipboardMimeTypes(numMimeTypes);
    public static string GetClipboardText() => SDL_GetClipboardText() ?? string.Empty;
    public static string GetPrimarySelectionText() => SDL_GetPrimarySelectionText() ?? string.Empty;
    public static bool HasClipboardData(string mimeType) => SDL_HasClipboardData(mimeType);
    public static bool HasClipboardText() => SDL_HasClipboardText();

    public static bool HasPrimarySelectionText() => SDL_HasPrimarySelectionText();

//    public static void SetClipboardData() => SDL_SetClipboardData();
    public static bool SetClipboardText(string text) => SDL_SetClipboardText(text);
    public static bool SetPrimarySelectionText(string text) => SDL_SetPrimarySelectionText(text);
}