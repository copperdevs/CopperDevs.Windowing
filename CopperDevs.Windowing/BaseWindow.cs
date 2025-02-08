using CopperDevs.Core.Utility;
using CopperDevs.Windowing.Data;

namespace CopperDevs.Windowing;

public abstract partial class Window : SafeDisposable
{
    public abstract void CreateWindow(WindowOptions options);
    public abstract void StartWindowUpdate();
    public abstract void StopWindowUpdate();
    public abstract void DestroyWindow();
}