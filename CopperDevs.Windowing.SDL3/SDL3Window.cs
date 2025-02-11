using CopperDevs.Core.Data;
using CopperDevs.Core.Utility;
using CopperDevs.Windowing.Data;
using CopperDevs.Windowing.SDL3.Data;

namespace CopperDevs.Windowing.SDL3;

// ReSharper disable once InconsistentNaming
/// <summary>
/// Base window to be used with <see cref="CopperDevs.Windowing.Window"/>
/// </summary>
/// <remarks>Can be created with <see cref="CopperDevs.Windowing.Window.CreateWindow"/></remarks>
public class SDL3Window : Window
{
    private ManagedSDLWindow window = null!;

    /// <summary>
    /// Get the managed SDL window wrapper
    /// </summary>
    /// <returns>Window object</returns>
    // ReSharper disable once InconsistentNaming
    public ManagedSDLWindow GetManagedSDLWindow() => window;

    /// <summary>
    /// Get the managed SDL renderer wrapper
    /// </summary>
    /// <returns>Renderer wrapper object</returns>
    public SDLRenderer GetRenderer() => window.GetRenderer();

    /// <summary>
    /// Disposes of the windows resources and shuts down SDL
    /// </summary>
    /// <remarks>Call <see cref="Window.Dispose"/> instead to make sure resources aren't attempted to be disposed of multiple times, and to fully shut down the windowing system correctly</remarks>
    public override void DisposeResources()
    {
        window.Dispose();
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    protected override Vector2Int GetWindowSize() => window.Size;
    protected override void SetWindowSize(Vector2Int size) => window.Size = size;
    protected override Vector2Int GetWindowMaximumSize() => window.MaximumSize;
    protected override void SetWindowMaximumSize(Vector2Int size) => window.MaximumSize = size;
    protected override Vector2Int GetWindowMinimumSize() => window.MinimumSize;
    protected override void SetWindowMinimumSize(Vector2Int size) => window.MinimumSize = size;
    protected override Vector2Int GetWindowPosition() => window.Position;
    protected override void SetWindowPosition(Vector2Int position) => window.Position = position;
    protected override string GetWindowTitle() => window.Title;
    protected override void SetWindowTitle(string title) => window.Title = title;
    protected override void SetFullscreen(bool fullscreen) => window.Fullscreen = fullscreen;
    protected override bool GetFullscreen() => window.Fullscreen;
    protected override void SetAlwaysOnTop(bool alwaysOnTop) => window.AlwaysOnTop = alwaysOnTop;
    protected override bool GetAlwaysOnTop() => window.AlwaysOnTop;
    protected override bool GetMinimized() => window.Minimized;
    protected override void SetMinimize() => window.Minimize();
    protected override bool GetMaximized() => window.Maximized;
    protected override void SetMaximize() => window.Maximize();
    protected override bool GetFocused() => window.Focused;
    protected override bool GetHovered() => window.Hovered;
    protected override double GetTotalTime() => totalTime;
    protected override double GetDeltaTime() => deltaTime;

    protected override unsafe void ConnectWindowEvents()
    {
        fixed (byte* pointerPointer = SDL_PROP_WINDOW_WIN32_HWND_POINTER)
        {
            var pointer = SDL_GetPointerProperty(SDL_GetWindowProperties(window.GetNativeWindow()), pointerPointer, (IntPtr)null);

            WindowsApi.RegisterWindow(pointer);
            WindowsApi.OnWindowResize += _ => RenderWindow();
        }
    }

    protected override void WindowFlash(bool untilFocus = true) => window.Flash(untilFocus);
    protected override void StopWindowFlash() => window.StopFlash();
    
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    protected override IInput CreateInput()
    {
        return new SDLInput();
    }

    /// <summary>
    /// Create the window
    /// </summary>
    /// <param name="options">Window starting options</param>
    /// <remarks>Use <see cref="CopperDevs.Windowing.Window.Create{TWindow}()"/> or <see cref="CopperDevs.Windowing.Window.Create{TWindow}(WindowOptions)"/> instead to properly set up the windowing system</remarks>
    protected override void CreateWindow(WindowOptions options)
    {
        SDL.SetHint(SDL_HINT_WINDOWS_CLOSE_ON_ALT_F4, "null byte \0 in string"u8);

        SDL.SetHint(SDL_HINT_WINDOWS_CLOSE_ON_ALT_F4, "1"u8);
        SDL.SetHint(SDL_HINT_WINDOWS_CLOSE_ON_ALT_F4, "1");

        window = new ManagedSDLWindow(options);
        window.HandleEvent += EventsHandler;
    }

    /// <summary>
    /// Starts the window updating process
    /// </summary>
    /// <remarks>It's not recommended to call this directly, rather to let the windowing system call it</remarks>
    protected override void StartWindowUpdate()
    {
        deltaTimeStartTime = totalTime;

        window.Update();
    }

    /// <summary>
    /// Ends the window updating process
    /// </summary>
    /// <remarks>It's not recommended to call this directly, rather to let the windowing system call it</remarks>
    protected override void StopWindowUpdate()
    {
        deltaTime = totalTime - deltaTimeStartTime;
    }

    // ReSharper disable once InconsistentNaming
    private double totalTime => SDL.GetTicks() / (double)1000;
    private double deltaTime;
    private double deltaTimeStartTime;

    /// <summary>
    /// Disposes of the window
    /// </summary>
    /// <remarks>It's not recommended to call this directly, rather to let the windowing system call it</remarks>
    protected override void DestroyWindow()
    {
        Dispose();
    }

    private void EventsHandler(EventType type, SDL_Event e)
    {
        // ReSharper disable once SwitchStatementMissingSomeEnumCasesNoDefault
        // ReSharper disable once ConvertSwitchStatementToSwitchExpression
        switch (type)
        {
            case EventType.Quit:
                ShouldRun = false;
                break;
        }
    }
}