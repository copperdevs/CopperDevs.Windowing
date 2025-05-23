using CopperDevs.Core.Data;
using CopperDevs.Core.Utility;

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
    /// Delay in milliseconds between each frame render
    /// </summary>
    public Optional<int> FrameRenderDelay = new(10);

    /// <summary>
    /// Default settings
    /// </summary>
    public static WindowOptions Default => new();
}
