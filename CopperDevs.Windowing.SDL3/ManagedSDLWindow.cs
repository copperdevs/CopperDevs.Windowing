using CopperDevs.Core.Utility;
using CopperDevs.Windowing.Data;
using CopperDevs.Windowing.SDL3.Data;
using SDL;

namespace CopperDevs.Windowing.SDL3;

// ReSharper disable once InconsistentNaming
internal unsafe class ManagedSDLWindow : SafeDisposable
{
    private bool createdSuccessfully = false;

    // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
    private readonly SDL_Window* window;
    private readonly SDL_Renderer* renderer;

    // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
    private readonly WindowFlags windowFlags;
    private readonly InitFlags initFlags;

    private Events events = new();

    public ManagedSDLWindow(WindowOptions options)
    {
        initFlags = InitFlags.Video;
        windowFlags = WindowFlags.Resizable | WindowFlags.Hidden;

        if (options.GetType() == typeof(SDL3WindowOptions))
        {
            var windowOptions = (SDL3WindowOptions)options;

            initFlags = windowOptions.InitFlags;
            windowFlags = windowOptions.WindowFlags;
        }

        if (!(createdSuccessfully = SDL.InitSubSystem(initFlags)))
        {
            throw new InvalidOperationException($"Failed to initialise SDL. Error: {SDL.GetError()}");
        }

        events.HandleEvent += HandleEvents;

        window = SDL.CreateWindow(options.Title, options.Size, windowFlags);
        renderer = SDL.CreateRenderer(window);
    }

    public void Update()
    {
        events.Poll();
    }

