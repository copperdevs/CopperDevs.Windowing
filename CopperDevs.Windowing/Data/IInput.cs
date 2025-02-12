using System.Numerics;

namespace CopperDevs.Windowing.Data;

public interface IInput
{
    // updates
    protected internal void UpdateInput();

    // checks
    protected internal bool SupportsInputKey(InputKey inputKey);

    // key inputs
    public bool IsKeyPressed(InputKey key);
    public bool IsKeyDown(InputKey key);
    public bool IsKeyReleased(InputKey key);
    public bool IsKeyUp(InputKey key);

    // mouse inputs
    public bool IsMouseButtonPressed(MouseButton button);
    public bool IsMouseButtonDown(MouseButton button);
    public bool IsMouseButtonReleased(MouseButton button);
    public bool IsMouseButtonUp(MouseButton button);

    // mouse values
    public Vector2 GetMousePosition();
    public Vector2 GetMouseDelta();
    public Vector2 GetMouseScroll();

    // cursor settings
    public void SetCursorMode(CursorMode cursorMode);
}