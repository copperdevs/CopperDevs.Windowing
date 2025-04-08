using System;
using System.Numerics;
using System.Runtime.Versioning;
using CopperDevs.Windowing.Data;

namespace CopperDevs.Windowing.Win32;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

[SupportedOSPlatform("windows5.0")]
public class Win32Input : IInput
{
    Vector2 IInput.GetMouseDelta()
    {
        return Vector2.Zero;
    }

    Vector2 IInput.GetMousePosition()
    {
        return Vector2.Zero;
    }

    Vector2 IInput.GetMouseScroll()
    {
        return Vector2.Zero;
    }

    bool IInput.IsKeyDown(InputKey key)
    {
        return false;
    }

    bool IInput.IsKeyPressed(InputKey key)
    {
        return false;
    }

    bool IInput.IsKeyReleased(InputKey key)
    {
        return false;
    }

    bool IInput.IsKeyUp(InputKey key)
    {
        return false;
    }

    bool IInput.IsMouseButtonDown(MouseButton button)
    {
        return false;
    }

    bool IInput.IsMouseButtonPressed(MouseButton button)
    {
        return false;
    }

    bool IInput.IsMouseButtonReleased(MouseButton button)
    {
        return false;
    }

    bool IInput.IsMouseButtonUp(MouseButton button)
    {
        return false;
    }

    void IInput.SetCursorMode(CursorMode cursorMode)
    {
    }

    bool IInput.SupportsInputKey(InputKey inputKey)
    {
        return false;
    }

    void IInput.UpdateInput()
    {
    }
}
