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

    public bool IsKeyPressed(InputKey key) => InputCheck() && input!.IsKeyPressed(key);

    public bool IsKeyDown(InputKey key) => InputCheck() && input!.IsKeyDown(key);

    public bool IsKeyReleased(InputKey key) => InputCheck() && input!.IsKeyReleased(key);

    public bool IsKeyUp(InputKey key) => InputCheck() && input!.IsKeyUp(key);

    public bool IsMouseButtonPressed(MouseButton button) => InputCheck() && input!.IsMouseButtonPressed(button);

    public bool IsMouseButtonDown(MouseButton button) => InputCheck() && input!.IsMouseButtonDown(button);

    public bool IsMouseButtonReleased(MouseButton button) => InputCheck() && input!.IsMouseButtonReleased(button);

    public bool IsMouseButtonUp(MouseButton button) => InputCheck() && input!.IsMouseButtonUp(button);

    public Vector2Int GetMousePosition() => InputCheck() ? input!.GetMousePosition() : Vector2Int.Zero;

    public Vector2Int GetMouseDelta() => InputCheck() ? input!.GetMouseDelta() : Vector2Int.Zero;

    public void SetCursorMode(CursorMode cursorMode)
    {
        if (InputCheck())
            input!.SetCursorMode(cursorMode);
    }
}