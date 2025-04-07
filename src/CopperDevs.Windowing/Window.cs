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
    /// Create a new window with a user provided <see cref="WindowOptions"/>
    /// </summary>
    /// <typeparam name="TWindow">The type of window to create</typeparam>
    /// <param name="options">Custom options for the window to be created with</param>
    /// <returns>The created window</returns>
    public static TWindow Create<TWindow>(WindowOptions options) where TWindow : Window, new()
    {
        return (TWindow)Create(typeof(TWindow), options);
    }

    /// <summary>
    /// Create a new window with <see cref="WindowOptions.Default"/>
    /// </summary>
    /// <param name="windowType">Type of the window class that derives from <see cref="Window"/></param>
    /// <returns>Created window class as <see cref="Window"/></returns>
    public static Window Create(Type windowType) => Create(windowType, WindowOptions.Default);

    /// <summary>
    /// Create a new window with a user provided <see cref="WindowOptions"/>
    /// </summary>
    /// <param name="windowType">Type of the window class that derives from <see cref="Window"/></param>
    /// <param name="options">Custom options for the window to be created with</param>
    /// <returns>The created window</returns>
    public static Window Create(Type windowType, WindowOptions options)
    {
        var window = (Window)Activator.CreateInstance(windowType)!;
        window.Options = options;

        window.CreateWindow(window.Options);

        CreatedWindows.Add(window);

        return window;
    }
}
