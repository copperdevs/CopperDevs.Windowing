using CopperDevs.Core.Data;
using CopperDevs.Logger;
using CopperDevs.Windowing.Data;
using CopperDevs.Windowing.SDL3.Data;

namespace CopperDevs.Windowing.SDL3;

public class SDLInput : IInput
{
    private const bool InputLogs = true;

    private SDL3Window connectedWindow;

    private SDLKeyMap keyMap = new();
    private SDLMouseMap mouseMap = new();

    private readonly List<EventType> targetEvents =
    [
        // EventType.WindowMouseEnter,
        // EventType.WindowMouseLeave,
        EventType.MouseMotion,
        EventType.MouseButtonDown,
        EventType.MouseButtonUp,
        EventType.MouseWheel,
        // EventType.MouseAdded,
        // EventType.MouseRemoved,
        EventType.KeyDown,
        EventType.KeyUp,
        // EventType.KeymapChanged,
        // EventType.KeyboardAdded,
        // EventType.KeyboardRemoved,
    ];

    public SDLInput(SDL3Window connectedWindow)
    {
        this.connectedWindow = connectedWindow;

        connectedWindow.GetManagedSDLWindow().HandleEvent += EventHandler;
    }

    private void EventHandler(EventType eventType, SDL_Event eventData)
    {
        if (!targetEvents.Contains(eventType))
            return;

        // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
        switch (eventType)
        {
            case EventType.MouseMotion:
                if (InputLogs)
                    Log.Info($"Mouse Motion: <{eventData.motion.x},{eventData.motion.y}> | Mouse Motion Relative: <{eventData.motion.xrel},{eventData.motion.yrel}>");
                break;
            case EventType.MouseButtonDown:
                if (InputLogs)
                    Log.Info($"Mouse Button Down: {eventData.button.Button}");
                break;
            case EventType.MouseButtonUp:
                if (InputLogs)
                    Log.Info($"Mouse Button Up: {eventData.button.Button}");
                break;
            case EventType.MouseWheel:
                if (InputLogs)
                    Log.Info($"Mouse Wheel: <{eventData.wheel.x},{eventData.wheel.y}> | Mouse Wheel Mouse: <{eventData.wheel.mouse_x},{eventData.wheel.mouse_y}> | Direction: <{eventData.wheel.direction}>");
                break;
            case EventType.KeyDown:
                if (InputLogs)
                    Log.Info($"Key Down: {eventData.key.key} | Modifier: {eventData.key.mod}");
                break;
            case EventType.KeyUp:
                if (InputLogs)
                    Log.Info($"Key Up: {eventData.key.key} | Modifier: {eventData.key.mod}");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(eventType), eventType, null);
        }
    }

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