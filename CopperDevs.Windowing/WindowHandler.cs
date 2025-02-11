using CopperDevs.Core.Utility;

namespace CopperDevs.Windowing;

public partial class Window
{
    /// <summary>
    /// Should the window still be updating
    /// </summary>
    protected bool ShouldRun = true;

    /// <summary>
    /// Start the windowing system once setup
    /// </summary>
    public void Run()
    {
        if (WindowsApi.IsWindows && Options.WindowsApiResizeCallback)
            ConnectWindowEvents();

        SetupInput();

        OnLoad?.Invoke();

        while (ShouldRun)
        {
            RenderWindow();
        }

        OnClose?.Invoke();
        DestroyWindow();
    }

    /// <summary>
    /// Shutdown the window
    /// </summary>
    public void Stop()
    {
        ShouldRun = false;
    }

    /// <summary>
    /// Render a frame of the window
    /// </summary>
    protected void RenderWindow()
    {
        UpdateInput();
        StartWindowUpdate();

        OnUpdate?.Invoke();
        OnRender?.Invoke();

        Thread.Sleep(10);

        StopWindowUpdate();
    }
}