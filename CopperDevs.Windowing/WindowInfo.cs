using CopperDevs.Core.Data;
using CopperDevs.Windowing.Data;

namespace CopperDevs.Windowing;

public partial class Window
{
    internal WindowOptions Options = null!;

    /// <summary>
    /// Current position of the window
    /// </summary>
    public Vector2Int Position
    {
        get => GetWindowPosition();
        set => SetWindowPosition(value);
    }
    
    /// <summary>
    /// Current size of the window
    /// </summary>
    public Vector2Int Size
    {
        get => GetWindowSize();
        set => SetWindowSize(value);
    }

    /// <summary>
    /// Current minimum size of the window
    /// </summary>
    public Vector2Int MinimumSize
    {
        get => GetWindowMinimumSize();
        set => SetWindowMinimumSize(value);
    }

    /// <summary>
    /// Current maximum size of the window
    /// </summary>
    public Vector2Int MaximumSize
    {
        get => GetWindowMaximumSize();
        set => SetWindowMaximumSize(value);
    }

    /// <summary>
    /// Get the total time the window has been open
    /// </summary>
    public double TotalTime => GetTotalTime();

    /// <summary>
    /// Get the current frames delta time
    /// </summary>
    public double DeltaTime => GetDeltaTime();

    /// <summary>
    /// Current title of the window
    /// </summary>
    public string Title
    {
        get => GetWindowTitle();
        set => SetWindowTitle(value);
    }

    /// <summary>
    /// If the window should always be on top of everything else regardless of if focused or not
    /// </summary>
    public bool AlwaysOnTop
    {
        set => SetAlwaysOnTop(value);
        get => GetAlwaysOnTop();
    }

    /// <summary>
    /// Should the window be fullscreen
    /// </summary>
    public bool FullScreen
    {
        get => GetFullscreen();
        set => SetFullscreen(value);
    }

    /// <summary>
    /// Is the window currently minimized
    /// </summary>
    public bool Minimized => GetMinimized();

    /// <summary>
    /// Is the window currently maximized
    /// </summary>
    public bool Maximized => GetMaximized();

    /// <summary>
    /// Is the window currently being focused
    /// </summary>
    public bool Focused => GetFocused();

    /// <summary>
    /// Is the window currently being hovered by the mouse
    /// </summary>
    public bool Hovered => GetHovered();
    
    /// <summary>
    /// Maximize the window 
    /// </summary>
    public void Maximize() => SetMaximize();

    /// <summary>
    /// Minimize the window
    /// </summary>
    public void Minimize() => SetMinimize();

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    // time
    protected abstract double GetTotalTime();
    protected abstract double GetDeltaTime();

    // size
    protected abstract Vector2Int GetWindowSize();
    protected abstract void SetWindowSize(Vector2Int size);

    // max size
    protected abstract Vector2Int GetWindowMaximumSize();
    protected abstract void SetWindowMaximumSize(Vector2Int size);

    // min size
    protected abstract Vector2Int GetWindowMinimumSize();
    protected abstract void SetWindowMinimumSize(Vector2Int size);

    // pos
    protected abstract Vector2Int GetWindowPosition();
    protected abstract void SetWindowPosition(Vector2Int position);

    // title
    protected abstract string GetWindowTitle();
    protected abstract void SetWindowTitle(string title);

    // full screen
    protected abstract void SetFullscreen(bool fullscreen);
    protected abstract bool GetFullscreen();

    // always on top
    protected abstract void SetAlwaysOnTop(bool alwaysOnTop);
    protected abstract bool GetAlwaysOnTop();

    // minimized
    protected abstract bool GetMinimized();
    protected abstract void SetMinimize();

    // maximized
    protected abstract bool GetMaximized();
    protected abstract void SetMaximize();

    // focus
    protected abstract bool GetFocused();
    protected abstract bool GetHovered();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}