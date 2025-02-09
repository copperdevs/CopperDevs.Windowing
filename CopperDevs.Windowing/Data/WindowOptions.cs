using CopperDevs.Core.Data;

namespace CopperDevs.Windowing.Data;

/// <summary>
/// Base window creation options
/// </summary>
/// <remarks>Can be used with <see cref="CopperDevs.Windowing.Window.Create{TWindow}()"/> or <see cref="CopperDevs.Windowing.Window.Create{TWindow}(WindowOptions)"/></remarks>
public record WindowOptions
{
    /// <summary>
    /// Starting size of the window on creation
    /// </summary>
    public Vector2Int Size = new(1150, 680);
    
    /// <summary>
    /// Starting title of the window on creation
    /// </summary>
    public string Title = "Untitled Window";

    /// <summary>
    /// Should the window rendering function be called via the Win32 api when the window resizes
    /// </summary>
    /// <remarks>Only available on Windows</remarks>
    public bool WindowsApiResizeCallback = false;

    /// <summary>
    /// Default settings
    /// </summary>
    public static WindowOptions Default => new();
}