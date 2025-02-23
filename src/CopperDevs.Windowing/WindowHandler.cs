using CopperDevs.Core.Utility;
using CopperDevs.Windowing.Data;

namespace CopperDevs.Windowing;

public partial class Window
{
    private readonly FPSCounter fpsCounter = new();
    internal int GetFrameRate() => fpsCounter.FrameRate;

    /// <summary>
    /// Should the window still be updating
    /// </summary>
    protected bool ShouldRun = true;

    /// <summary>
    /// Start the windowing system once setup
    /// </summary>
    public void Run()
    {
        Time.Setup(this);
        SetupInput();

        OnLoad?.Invoke();

        while (ShouldRun)
            RenderWindow();

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
    public void RenderWindow()
    {
        fpsCounter.Update();

        UpdateInput();
        StartWindowUpdate();

        OnUpdate?.Invoke();
        OnRender?.Invoke();

        Thread.Sleep(10);

        StopWindowUpdate();
    }
}