using CopperDevs.Core.Data;
using CopperDevs.Windowing.Data;

namespace CopperDevs.Windowing.SDL3;

public class SDLInput : IInput
{
    private readonly Dictionary<InputKey, SDL_Keycode> keys = new()
    {
        { InputKey.Unknown, SDL_Keycode.SDLK_UNKNOWN },
        { InputKey.Space, SDL_Keycode.SDLK_SPACE },
        { InputKey.Apostrophe, SDL_Keycode.SDLK_APOSTROPHE },
        { InputKey.Comma, SDL_Keycode.SDLK_COMMA },
        { InputKey.Minus, SDL_Keycode.SDLK_MINUS },
        { InputKey.Period, SDL_Keycode.SDLK_PERIOD },
        { InputKey.Slash, SDL_Keycode.SDLK_SLASH },
        { InputKey.Number0, SDL_Keycode.SDLK_0 },
        { InputKey.Number1, SDL_Keycode.SDLK_1 },
        { InputKey.Number2, SDL_Keycode.SDLK_2 },
        { InputKey.Number3, SDL_Keycode.SDLK_3 },
        { InputKey.Number4, SDL_Keycode.SDLK_4 },
        { InputKey.Number5, SDL_Keycode.SDLK_5 },
        { InputKey.Number6, SDL_Keycode.SDLK_6 },
        { InputKey.Number7, SDL_Keycode.SDLK_7 },
        { InputKey.Number8, SDL_Keycode.SDLK_8 },
        { InputKey.Number9, SDL_Keycode.SDLK_9 },
        { InputKey.Semicolon, SDL_Keycode.SDLK_SEMICOLON },
        { InputKey.Equal, SDL_Keycode.SDLK_EQUALS },
        { InputKey.A, SDL_Keycode.SDLK_A },
        { InputKey.B, SDL_Keycode.SDLK_B },
        { InputKey.C, SDL_Keycode.SDLK_C },
        { InputKey.D, SDL_Keycode.SDLK_D },
        { InputKey.E, SDL_Keycode.SDLK_E },
        { InputKey.F, SDL_Keycode.SDLK_F },
        { InputKey.G, SDL_Keycode.SDLK_G },
        { InputKey.H, SDL_Keycode.SDLK_H },
        { InputKey.I, SDL_Keycode.SDLK_I },
        { InputKey.J, SDL_Keycode.SDLK_J },
        { InputKey.K, SDL_Keycode.SDLK_K },
        { InputKey.L, SDL_Keycode.SDLK_L },
        { InputKey.M, SDL_Keycode.SDLK_M },
        { InputKey.N, SDL_Keycode.SDLK_N },
        { InputKey.O, SDL_Keycode.SDLK_O },
        { InputKey.P, SDL_Keycode.SDLK_P },
        { InputKey.Q, SDL_Keycode.SDLK_Q },
        { InputKey.R, SDL_Keycode.SDLK_R },
        { InputKey.S, SDL_Keycode.SDLK_S },
        { InputKey.T, SDL_Keycode.SDLK_T },
        { InputKey.U, SDL_Keycode.SDLK_U },
        { InputKey.V, SDL_Keycode.SDLK_V },
        { InputKey.W, SDL_Keycode.SDLK_W },
        { InputKey.X, SDL_Keycode.SDLK_X },
        { InputKey.Y, SDL_Keycode.SDLK_Y },
        { InputKey.Z, SDL_Keycode.SDLK_Z },
        { InputKey.LeftBracket, SDL_Keycode.SDLK_LEFTBRACKET },
        { InputKey.BackSlash, SDL_Keycode.SDLK_BACKSLASH },
        { InputKey.RightBracket, SDL_Keycode.SDLK_RIGHTBRACKET },
        { InputKey.GraveAccent, SDL_Keycode.SDLK_GRAVE },
        { InputKey.Escape, SDL_Keycode.SDLK_ESCAPE },
        { InputKey.Enter, SDL_Keycode.SDLK_RETURN },
        { InputKey.Tab, SDL_Keycode.SDLK_TAB },
        { InputKey.Backspace, SDL_Keycode.SDLK_BACKSPACE },
        { InputKey.Insert, SDL_Keycode.SDLK_INSERT },
        { InputKey.Delete, SDL_Keycode.SDLK_DELETE },
        { InputKey.Right, SDL_Keycode.SDLK_RIGHT },
        { InputKey.Left, SDL_Keycode.SDLK_LEFT },
        { InputKey.Down, SDL_Keycode.SDLK_DOWN },
        { InputKey.Up, SDL_Keycode.SDLK_UP },
        { InputKey.PageUp, SDL_Keycode.SDLK_PAGEUP },
        { InputKey.PageDown, SDL_Keycode.SDLK_PAGEDOWN },
        { InputKey.Home, SDL_Keycode.SDLK_HOME },
        { InputKey.End, SDL_Keycode.SDLK_END },
        { InputKey.CapsLock, SDL_Keycode.SDLK_CAPSLOCK },
        { InputKey.ScrollLock, SDL_Keycode.SDLK_SCROLLLOCK },
        { InputKey.NumLock, SDL_Keycode.SDLK_NUMLOCKCLEAR },
        { InputKey.PrintScreen, SDL_Keycode.SDLK_PRINTSCREEN },
        { InputKey.Pause, SDL_Keycode.SDLK_PAUSE },
        { InputKey.F1, SDL_Keycode.SDLK_F1 },
        { InputKey.F2, SDL_Keycode.SDLK_F2 },
        { InputKey.F3, SDL_Keycode.SDLK_F3 },
        { InputKey.F4, SDL_Keycode.SDLK_F4 },
        { InputKey.F5, SDL_Keycode.SDLK_F5 },
        { InputKey.F6, SDL_Keycode.SDLK_F6 },
        { InputKey.F7, SDL_Keycode.SDLK_F7 },
        { InputKey.F8, SDL_Keycode.SDLK_F8 },
        { InputKey.F9, SDL_Keycode.SDLK_F9 },
        { InputKey.F10, SDL_Keycode.SDLK_F10 },
        { InputKey.F11, SDL_Keycode.SDLK_F11 },
        { InputKey.F12, SDL_Keycode.SDLK_F12 },
        { InputKey.F13, SDL_Keycode.SDLK_UNKNOWN },
        { InputKey.F14, SDL_Keycode.SDLK_UNKNOWN },
        { InputKey.F15, SDL_Keycode.SDLK_UNKNOWN },
        { InputKey.F16, SDL_Keycode.SDLK_UNKNOWN },
        { InputKey.F17, SDL_Keycode.SDLK_UNKNOWN },
        { InputKey.F18, SDL_Keycode.SDLK_UNKNOWN },
        { InputKey.F19, SDL_Keycode.SDLK_UNKNOWN },
        { InputKey.F20, SDL_Keycode.SDLK_UNKNOWN },
        { InputKey.F21, SDL_Keycode.SDLK_UNKNOWN },
        { InputKey.F22, SDL_Keycode.SDLK_UNKNOWN },
        { InputKey.F23, SDL_Keycode.SDLK_UNKNOWN },
        { InputKey.F24, SDL_Keycode.SDLK_UNKNOWN },
        { InputKey.F25, SDL_Keycode.SDLK_UNKNOWN },
        { InputKey.KeypadEqual, SDL_Keycode.SDLK_UNKNOWN },
        { InputKey.LeftShift, SDL_Keycode.SDLK_LSHIFT },
        { InputKey.LeftControl, SDL_Keycode.SDLK_LCTRL },
        { InputKey.LeftAlt, SDL_Keycode.SDLK_LALT },
        { InputKey.LeftSuper, SDL_Keycode.SDLK_LGUI },
        { InputKey.RightShift, SDL_Keycode.SDLK_RSHIFT },
        { InputKey.RightControl, SDL_Keycode.SDLK_RCTRL },
        { InputKey.RightAlt, SDL_Keycode.SDLK_RALT },
        { InputKey.RightSuper, SDL_Keycode.SDLK_RGUI }
    };

