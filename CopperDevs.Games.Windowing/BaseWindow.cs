using CopperDevs.Core.Utility;
using CopperDevs.Games.Windowing.Data;

namespace CopperDevs.Games.Windowing;

public abstract partial class Window : SafeDisposable
{
    public abstract void CreateWindow(WindowOptions options);
    public abstract void UpdateWindow();
    public abstract void DestroyWindow();
}