using CopperDevs.Core.Data;
using CopperDevs.Logger;
using CopperDevs.Windowing.Data;

namespace CopperDevs.Windowing;

public partial class Window
{
    private IInput? input;

    private void SetupInput()
    {
        input ??= CreateInput();
    }

    protected abstract IInput CreateInput();

    private bool InputCheck()
    {
        if (input is not null)
            return true;

        Log.Warning("Input is not setup, attempting to setup now");
        SetupInput();

        return input is not null;
    }

    private bool InputCheck(InputKey key)
    {
        return InputCheck() && input!.SupportsInputKey(key);
    }

    public bool IsKeyPressed(InputKey key)
    {
        return InputCheck(key) && input!.IsKeyPressed(key);
    }

    public bool IsKeyDown(InputKey key)
    {
        return InputCheck(key) && input!.IsKeyDown(key);
    }

    public bool IsKeyReleased(InputKey key)
    {
        return InputCheck(key) && input!.IsKeyReleased(key);
    }

    public bool IsKeyUp(InputKey key)
    {
        return InputCheck() && input!.IsKeyUp(key);
    }

    public bool IsMouseButtonPressed(MouseButton button)
    {
        return InputCheck() && input!.IsMouseButtonPressed(button);
    }

    public bool IsMouseButtonDown(MouseButton button)
    {
        return InputCheck() && input!.IsMouseButtonDown(button);
    }

    public bool IsMouseButtonReleased(MouseButton button)
    {
        return InputCheck() && input!.IsMouseButtonReleased(button);
    }

    public bool IsMouseButtonUp(MouseButton button)
    {
        return InputCheck() && input!.IsMouseButtonUp(button);
    }

    public Vector2Int GetMousePosition()
    {
        return InputCheck() ? input!.GetMousePosition() : Vector2Int.Zero;
    }

    public Vector2Int GetMouseDelta()
    {
        return InputCheck() ? input!.GetMouseDelta() : Vector2Int.Zero;
    }

    public void SetCursorMode(CursorMode cursorMode)
    {
        if (InputCheck())
            input!.SetCursorMode(cursorMode);
    }
}