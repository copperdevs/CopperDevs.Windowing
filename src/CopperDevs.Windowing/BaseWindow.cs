#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using CopperDevs.Celesium;
using CopperDevs.Windowing.Data;

namespace CopperDevs.Windowing;

public abstract partial class Window : SafeDisposable
{
    protected abstract void CreateWindow(WindowOptions options);
    protected abstract void StartWindowUpdate();
    protected abstract void StopWindowUpdate();
    protected abstract void DestroyWindow();
}