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
    private readonly SDLWindow* window;

    /// <summary>
    /// Get the direct SDL Window
    /// </summary>
    /// <returns>SDL Window pointer</returns>
    public SDLWindow* GetNativeWindow() => window;

    // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
    private readonly SDLWindowFlags windowFlags;
    private readonly SDLInitFlags initFlags;

    private Events events = new();

    /// <summary>
    /// Current position of the window
    /// </summary>
    public Vector2Int Position
    {
        get
        {
            var vector = new Vector2Int();
            NativeSDL.GetWindowPosition(window, ref vector.X, ref vector.Y);
            return vector;
        }
        set => NativeSDL.SetWindowPosition(window, value.X, value.Y);
    }

    /// <summary>
    /// Current size of the window
    /// </summary>
    public Vector2Int Size
    {
        get
        {
            var vector = new Vector2Int();
            NativeSDL.GetWindowSize(window, ref vector.X, ref vector.Y);
            return vector;
        }
        set => NativeSDL.SetWindowSize(window, value.X, value.Y);
    }

    /// <summary>
    /// Current minimum size of the window
    /// </summary>
    public Vector2Int MinimumSize
    {
        get
        {
            var vector = new Vector2Int();
            NativeSDL.GetWindowMinimumSize(window, ref vector.X, ref vector.Y);
            return vector;
        }
        set => NativeSDL.SetWindowMinimumSize(window, value.X, value.Y);
    }

    /// <summary>
    /// Current maximum size of the window
    /// </summary>
    public Vector2Int MaximumSize
    {
        get
        {
            var vector = new Vector2Int();
            NativeSDL.GetWindowMaximumSize(window, ref vector.X, ref vector.Y);
            return vector;
        }
        set => NativeSDL.SetWindowMaximumSize(window, value.X, value.Y);
    }


    /// <summary>
    /// Current title of the window
    /// </summary>
    public string Title
    {
        get => NativeSDL.GetWindowTitle(window)->ToString();
        set => NativeSDL.SetWindowTitle(window, value);
    }

    /// <summary>
    /// Should the window be fullscreen
    /// </summary>
    public bool Fullscreen
    {
        get => NativeSDL.GetWindowFlags(window).HasFlag(SDLWindowFlags.Fullscreen);
        set => NativeSDL.SetWindowFullscreen(window, value);
    }

    /// <summary>
    /// If the window should always be on top of everything else regardless of if focused or not
    /// </summary>
    public bool AlwaysOnTop
    {
        get => NativeSDL.GetWindowFlags(window).HasFlag(SDLWindowFlags.AlwaysOnTop);
        set => NativeSDL.SetWindowAlwaysOnTop(window, value);
    }

    /// <summary>
    /// Is the window currently minimized
    /// </summary>
    public bool Minimized => NativeSDL.GetWindowFlags(window).HasFlag(SDLWindowFlags.Minimized);

    /// <summary>
    /// Is the window currently maximized
    /// </summary>
    public bool Maximized => NativeSDL.GetWindowFlags(window).HasFlag(SDLWindowFlags.Maximized);

    /// <summary>
    /// Is the window currently being focused
    /// </summary>
    public bool Focused => NativeSDL.GetWindowFlags(window).HasFlag(SDLWindowFlags.InputFocus);

    /// <summary>
    /// Is the window currently being hovered by the mouse
    /// </summary>
    public bool Hovered => NativeSDL.GetWindowFlags(window).HasFlag(SDLWindowFlags.MouseFocus);

    /// <summary>
    /// Callback for when an event is called
    /// </summary>
    /// <remarks>If you need the <see cref="SDLEvent"/> info, use <see cref="HandleEvent"/></remarks>
    public Action<SDLEventType> OnEvent = null!;

    /// <summary>
    /// Callback for when an event is called and gives the events data
    /// </summary>
    public Action<SDLEventType, SDLEvent> HandleEvent = null!;

    /// <summary>
    /// Create
    /// </summary>
    /// <param name="options">Info to use when creating the window.</param>
    /// <exception cref="InvalidOperationException">Failure to initialize SDL</exception>
    /// <remarks><see cref="SDL3WindowOptions"/> can be used instead of <see cref="WindowOptions"/> for <paramref name="options"/> to get SDL specific options</remarks>
    public ManagedSDLWindow(WindowOptions options)
    {
        initFlags = SDLInitFlags.Video;
        windowFlags = SDLWindowFlags.Resizable | SDLWindowFlags.Hidden;

        if (options.GetType() == typeof(SDL3WindowOptions))
        {
            initFlags = ((SDL3WindowOptions)options).InitFlags;
            windowFlags = ((SDL3WindowOptions)options).WindowFlags;
        }

        if (!(createdSuccessfully = NativeSDL.InitSubSystem(initFlags)))
        {
            throw new InvalidOperationException($"Failed to initialise SDL. Error: {NativeSDL.GetError()->ToString()}");
        }

        events.HandleEvent += HandleEvents;

        window = NativeSDL.CreateWindow(options.Title, options.Size.X, options.Size.Y, windowFlags);
    }

    /// <summary>
    /// Poll the windows events
    /// </summary>
    public void PollEvents()
    {
        events.Poll();
    }

    private void HandleEvents(SDLEvent e)
    {
        OnEvent?.Invoke((SDLEventType)e.Type);
        HandleEvent?.Invoke((SDLEventType)e.Type, e);
    }

    /// <summary>
    /// Maximize the window 
    /// </summary>
    public void Maximize() => NativeSDL.MaximizeWindow(window);

    /// <summary>
    /// Minimize the window
    /// </summary>
    public void Minimize() => NativeSDL.MinimizeWindow(window);

    /// <summary>
    /// Flash the window
    /// </summary>
    /// <param name="untilFocus">If true, flashes the window until focused, otherwise only briefly flashes</param>
    public void Flash(bool untilFocus = true)
    {
        NativeSDL.FlashWindow(window, untilFocus ? SDLFlashOperation.UntilFocused : SDLFlashOperation.Briefly);
    }

    /// <summary>
    /// Cancel any window flash state
    /// </summary>
    public void StopFlash()
    {
        NativeSDL.FlashWindow(window, SDLFlashOperation.Cancel);
    }

    /// <summary>
    /// Disposes of the windows resources and shuts down SDL
    /// </summary>
    /// <remarks>Call <see cref="ManagedSDLWindow.Dispose"/> instead to make sure resources aren't attempted to be disposed of multiple times</remarks>
    public override void DisposeResources()
    {
        if (createdSuccessfully)
            NativeSDL.QuitSubSystem(initFlags);

        NativeSDL.Quit();
    }

    private class Events
    {
        public Action<SDLEvent> HandleEvent = null!;

        public void Poll()
        {
            SDLEvent sdlEvent = default;

            NativeSDL.PumpEvents();

            while (NativeSDL.PollEvent(ref sdlEvent))
            {
                HandleEvent?.Invoke(sdlEvent);
            }
        }
    }
}