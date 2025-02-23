using CopperDevs.Windowing.Data;

namespace CopperDevs.Windowing;

/// <summary>
/// Base window
/// </summary>
public partial class Window
{
    /// <summary>
    /// All created windows
    /// </summary>
    protected static readonly List<Window> CreatedWindows = [];
    
    /// <summary>
    /// Create a new window with <see cref="WindowOptions.Default"/>
    /// </summary>
    /// <typeparam name="TWindow">The type of window to create</typeparam>
    /// <returns>The created window</returns>
    public static TWindow Create<TWindow>() where TWindow : Window, new() => Create<TWindow>(WindowOptions.Default);

    /// <summary>
    /// Create a new window with <see cref="WindowOptions.Default"/>
    /// </summary>
    /// <param name="options">Custom options for the window to be created with</param>
    /// <typeparam name="TWindow">The type of window to create</typeparam>
    /// <returns>The created window</returns>
    public static TWindow Create<TWindow>(WindowOptions options) where TWindow : Window, new()
    {
        var window = new TWindow();
        window.Options = options;

        window.CreateWindow(window.Options);

        CreatedWindows.Add(window);
        
        return window;
    }
}