    private readonly Dictionary<MouseButton, SDLButton> mouseButtons = new()
    {
        { MouseButton.Left, SDLButton.SDL_BUTTON_LEFT },
        { MouseButton.Middle, SDLButton.SDL_BUTTON_MIDDLE },
        { MouseButton.Right, SDLButton.SDL_BUTTON_RIGHT },
    };

    public bool SupportsInputKey(InputKey inputKey)
    {
        return keys[inputKey] != SDL_Keycode.SDLK_UNKNOWN;
    }

    public bool IsKeyPressed(InputKey key)
    {
        throw new NotImplementedException();
    }

    public bool IsKeyDown(InputKey key)
    {
        throw new NotImplementedException();
    }

    public bool IsKeyReleased(InputKey key)
    {
        throw new NotImplementedException();
    }

    public bool IsKeyUp(InputKey key)
    {
        throw new NotImplementedException();
    }

    public bool IsMouseButtonPressed(MouseButton button)
    {
        throw new NotImplementedException();
    }

    public bool IsMouseButtonDown(MouseButton button)
    {
        throw new NotImplementedException();
    }

    public bool IsMouseButtonReleased(MouseButton button)
    {
        throw new NotImplementedException();
    }

    public bool IsMouseButtonUp(MouseButton button)
    {
        throw new NotImplementedException();
    }

    public Vector2Int GetMousePosition()
    {
        throw new NotImplementedException();
    }

    public Vector2Int GetMouseDelta()
    {
        throw new NotImplementedException();
    }

    public void SetCursorMode(CursorMode cursorMode)
    {
        throw new NotImplementedException();
    }
}