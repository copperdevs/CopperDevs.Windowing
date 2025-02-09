using CopperDevs.Core.Utility;

namespace CopperDevs.Windowing;

public partial class Window
{
    protected bool ShouldRun = true;

    public void Run()
    {
        if (WindowsApi.IsWindows && Options.WindowsApiResizeCallback)
            ConnectWindowEvents();

        OnLoad?.Invoke();

        while (ShouldRun)
        {
            RenderWindow();
        }

        OnClose?.Invoke();
        DestroyWindow();
    }

    public void Stop()
    {
        ShouldRun = false;
    }

    protected void RenderWindow()
    {
        StartWindowUpdate();

        OnUpdate?.Invoke();
        OnRender?.Invoke();

        Thread.Sleep(10);

        StopWindowUpdate();
    }

    protected abstract void ConnectWindowEvents();
}