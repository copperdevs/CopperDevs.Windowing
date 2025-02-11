using CopperDevs.Core.Data;
using CopperDevs.Windowing.Data;

namespace CopperDevs.Windowing;

public interface IInput
{
    // checks
    public bool SupportsInputKey(InputKey inputKey);
    
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
    public Vector2Int GetMousePosition();
    public Vector2Int GetMouseDelta();

    // cursor settings
    public void SetCursorMode(CursorMode cursorMode);
}