    private void HandleEvents(SDL_Event e)
    {
        switch (e.Type)
        {
            case SDL_EventType.SDL_EVENT_FIRST:
                break;
            case SDL_EventType.SDL_EVENT_QUIT:
                break;
            case SDL_EventType.SDL_EVENT_TERMINATING:
                break;
            case SDL_EventType.SDL_EVENT_LOW_MEMORY:
                break;
            case SDL_EventType.SDL_EVENT_WILL_ENTER_BACKGROUND:
                break;
            case SDL_EventType.SDL_EVENT_DID_ENTER_BACKGROUND:
                break;
            case SDL_EventType.SDL_EVENT_WILL_ENTER_FOREGROUND:
                break;
            case SDL_EventType.SDL_EVENT_DID_ENTER_FOREGROUND:
                break;
            case SDL_EventType.SDL_EVENT_LOCALE_CHANGED:
                break;
            case SDL_EventType.SDL_EVENT_SYSTEM_THEME_CHANGED:
                break;
            case SDL_EventType.SDL_EVENT_DISPLAY_ORIENTATION:
                break;
            case SDL_EventType.SDL_EVENT_DISPLAY_ADDED:
                break;
            case SDL_EventType.SDL_EVENT_DISPLAY_REMOVED:
                break;
            case SDL_EventType.SDL_EVENT_DISPLAY_MOVED:
                break;
            case SDL_EventType.SDL_EVENT_DISPLAY_DESKTOP_MODE_CHANGED:
                break;
            case SDL_EventType.SDL_EVENT_DISPLAY_CURRENT_MODE_CHANGED:
                break;
            case SDL_EventType.SDL_EVENT_DISPLAY_CONTENT_SCALE_CHANGED:
                break;
            case SDL_EventType.SDL_EVENT_WINDOW_SHOWN:
                break;
            case SDL_EventType.SDL_EVENT_WINDOW_HIDDEN:
                break;
            case SDL_EventType.SDL_EVENT_WINDOW_EXPOSED:
                break;
            case SDL_EventType.SDL_EVENT_WINDOW_MOVED:
                break;
            case SDL_EventType.SDL_EVENT_WINDOW_RESIZED:
                break;
            case SDL_EventType.SDL_EVENT_WINDOW_PIXEL_SIZE_CHANGED:
                break;
            case SDL_EventType.SDL_EVENT_WINDOW_METAL_VIEW_RESIZED:
                break;
            case SDL_EventType.SDL_EVENT_WINDOW_MINIMIZED:
                break;
            case SDL_EventType.SDL_EVENT_WINDOW_MAXIMIZED:
                break;
            case SDL_EventType.SDL_EVENT_WINDOW_RESTORED:
                break;
            case SDL_EventType.SDL_EVENT_WINDOW_MOUSE_ENTER:
                break;
            case SDL_EventType.SDL_EVENT_WINDOW_MOUSE_LEAVE:
                break;
            case SDL_EventType.SDL_EVENT_WINDOW_FOCUS_GAINED:
                break;
            case SDL_EventType.SDL_EVENT_WINDOW_FOCUS_LOST:
                break;
            case SDL_EventType.SDL_EVENT_WINDOW_CLOSE_REQUESTED:
                break;
            case SDL_EventType.SDL_EVENT_WINDOW_HIT_TEST:
                break;
            case SDL_EventType.SDL_EVENT_WINDOW_ICCPROF_CHANGED:
                break;
            case SDL_EventType.SDL_EVENT_WINDOW_DISPLAY_CHANGED:
                break;
            case SDL_EventType.SDL_EVENT_WINDOW_DISPLAY_SCALE_CHANGED:
                break;
            case SDL_EventType.SDL_EVENT_WINDOW_SAFE_AREA_CHANGED:
                break;
            case SDL_EventType.SDL_EVENT_WINDOW_OCCLUDED:
                break;
            case SDL_EventType.SDL_EVENT_WINDOW_ENTER_FULLSCREEN:
                break;
            case SDL_EventType.SDL_EVENT_WINDOW_LEAVE_FULLSCREEN:
                break;
            case SDL_EventType.SDL_EVENT_WINDOW_DESTROYED:
                break;
            case SDL_EventType.SDL_EVENT_WINDOW_HDR_STATE_CHANGED:
                break;
            case SDL_EventType.SDL_EVENT_KEY_DOWN:
                break;
            case SDL_EventType.SDL_EVENT_KEY_UP:
                break;
            case SDL_EventType.SDL_EVENT_TEXT_EDITING:
                break;
            case SDL_EventType.SDL_EVENT_TEXT_INPUT:
                break;
            case SDL_EventType.SDL_EVENT_KEYMAP_CHANGED:
                break;
            case SDL_EventType.SDL_EVENT_KEYBOARD_ADDED:
                break;
            case SDL_EventType.SDL_EVENT_KEYBOARD_REMOVED:
                break;
            case SDL_EventType.SDL_EVENT_TEXT_EDITING_CANDIDATES:
                break;
            case SDL_EventType.SDL_EVENT_MOUSE_MOTION:
                break;
            case SDL_EventType.SDL_EVENT_MOUSE_BUTTON_DOWN:
                break;
            case SDL_EventType.SDL_EVENT_MOUSE_BUTTON_UP:
                break;
            case SDL_EventType.SDL_EVENT_MOUSE_WHEEL:
                break;
            case SDL_EventType.SDL_EVENT_MOUSE_ADDED:
                break;
            case SDL_EventType.SDL_EVENT_MOUSE_REMOVED:
                break;
            case SDL_EventType.SDL_EVENT_JOYSTICK_AXIS_MOTION:
                break;
            case SDL_EventType.SDL_EVENT_JOYSTICK_BALL_MOTION:
                break;
            case SDL_EventType.SDL_EVENT_JOYSTICK_HAT_MOTION:
                break;
            case SDL_EventType.SDL_EVENT_JOYSTICK_BUTTON_DOWN:
                break;
            case SDL_EventType.SDL_EVENT_JOYSTICK_BUTTON_UP:
                break;
            case SDL_EventType.SDL_EVENT_JOYSTICK_ADDED:
                break;
            case SDL_EventType.SDL_EVENT_JOYSTICK_REMOVED:
                break;
            case SDL_EventType.SDL_EVENT_JOYSTICK_BATTERY_UPDATED:
                break;
            case SDL_EventType.SDL_EVENT_JOYSTICK_UPDATE_COMPLETE:
                break;
            case SDL_EventType.SDL_EVENT_GAMEPAD_AXIS_MOTION:
                break;
            case SDL_EventType.SDL_EVENT_GAMEPAD_BUTTON_DOWN:
                break;
            case SDL_EventType.SDL_EVENT_GAMEPAD_BUTTON_UP:
                break;
            case SDL_EventType.SDL_EVENT_GAMEPAD_ADDED:
                break;
            case SDL_EventType.SDL_EVENT_GAMEPAD_REMOVED:
                break;
            case SDL_EventType.SDL_EVENT_GAMEPAD_REMAPPED:
                break;
            case SDL_EventType.SDL_EVENT_GAMEPAD_TOUCHPAD_DOWN:
                break;
            case SDL_EventType.SDL_EVENT_GAMEPAD_TOUCHPAD_MOTION:
                break;
            case SDL_EventType.SDL_EVENT_GAMEPAD_TOUCHPAD_UP:
                break;
            case SDL_EventType.SDL_EVENT_GAMEPAD_SENSOR_UPDATE:
                break;
            case SDL_EventType.SDL_EVENT_GAMEPAD_UPDATE_COMPLETE:
                break;
            case SDL_EventType.SDL_EVENT_GAMEPAD_STEAM_HANDLE_UPDATED:
                break;
            case SDL_EventType.SDL_EVENT_FINGER_DOWN:
                break;
            case SDL_EventType.SDL_EVENT_FINGER_UP:
                break;
            case SDL_EventType.SDL_EVENT_FINGER_MOTION:
                break;
            case SDL_EventType.SDL_EVENT_FINGER_CANCELED:
                break;
            case SDL_EventType.SDL_EVENT_CLIPBOARD_UPDATE:
                break;
            case SDL_EventType.SDL_EVENT_DROP_FILE:
                break;
            case SDL_EventType.SDL_EVENT_DROP_TEXT:
                break;
            case SDL_EventType.SDL_EVENT_DROP_BEGIN:
                break;
            case SDL_EventType.SDL_EVENT_DROP_COMPLETE:
                break;
            case SDL_EventType.SDL_EVENT_DROP_POSITION:
                break;
            case SDL_EventType.SDL_EVENT_AUDIO_DEVICE_ADDED:
                break;
            case SDL_EventType.SDL_EVENT_AUDIO_DEVICE_REMOVED:
                break;
            case SDL_EventType.SDL_EVENT_AUDIO_DEVICE_FORMAT_CHANGED:
                break;
            case SDL_EventType.SDL_EVENT_SENSOR_UPDATE:
                break;
            case SDL_EventType.SDL_EVENT_PEN_PROXIMITY_IN:
                break;
            case SDL_EventType.SDL_EVENT_PEN_PROXIMITY_OUT:
                break;
            case SDL_EventType.SDL_EVENT_PEN_DOWN:
                break;
            case SDL_EventType.SDL_EVENT_PEN_UP:
                break;
            case SDL_EventType.SDL_EVENT_PEN_BUTTON_DOWN:
                break;
            case SDL_EventType.SDL_EVENT_PEN_BUTTON_UP:
                break;
            case SDL_EventType.SDL_EVENT_PEN_MOTION:
                break;
            case SDL_EventType.SDL_EVENT_PEN_AXIS:
                break;
            case SDL_EventType.SDL_EVENT_CAMERA_DEVICE_ADDED:
                break;
            case SDL_EventType.SDL_EVENT_CAMERA_DEVICE_REMOVED:
                break;
            case SDL_EventType.SDL_EVENT_CAMERA_DEVICE_APPROVED:
                break;
            case SDL_EventType.SDL_EVENT_CAMERA_DEVICE_DENIED:
                break;
            case SDL_EventType.SDL_EVENT_RENDER_TARGETS_RESET:
                break;
            case SDL_EventType.SDL_EVENT_RENDER_DEVICE_RESET:
                break;
            case SDL_EventType.SDL_EVENT_RENDER_DEVICE_LOST:
                break;
            case SDL_EventType.SDL_EVENT_PRIVATE0:
                break;
            case SDL_EventType.SDL_EVENT_PRIVATE1:
                break;
            case SDL_EventType.SDL_EVENT_PRIVATE2:
                break;
            case SDL_EventType.SDL_EVENT_PRIVATE3:
                break;
            case SDL_EventType.SDL_EVENT_POLL_SENTINEL:
                break;
            case SDL_EventType.SDL_EVENT_USER:
                break;
            case SDL_EventType.SDL_EVENT_LAST:
                break;
            case SDL_EventType.SDL_EVENT_ENUM_PADDING:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    public override void DisposeResources()
    {
        if (createdSuccessfully)
            SDL.QuitSubSystem(initFlags);

        SDL.Quit();
    }

    private class Events
    {
        private const int EventsPerPeep = 64;
        private readonly SDL_Event[] events = new SDL_Event[EventsPerPeep];

        public Action<SDL_Event> HandleEvent = null!;

        public void Poll()
        {
            SDL.PumpEvents();

            int eventsRead;

            do
            {
                eventsRead = SDL.PeepEvents(events, SDL_EventAction.SDL_GETEVENT, SDL_EventType.SDL_EVENT_FIRST, SDL_EventType.SDL_EVENT_LAST);
                for (var i = 0; i < eventsRead; i++)
                    HandleEvent?.Invoke(events[i]);
            } while (eventsRead == EventsPerPeep);
        }
    }
}