using CopperDevs.Core.Data;
using CopperDevs.Core.Utility;
using CopperDevs.Windowing.Data;
using CopperDevs.Windowing.SDL3.Data;

namespace CopperDevs.Windowing.SDL3;

/// <summary>
/// Thing layer above <see cref="SDL_Window"/> that wraps common actions (Initialization, Events,Disposing, etc.)
/// </summary>
/// <remarks>Can be used without using <see cref="SDL3Window"/>, although its not recommended</remarks>
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
    /// Get the size of the window
    /// </summary>
    public Vector2Int Size => SDL.GetWindowSize(window);

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
    /// Called when updating the window, after events are polled
    /// </summary>
    public Action OnUpdate = null!;

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

        if (!(createdSuccessfully = SDL.InitSubSystem(initFlags)))
        {
            throw new InvalidOperationException($"Failed to initialise SDL. Error: {SDL.GetError()}");
        }

        events.HandleEvent += HandleEvents;

        window = SDL.CreateWindow(options.Title, options.Size, windowFlags);
        renderer = new SDLRenderer(SDL.CreateRenderer(window));
    }

    /// <summary>
    /// Update the window
    /// </summary>
    public void Update()
    {
        events.Poll();
        OnUpdate?.Invoke();
    }

    private void HandleEvents(SDL_Event e)
    {
        OnEvent?.Invoke((EventType)e.type);
        HandleEvent?.Invoke((EventType)e.type, e);
    }

    /// <summary>
    /// Disposes of the windows resources and shuts down SDL
    /// </summary>
    /// <remarks>Call <see cref="ManagedSDLWindow.Dispose"/> instead to make sure resources aren't attempted to be disposed of multiple times</remarks>
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