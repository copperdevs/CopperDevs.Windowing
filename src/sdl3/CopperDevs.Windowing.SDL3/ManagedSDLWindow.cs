using CopperDevs.Core.Data;
using CopperDevs.Core.Utility;
using CopperDevs.Windowing.Data;
using CopperDevs.Windowing.SDL3.Data;

namespace CopperDevs.Windowing.SDL3;

/// <summary>
/// Thin layer above <see cref="SDL_Window"/> that wraps common actions (Initialization, Events, Disposing, etc.)
/// </summary>
/// <remarks>Can be used without using <see cref="SDL3Window"/>, although it's not recommended</remarks>
// ReSharper disable once InconsistentNaming
public unsafe class ManagedSDLWindow : SafeDisposable
{
    private bool createdSuccessfully;

    // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
    private readonly SDL_Window* window;
    private readonly SDLRenderer renderer;

    /// <summary>
    /// Get the direct SDL Window
    /// </summary>
    /// <returns>SDL Window pointer</returns>
    public SDL_Window* GetNativeWindow() => window;

    /// <summary>
    /// Get the SDL renderer wrapper
    /// </summary>
    /// <returns>Renderer wrapper object</returns>
    public SDLRenderer GetRenderer() => renderer;

    // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
    private readonly WindowFlags windowFlags;
    private readonly InitFlags initFlags;

    private Events events = new();

    /// <summary>
    /// Current position of the window
    /// </summary>
    public Vector2Int Position
    {
        get => SDLAPI.GetWindowPosition(window);
        set => SDLAPI.SetWindowPosition(window, value);
    }

    /// <summary>
    /// Current size of the window
    /// </summary>
    public Vector2Int Size
    {
        get => SDLAPI.GetWindowSize(window);
        set => SDLAPI.SetWindowSize(window, value);
    }

    /// <summary>
    /// Current minimum size of the window
    /// </summary>
    public Vector2Int MinimumSize
    {
        get => SDLAPI.GetWindowMinimumSize(window);
        set => SDLAPI.SetWindowMinimumSize(window, value);
    }

    /// <summary>
    /// Current maximum size of the window
    /// </summary>
    public Vector2Int MaximumSize
    {
        get => SDLAPI.GetWindowMaximumSize(window);
        set => SDLAPI.SetWindowMaximumSize(window, value);
    }


    /// <summary>
    /// Current title of the window
    /// </summary>
    public string Title
    {
        get => SDLAPI.GetWindowTitle(window);
        set => SDLAPI.SetWindowTitle(window, value);
    }

    /// <summary>
    /// Should the window be fullscreen
    /// </summary>
    public bool Fullscreen
    {
        get => SDLAPI.GetFlags(window).HasFlag(WindowFlags.Fullscreen);
        set => SDLAPI.SetFullscreen(window, value);
    }

    /// <summary>
    /// If the window should always be on top of everything else regardless of if focused or not
    /// </summary>
    public bool AlwaysOnTop
    {
        get => SDLAPI.GetFlags(window).HasFlag(WindowFlags.AlwaysOnTop);
        set => SDLAPI.SetAlwaysOnTop(window, value);
    }

    /// <summary>
    /// Is the window currently minimized
    /// </summary>
    public bool Minimized => SDLAPI.GetFlags(window).HasFlag(WindowFlags.Minimized);

    /// <summary>
    /// Is the window currently maximized
    /// </summary>
    public bool Maximized => SDLAPI.GetFlags(window).HasFlag(WindowFlags.Maximized);

    /// <summary>
    /// Is the window currently being focused
    /// </summary>
    public bool Focused => SDLAPI.GetFlags(window).HasFlag(WindowFlags.InputFocus);

    /// <summary>
    /// Is the window currently being hovered by the mouse
    /// </summary>
    public bool Hovered => SDLAPI.GetFlags(window).HasFlag(WindowFlags.MouseFocus);

    /// <summary>
    /// Callback for when an event is called
    /// </summary>
    /// <remarks>If you need the <see cref="SDL_Event"/> info, use <see cref="HandleEvent"/></remarks>
    public Action<EventType> OnEvent = null!;

    /// <summary>
    /// Callback for when an event is called and gives the events data
    /// </summary>
    public Action<EventType, SDL_Event> HandleEvent = null!;

    /// <summary>
    /// Create
    /// </summary>
    /// <param name="options">Info to use when creating the window.</param>
    /// <exception cref="InvalidOperationException">Failure to initialize SDL</exception>
    /// <remarks><see cref="SDL3WindowOptions"/> can be used instead of <see cref="WindowOptions"/> for <paramref name="options"/> to get SDL specific options</remarks>
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

        if (!(createdSuccessfully = SDLAPI.InitSubSystem(initFlags)))
        {
            throw new InvalidOperationException($"Failed to initialise SDL. Error: {SDLAPI.GetError()}");
        }

        events.HandleEvent += HandleEvents;

        window = SDLAPI.CreateWindow(options.Title, options.Size, windowFlags);
        renderer = new SDLRenderer(SDLAPI.CreateRenderer(window));
    }

    /// <summary>
    /// Poll the windows events
    /// </summary>
    public void PollEvents()
    {
        events.Poll();
    }

    private void HandleEvents(SDL_Event e)
    {
        OnEvent?.Invoke((EventType)e.type);
        HandleEvent?.Invoke((EventType)e.type, e);
    }

    /// <summary>
    /// Maximize the window 
    /// </summary>
    public void Maximize() => SDLAPI.Maximize(window);

    /// <summary>
    /// Minimize the window
    /// </summary>
    public void Minimize() => SDLAPI.Minimize(window);

    /// <summary>
    /// Flash the window
    /// </summary>
    /// <param name="untilFocus">If true, flashes the window until focused, otherwise only briefly flashes</param>
    public void Flash(bool untilFocus = true)
    {
        SDLAPI.FlashWindow(window, untilFocus ? SDL_FlashOperation.SDL_FLASH_UNTIL_FOCUSED : SDL_FlashOperation.SDL_FLASH_BRIEFLY);
    }

    /// <summary>
    /// Cancel any window flash state
    /// </summary>
    public void StopFlash()
    {
        SDLAPI.FlashWindow(window, SDL_FlashOperation.SDL_FLASH_CANCEL);
    }

    /// <summary>
    /// Disposes of the windows resources and shuts down SDL
    /// </summary>
    /// <remarks>Call <see cref="ManagedSDLWindow.Dispose"/> instead to make sure resources aren't attempted to be disposed of multiple times</remarks>
    public override void DisposeResources()
    {
        if (createdSuccessfully)
            SDLAPI.QuitSubSystem(initFlags);

        renderer.Dispose();

        SDLAPI.Quit();
    }

    private class Events
    {
        private const int EventsPerPeep = 64;
        private readonly SDL_Event[] events = new SDL_Event[EventsPerPeep];

        public Action<SDL_Event> HandleEvent = null!;

        public void Poll()
        {
            SDLAPI.PumpEvents();

            int eventsRead;

            do
            {
                eventsRead = SDLAPI.PeepEvents(events, SDL_EventAction.SDL_GETEVENT, SDL_EventType.SDL_EVENT_FIRST, SDL_EventType.SDL_EVENT_LAST);
                for (var i = 0; i < eventsRead; i++)
                    HandleEvent?.Invoke(events[i]);
            } while (eventsRead == EventsPerPeep);
        }
    }
}