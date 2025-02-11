using CopperDevs.Core.Data;
using CopperDevs.Windowing.Data;

namespace CopperDevs.Windowing;

public interface IInput
{
    public bool IsKeyPressed(InputKey key);
    public bool IsKeyDown(InputKey key);
    public bool IsKeyReleased(InputKey key);
    public bool IsKeyUp(InputKey key);
    
    public bool IsMouseButtonPressed(MouseButton button);
    public bool IsMouseButtonDown(MouseButton button);
    public bool IsMouseButtonReleased(MouseButton button);
    public bool IsMouseButtonUp(MouseButton button);
    
    public Vector2Int GetMousePosition();
    public Vector2Int GetMouseDelta();
    
    public void SetCursorMode(CursorMode cursorMode);
}