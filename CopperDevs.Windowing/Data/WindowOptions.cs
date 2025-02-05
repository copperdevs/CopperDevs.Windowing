using CopperDevs.Core.Data;

namespace CopperDevs.Windowing.Data;

public record class WindowOptions
{
    public WindowOptions()
    {
    }

    public Vector2Int Size { get; set; } = new(1150, 680);
    public string Title { get; set; } = "Untitled Window";
    
    public static WindowOptions Default => new();
}