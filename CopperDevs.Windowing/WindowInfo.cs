using CopperDevs.Core.Data;
using CopperDevs.Windowing.Data;

namespace CopperDevs.Windowing;

public partial class Window
{
    internal WindowOptions Options = null!;
    
    /// <summary>
    /// Get the size of the window
    /// </summary>
    public Vector2Int Size => GetWindowSize();
    
    /// <summary>
    /// Get the total time the window has been open
    /// </summary>
    public double TotalTime => GetTotalTime();
    
    /// <summary>
    /// Get the current frames delta time
    /// </summary>
    public double DeltaTime => GetDeltaTime();

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    protected abstract Vector2Int GetWindowSize();
    protected abstract double GetTotalTime();
    protected abstract double GetDeltaTime();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}