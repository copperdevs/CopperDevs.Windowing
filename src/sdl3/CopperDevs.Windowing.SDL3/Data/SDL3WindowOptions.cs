using CopperDevs.Windowing.Data;

namespace CopperDevs.Windowing.SDL3.Data;

// ReSharper disable once InconsistentNaming
/// <summary>
/// Layer above <see cref="WindowOptions"/> that adds SDL specific settings
/// </summary>
/// <remarks>Can be used with <see cref="CopperDevs.Windowing.Window.Create{TWindow}()"/> or <see cref="CopperDevs.Windowing.Window.Create{TWindow}(WindowOptions)"/></remarks>
public record SDL3WindowOptions : WindowOptions
{
    /// <summary>
    /// Flags for what to initialize the window with
    /// </summary>
    public InitFlags InitFlags { get; set; } = InitFlags.Video;

    /// <summary>
    /// Flags for the window to utilize
    /// </summary>
    public WindowFlags WindowFlags { get; set; } = WindowFlags.Resizable | WindowFlags.HighPixelDensity;

    public RendererOptions RendererOptions { get; set; } = new();
    
    /// <summary>
    /// Default settings
    /// </summary>
    public new static SDL3WindowOptions Default => new();
}