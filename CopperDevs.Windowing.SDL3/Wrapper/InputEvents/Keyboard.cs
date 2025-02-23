using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDLAPI
{
    public static bool ClearComposition(SDL_Window* window) => SDL_ClearComposition(window);
    public static SDL_Window* GetKeyboardFocus() => SDL_GetKeyboardFocus();
    public static string GetKeyboardNameForId(SDL_KeyboardID id) => SDL_GetKeyboardNameForID(id) ?? string.Empty;
    public static SDL_KeyboardID[] GetKeyboards() => SDLUtil.ToArray(SDL_GetKeyboards());
    public static SDLBool* GetKeyboardState(int* numKeys) => SDL_GetKeyboardState(numKeys);
    public static SDL_Keycode GetKeyFromName(string name) => SDL_GetKeyFromName(name);
    public static void GetKeyFromScancode(SDL_Scancode scancode, SDL_Keymod modState, SDLBool keyEvent) => SDL_GetKeyFromScancode(scancode, modState, keyEvent);
    public static string GetKeyName(SDL_Keycode keycode) => SDL_GetKeyName(keycode) ?? string.Empty;
    public static SDL_Keymod GetModState() => SDL_GetModState();
    public static SDL_Scancode GetScancodeFromKey(SDL_Keycode key, SDL_Keymod* modState) => SDL_GetScancodeFromKey(key, modState);
    public static SDL_Scancode GetScancodeFromName(string name) => SDL_GetScancodeFromName(name);
    public static string GetScancodeName(SDL_Scancode code) => SDL_GetScancodeName(code) ?? string.Empty;
    public static bool GetTextInputArea(SDL_Window* window, SDL_Rect* rect, int* cursor) => SDL_GetTextInputArea(window, rect, cursor);
    public static bool HasKeyboard() => SDL_HasKeyboard();
    public static bool HasScreenKeyboardSupport() => SDL_HasScreenKeyboardSupport();
    public static void ResetKeyboard() => SDL_ResetKeyboard();
    public static bool ScreenKeyboardShown(SDL_Window* window) => SDL_ScreenKeyboardShown(window);
    public static void SetModState(SDL_Keymod modState) => SDL_SetModState(modState);
    public static void SetScancodeName(SDL_Scancode scancode, string name) => SDL_SetScancodeName(scancode, name);
    public static bool SetTextInputArea(SDL_Window* window, SDL_Rect* rect, int cursor) => SDL_SetTextInputArea(window, rect, cursor);
    public static bool StartTextInput(SDL_Window* window) => SDL_StartTextInput(window);
    public static bool StartTextInputWithProperties(SDL_Window* window, SDL_PropertiesID props) => SDL_StartTextInputWithProperties(window, props);
    public static bool StopTextInput(SDL_Window* window) => SDL_StopTextInput(window);
    public static bool TextInputActive(SDL_Window* window) => SDL_TextInputActive(window);
}