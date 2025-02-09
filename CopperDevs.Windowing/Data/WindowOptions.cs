using CopperDevs.Core.Data;

namespace CopperDevs.Windowing.Data;

public record WindowOptions
{
    public Vector2Int Size { get; set; } = new(1150, 680);
    public string Title { get; set; } = "Untitled Window";

    public bool WindowsApiResizeCallback = false;

    public static WindowOptions Default => new();
}