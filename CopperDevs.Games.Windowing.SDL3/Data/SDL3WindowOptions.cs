using CopperDevs.Games.Windowing.Data;

namespace CopperDevs.Games.Windowing.SDL3.Data;

// ReSharper disable once InconsistentNaming
public record class SDL3WindowOptions : WindowOptions
{
    public InitFlags InitFlags { get; set; } = InitFlags.Video;
    public WindowFlags WindowFlags { get; set; } = WindowFlags.Resizable | WindowFlags.Hidden;
    
    public new static SDL3WindowOptions Default => new();
}