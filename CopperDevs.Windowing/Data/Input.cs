using System.Numerics;
using CopperDevs.Core.Data;
using CopperDevs.Logger;

namespace CopperDevs.Windowing.Data;

public static class Input
{
    private static Window window;
    private static IInput? input;
    
    internal static void Connect(Window targetWindow, IInput targetInput)
    {
        window = targetWindow;
        input = targetInput;
    }


    private static bool InputCheck()
    {
        if (input is not null)
            return true;

        Log.Warning("Input is not setup, attempting to setup now");
        window.SetupInput();

        return input is not null;
    }

    private static bool InputCheck(InputKey key)
    {
        return InputCheck() && input!.SupportsInputKey(key);
    }

    public static bool IsKeyPressed(InputKey key)
    {
        return InputCheck(key) && input!.IsKeyPressed(key);
    }

    public static bool IsKeyDown(InputKey key)
    {
        return InputCheck(key) && input!.IsKeyDown(key);
    }

    public static bool IsKeyReleased(InputKey key)
    {
        return InputCheck(key) && input!.IsKeyReleased(key);
    }

    public static bool IsKeyUp(InputKey key)
    {
        return InputCheck() && input!.IsKeyUp(key);
    }

    public static bool IsMouseButtonPressed(MouseButton button)
    {
        return InputCheck() && input!.IsMouseButtonPressed(button);
    }

    public static bool IsMouseButtonDown(MouseButton button)
    {
        return InputCheck() && input!.IsMouseButtonDown(button);
    }

    public static bool IsMouseButtonReleased(MouseButton button)
    {
        return InputCheck() && input!.IsMouseButtonReleased(button);
    }

    public static bool IsMouseButtonUp(MouseButton button)
    {
        return InputCheck() && input!.IsMouseButtonUp(button);
    }

    public static Vector2 GetMousePosition()
    {
        return InputCheck() ? input!.GetMousePosition() : Vector2Int.Zero;
    }

    public static Vector2 GetMouseDelta()
    {
        return InputCheck() ? input!.GetMouseDelta() : Vector2Int.Zero;
    }

    public static Vector2 GetMouseScroll()
    {
        return InputCheck() ? input!.GetMouseScroll() : Vector2Int.Zero;
    }

    public static void SetCursorMode(CursorMode cursorMode)
    {
        if (InputCheck())
            input!.SetCursorMode(cursorMode);
    }
}