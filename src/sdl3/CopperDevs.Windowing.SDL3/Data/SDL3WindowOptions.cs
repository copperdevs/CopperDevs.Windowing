using CopperDevs.Windowing.Data;
using Hexa.NET.SDL3;

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
    public SDLInitFlags InitFlags { get; set; } = SDLInitFlags.Video;

    /// <summary>
    /// Flags for the window to utilize
    /// </summary>
    public SDLWindowFlags WindowFlags { get; set; } = SDLWindowFlags.Resizable | SDLWindowFlags.HighPixelDensity;

    /// <summary>
    /// Default settings
    /// </summary>
    public new static SDL3WindowOptions Default => new();
}