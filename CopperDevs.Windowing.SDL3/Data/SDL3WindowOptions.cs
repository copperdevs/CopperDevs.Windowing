using CopperDevs.Windowing.Data;

namespace CopperDevs.Windowing.SDL3.Data;

// ReSharper disable once InconsistentNaming
public record SDL3WindowOptions : WindowOptions
{
    public InitFlags InitFlags { get; set; } = InitFlags.Video;
    public WindowFlags WindowFlags { get; set; } = WindowFlags.Resizable | WindowFlags.HighPixelDensity;

    public new static SDL3WindowOptions Default => new();
}