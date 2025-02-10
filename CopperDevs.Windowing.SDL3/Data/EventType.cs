#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace CopperDevs.Windowing.SDL3.Data;

/// <summary>
/// Wrapper for <see cref="SDL_EventType"/>
/// </summary>
public enum EventType
{
    First = SDL_EventType.SDL_EVENT_FIRST,
    Quit = SDL_EventType.SDL_EVENT_QUIT,
    Terminating = SDL_EventType.SDL_EVENT_TERMINATING,
    LowMemory = SDL_EventType.SDL_EVENT_LOW_MEMORY,
    WillEnterBackground = SDL_EventType.SDL_EVENT_WILL_ENTER_BACKGROUND,
    DidEnterBackground = SDL_EventType.SDL_EVENT_DID_ENTER_BACKGROUND,
    WillEnterForeground = SDL_EventType.SDL_EVENT_WILL_ENTER_FOREGROUND,
    DidEnterForeground = SDL_EventType.SDL_EVENT_DID_ENTER_FOREGROUND,
    LocaleChanged = SDL_EventType.SDL_EVENT_LOCALE_CHANGED,
    SystemThemeChanged = SDL_EventType.SDL_EVENT_SYSTEM_THEME_CHANGED,
    DisplayFirst = SDL_EventType.SDL_EVENT_DISPLAY_FIRST,
    DisplayOrientation = SDL_EventType.SDL_EVENT_DISPLAY_ORIENTATION,
    DisplayAdded = SDL_EventType.SDL_EVENT_DISPLAY_ADDED,
    DisplayRemoved = SDL_EventType.SDL_EVENT_DISPLAY_REMOVED,
    DisplayMoved = SDL_EventType.SDL_EVENT_DISPLAY_MOVED,
    DisplayDesktopModeChanged = SDL_EventType.SDL_EVENT_DISPLAY_DESKTOP_MODE_CHANGED,
    DisplayCurrentModeChanged = SDL_EventType.SDL_EVENT_DISPLAY_CURRENT_MODE_CHANGED,
    DisplayContentScaleChanged = SDL_EventType.SDL_EVENT_DISPLAY_CONTENT_SCALE_CHANGED,
    DisplayLast = SDL_EventType.SDL_EVENT_DISPLAY_LAST,
    WindowFirst = SDL_EventType.SDL_EVENT_WINDOW_FIRST,
    WindowShown = SDL_EventType.SDL_EVENT_WINDOW_SHOWN,
    WindowHidden = SDL_EventType.SDL_EVENT_WINDOW_HIDDEN,
    WindowExposed = SDL_EventType.SDL_EVENT_WINDOW_EXPOSED,
    WindowMoved = SDL_EventType.SDL_EVENT_WINDOW_MOVED,
    WindowResized = SDL_EventType.SDL_EVENT_WINDOW_RESIZED,
    WindowPixelSizeChanged = SDL_EventType.SDL_EVENT_WINDOW_PIXEL_SIZE_CHANGED,
    WindowMetalViewResized = SDL_EventType.SDL_EVENT_WINDOW_METAL_VIEW_RESIZED,
    WindowMinimized = SDL_EventType.SDL_EVENT_WINDOW_MINIMIZED,
    WindowMaximized = SDL_EventType.SDL_EVENT_WINDOW_MAXIMIZED,
    WindowRestored = SDL_EventType.SDL_EVENT_WINDOW_RESTORED,
    WindowMouseEnter = SDL_EventType.SDL_EVENT_WINDOW_MOUSE_ENTER,
    WindowMouseLeave = SDL_EventType.SDL_EVENT_WINDOW_MOUSE_LEAVE,
    WindowFocusGained = SDL_EventType.SDL_EVENT_WINDOW_FOCUS_GAINED,
    WindowFocusLost = SDL_EventType.SDL_EVENT_WINDOW_FOCUS_LOST,
    WindowCloseRequested = SDL_EventType.SDL_EVENT_WINDOW_CLOSE_REQUESTED,
    WindowHitTest = SDL_EventType.SDL_EVENT_WINDOW_HIT_TEST,
    // ReSharper disable once InconsistentNaming
    WindowICCProfChanged = SDL_EventType.SDL_EVENT_WINDOW_ICCPROF_CHANGED,
    WindowDisplayChanged = SDL_EventType.SDL_EVENT_WINDOW_DISPLAY_CHANGED,
    WindowDisplayScaleChanged = SDL_EventType.SDL_EVENT_WINDOW_DISPLAY_SCALE_CHANGED,
    WindowSafeAreaChanged = SDL_EventType.SDL_EVENT_WINDOW_SAFE_AREA_CHANGED,
    WindowOccluded = SDL_EventType.SDL_EVENT_WINDOW_OCCLUDED,
    WindowEnterFullscreen = SDL_EventType.SDL_EVENT_WINDOW_ENTER_FULLSCREEN,
    WindowLeaveFullscreen = SDL_EventType.SDL_EVENT_WINDOW_LEAVE_FULLSCREEN,
    WindowDestroyed = SDL_EventType.SDL_EVENT_WINDOW_DESTROYED,
    WindowHdrStateChanged = SDL_EventType.SDL_EVENT_WINDOW_HDR_STATE_CHANGED,
    WindowLast = SDL_EventType.SDL_EVENT_WINDOW_LAST,
    KeyDown = SDL_EventType.SDL_EVENT_KEY_DOWN,
    KeyUp = SDL_EventType.SDL_EVENT_KEY_UP,
    TextEditing = SDL_EventType.SDL_EVENT_TEXT_EDITING,
    TextInput = SDL_EventType.SDL_EVENT_TEXT_INPUT,
    KeymapChanged = SDL_EventType.SDL_EVENT_KEYMAP_CHANGED,
    KeyboardAdded = SDL_EventType.SDL_EVENT_KEYBOARD_ADDED,
    KeyboardRemoved = SDL_EventType.SDL_EVENT_KEYBOARD_REMOVED,
    TextEditingCandidates = SDL_EventType.SDL_EVENT_TEXT_EDITING_CANDIDATES,
    MouseMotion = SDL_EventType.SDL_EVENT_MOUSE_MOTION,
    MouseButtonDown = SDL_EventType.SDL_EVENT_MOUSE_BUTTON_DOWN,
    MouseButtonUp = SDL_EventType.SDL_EVENT_MOUSE_BUTTON_UP,
    MouseWheel = SDL_EventType.SDL_EVENT_MOUSE_WHEEL,
    MouseAdded = SDL_EventType.SDL_EVENT_MOUSE_ADDED,
    MouseRemoved = SDL_EventType.SDL_EVENT_MOUSE_REMOVED,
    JoystickAxisMotion = SDL_EventType.SDL_EVENT_JOYSTICK_AXIS_MOTION,
    JoystickBallMotion = SDL_EventType.SDL_EVENT_JOYSTICK_BALL_MOTION,
    JoystickHatMotion = SDL_EventType.SDL_EVENT_JOYSTICK_HAT_MOTION,
    JoystickButtonDown = SDL_EventType.SDL_EVENT_JOYSTICK_BUTTON_DOWN,
    JoystickButtonUp = SDL_EventType.SDL_EVENT_JOYSTICK_BUTTON_UP,
    JoystickAdded = SDL_EventType.SDL_EVENT_JOYSTICK_ADDED,
    JoystickRemoved = SDL_EventType.SDL_EVENT_JOYSTICK_REMOVED,
    JoystickBatteryUpdated = SDL_EventType.SDL_EVENT_JOYSTICK_BATTERY_UPDATED,
    JoystickUpdateComplete = SDL_EventType.SDL_EVENT_JOYSTICK_UPDATE_COMPLETE,
    GamepadAxisMotion = SDL_EventType.SDL_EVENT_GAMEPAD_AXIS_MOTION,
    GamepadButtonDown = SDL_EventType.SDL_EVENT_GAMEPAD_BUTTON_DOWN,
    GamepadButtonUp = SDL_EventType.SDL_EVENT_GAMEPAD_BUTTON_UP,
    GamepadAdded = SDL_EventType.SDL_EVENT_GAMEPAD_ADDED,
    GamepadRemoved = SDL_EventType.SDL_EVENT_GAMEPAD_REMOVED,
    GamepadRemapped = SDL_EventType.SDL_EVENT_GAMEPAD_REMAPPED,
    GamepadTouchpadDown = SDL_EventType.SDL_EVENT_GAMEPAD_TOUCHPAD_DOWN,
    GamepadTouchpadMotion = SDL_EventType.SDL_EVENT_GAMEPAD_TOUCHPAD_MOTION,
    GamepadTouchpadUp = SDL_EventType.SDL_EVENT_GAMEPAD_TOUCHPAD_UP,
    GamepadSensorUpdate = SDL_EventType.SDL_EVENT_GAMEPAD_SENSOR_UPDATE,
    GamepadUpdateComplete = SDL_EventType.SDL_EVENT_GAMEPAD_UPDATE_COMPLETE,
    GamepadSteamHandleUpdated = SDL_EventType.SDL_EVENT_GAMEPAD_STEAM_HANDLE_UPDATED,
    FingerDown = SDL_EventType.SDL_EVENT_FINGER_DOWN,
    FingerUp = SDL_EventType.SDL_EVENT_FINGER_UP,
    FingerMotion = SDL_EventType.SDL_EVENT_FINGER_MOTION,
    FingerCanceled = SDL_EventType.SDL_EVENT_FINGER_CANCELED,
    ClipboardUpdate = SDL_EventType.SDL_EVENT_CLIPBOARD_UPDATE,
    DropFile = SDL_EventType.SDL_EVENT_DROP_FILE,
    DropText = SDL_EventType.SDL_EVENT_DROP_TEXT,
    DropBegin = SDL_EventType.SDL_EVENT_DROP_BEGIN,
    DropComplete = SDL_EventType.SDL_EVENT_DROP_COMPLETE,
    DropPosition = SDL_EventType.SDL_EVENT_DROP_POSITION,
    AudioDeviceAdded = SDL_EventType.SDL_EVENT_AUDIO_DEVICE_ADDED,
    AudioDeviceRemoved = SDL_EventType.SDL_EVENT_AUDIO_DEVICE_REMOVED,
    AudioDeviceFormatChanged = SDL_EventType.SDL_EVENT_AUDIO_DEVICE_FORMAT_CHANGED,
    SensorUpdate = SDL_EventType.SDL_EVENT_SENSOR_UPDATE,
    PenProximityIn = SDL_EventType.SDL_EVENT_PEN_PROXIMITY_IN,
    PenProximityOut = SDL_EventType.SDL_EVENT_PEN_PROXIMITY_OUT,
    PenDown = SDL_EventType.SDL_EVENT_PEN_DOWN,
    PenUp = SDL_EventType.SDL_EVENT_PEN_UP,
    PenButtonDown = SDL_EventType.SDL_EVENT_PEN_BUTTON_DOWN,
    PenButtonUp = SDL_EventType.SDL_EVENT_PEN_BUTTON_UP,
    PenMotion = SDL_EventType.SDL_EVENT_PEN_MOTION,
    PenAxis = SDL_EventType.SDL_EVENT_PEN_AXIS,
    CameraDeviceAdded = SDL_EventType.SDL_EVENT_CAMERA_DEVICE_ADDED,
    CameraDeviceRemoved = SDL_EventType.SDL_EVENT_CAMERA_DEVICE_REMOVED,
    CameraDeviceApproved = SDL_EventType.SDL_EVENT_CAMERA_DEVICE_APPROVED,
    CameraDeviceDenied = SDL_EventType.SDL_EVENT_CAMERA_DEVICE_DENIED,
    RenderTargetsReset = SDL_EventType.SDL_EVENT_RENDER_TARGETS_RESET,
    RenderDeviceReset = SDL_EventType.SDL_EVENT_RENDER_DEVICE_RESET,
    RenderDeviceLost = SDL_EventType.SDL_EVENT_RENDER_DEVICE_LOST,
    Private0 = SDL_EventType.SDL_EVENT_PRIVATE0,
    Private1 = SDL_EventType.SDL_EVENT_PRIVATE1,
    Private2 = SDL_EventType.SDL_EVENT_PRIVATE2,
    Private3 = SDL_EventType.SDL_EVENT_PRIVATE3,
    PollSentinel = SDL_EventType.SDL_EVENT_POLL_SENTINEL,
    User = SDL_EventType.SDL_EVENT_USER,
    Last = SDL_EventType.SDL_EVENT_LAST,
    EnumPadding = SDL_EventType.SDL_EVENT_ENUM_PADDING,
}