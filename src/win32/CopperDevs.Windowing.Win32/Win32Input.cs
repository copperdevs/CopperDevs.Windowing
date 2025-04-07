using System;
using System.Numerics;
using CopperDevs.Windowing.Data;

namespace CopperDevs.Windowing.Win32;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

public class Win32Input : IInput
{
    Vector2 IInput.GetMouseDelta()
    {
        throw new NotImplementedException();
    }

    Vector2 IInput.GetMousePosition()
    {
        throw new NotImplementedException();
    }

    Vector2 IInput.GetMouseScroll()
    {
        throw new NotImplementedException();
    }

    bool IInput.IsKeyDown(InputKey key)
    {
        throw new NotImplementedException();
    }

    bool IInput.IsKeyPressed(InputKey key)
    {
        throw new NotImplementedException();
    }

    bool IInput.IsKeyReleased(InputKey key)
    {
        throw new NotImplementedException();
    }

    bool IInput.IsKeyUp(InputKey key)
    {
        throw new NotImplementedException();
    }

    bool IInput.IsMouseButtonDown(MouseButton button)
    {
        throw new NotImplementedException();
    }

    bool IInput.IsMouseButtonPressed(MouseButton button)
    {
        throw new NotImplementedException();
    }

    bool IInput.IsMouseButtonReleased(MouseButton button)
    {
        throw new NotImplementedException();
    }

    bool IInput.IsMouseButtonUp(MouseButton button)
    {
        throw new NotImplementedException();
    }

    void IInput.SetCursorMode(CursorMode cursorMode)
    {
        throw new NotImplementedException();
    }

    bool IInput.SupportsInputKey(InputKey inputKey)
    {
        throw new NotImplementedException();
    }

    void IInput.UpdateInput()
    {
        throw new NotImplementedException();
    }
}
