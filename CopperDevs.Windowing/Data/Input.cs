using System.Numerics;
using CopperDevs.Core.Data;
using CopperDevs.Logger;

namespace CopperDevs.Windowing.Data;

/// <summary>
/// Input data for getting info from the mouse and keyboard
/// </summary>
public static class Input
{
    private static Window window = null!;
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

    /// <summary>
    /// Checks if a key was pressed this frame
    /// </summary>
    /// <param name="key">Key to check</param>
    /// <returns>True if the key was pressed this frame</returns>
    public static bool IsKeyPressed(InputKey key)
    {
        return InputCheck(key) && input!.IsKeyPressed(key);
    }

    /// <summary>
    /// Checks if a key is down
    /// </summary>
    /// <param name="key">Key to check</param>
    /// <returns>True if the key was down this frame</returns>
    public static bool IsKeyDown(InputKey key)
    {
        return InputCheck(key) && input!.IsKeyDown(key);
    }

    /// <summary>
    /// Checks if a key was released this frame
    /// </summary>
    /// <param name="key">Key to check</param>
    /// <returns>True if the key was released this frame</returns>
    public static bool IsKeyReleased(InputKey key)
    {
        return InputCheck(key) && input!.IsKeyReleased(key);
    }

    /// <summary>
    /// Checks if a key is up
    /// </summary>
    /// <param name="key">Key to check</param>
    /// <returns>True if the key was up this frame</returns>
    public static bool IsKeyUp(InputKey key)
    {
        return InputCheck() && input!.IsKeyUp(key);
    }

    /// <summary>
    /// Checks if a mouse button was pressed this frame
    /// </summary>
    /// <param name="button">Mouse button to check</param>
    /// <returns>True if the mouse button was pressed this frame</returns>
    public static bool IsMouseButtonPressed(MouseButton button)
    {
        return InputCheck() && input!.IsMouseButtonPressed(button);
    }

    /// <summary>
    /// Checks if a mouse button is down
    /// </summary>
    /// <param name="button">Mouse button to check</param>
    /// <returns>True if the mouse button was down this frame</returns>
    public static bool IsMouseButtonDown(MouseButton button)
    {
        return InputCheck() && input!.IsMouseButtonDown(button);
    }

    /// <summary>
    /// Checks if a mouse button was released this frame
    /// </summary>
    /// <param name="button">Mouse button to check</param>
    /// <returns>True if the mouse button was released this frame</returns>
    public static bool IsMouseButtonReleased(MouseButton button)
    {
        return InputCheck() && input!.IsMouseButtonReleased(button);
    }

    /// <summary>
    /// Checks if a mouse button is up
    /// </summary>
    /// <param name="button">Mouse button to check</param>
    /// <returns>True if the mouse button was up this frame</returns>
    public static bool IsMouseButtonUp(MouseButton button)
    {
        return InputCheck() && input!.IsMouseButtonUp(button);
    }

    /// <summary>
    /// Get the current position of the mouse relative to the window
    /// </summary>
    /// <returns>Position of the mouse</returns>
    public static Vector2 GetMousePosition()
    {
        return InputCheck() ? input!.GetMousePosition() : Vector2.Zero;
    }

    /// <summary>
    /// Get the relative movement of the mouse
    /// </summary>
    /// <returns>Movement of the mouse</returns>
    public static Vector2 GetMouseDelta()
    {
        return InputCheck() ? input!.GetMouseDelta() : Vector2.Zero;
    }

    /// <summary>
    /// Get the mouse scroll delta
    /// </summary>
    /// <returns>Scroll value of the mouse</returns>
    public static Vector2 GetMouseScroll()
    {
        return InputCheck() ? input!.GetMouseScroll() : Vector2.Zero;
    }

    /// <summary>
    /// Set the cursor mode
    /// </summary>
    /// <param name="cursorMode">Mode to set</param>
    public static void SetCursorMode(CursorMode cursorMode)
    {
        if (InputCheck())
            input!.SetCursorMode(cursorMode);
    }
}