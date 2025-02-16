using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void ClearComposition() => SDL_ClearComposition();
    public static void GetKeyboardFocus() => SDL_GetKeyboardFocus();
    public static void GetKeyboardNameForID() => SDL_GetKeyboardNameForID();
    public static void GetKeyboards() => SDL_GetKeyboards();
    public static void GetKeyboardState() => SDL_GetKeyboardState();
    public static void GetKeyFromName() => SDL_GetKeyFromName();
    public static void GetKeyFromScancode() => SDL_GetKeyFromScancode();
    public static void GetKeyName() => SDL_GetKeyName();
    public static void GetModState() => SDL_GetModState();
    public static void GetScancodeFromKey() => SDL_GetScancodeFromKey();
    public static void GetScancodeFromName() => SDL_GetScancodeFromName();
    public static void GetScancodeName() => SDL_GetScancodeName();
    public static void GetTextInputArea() => SDL_GetTextInputArea();
    public static void HasKeyboard() => SDL_HasKeyboard();
    public static void HasScreenKeyboardSupport() => SDL_HasScreenKeyboardSupport();
    public static void ResetKeyboard() => SDL_ResetKeyboard();
    public static void ScreenKeyboardShown() => SDL_ScreenKeyboardShown();
    public static void SetModState() => SDL_SetModState();
    public static void SetScancodeName() => SDL_SetScancodeName();
    public static void SetTextInputArea() => SDL_SetTextInputArea();
    public static void StartTextInput() => SDL_StartTextInput();
    public static void StartTextInputWithProperties() => SDL_StartTextInputWithProperties();
    public static void StopTextInput() => SDL_StopTextInput();
    public static void TextInputActive() => SDL_TextInputActive();
}