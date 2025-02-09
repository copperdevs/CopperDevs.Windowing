using CopperDevs.Core.Data;
using CopperDevs.Windowing.Data;

namespace CopperDevs.Windowing;

public partial class Window
{
    internal WindowOptions Options = null!;
    
    public Vector2Int Size => GetWindowSize();
    public double TotalTime => GetTotalTime();
    public double DeltaTime => GetDeltaTime();

    protected abstract Vector2Int GetWindowSize();

    protected abstract double GetTotalTime();
    protected abstract double GetDeltaTime();
}