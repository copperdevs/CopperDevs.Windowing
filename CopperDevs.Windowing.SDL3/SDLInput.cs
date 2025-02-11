using CopperDevs.Core.Data;
using CopperDevs.Windowing.Data;
using CopperDevs.Windowing.SDL3.Data;

namespace CopperDevs.Windowing.SDL3;

public class SDLInput : IInput
{
    private SDLKeyMap keyMap;
    private SDLMouseMap mouseMap;

    public bool SupportsInputKey(InputKey inputKey)
    {
        return keyMap[inputKey] != SDL_Keycode.SDLK_UNKNOWN;
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