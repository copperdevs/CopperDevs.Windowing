using CopperDevs.Core.Utility;

namespace CopperDevs.Windowing;

public partial class Window
{
    protected bool ShouldRun = true;

    public void Run()
    {
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

    private void RenderWindow()
    {
        StartWindowUpdate();

        OnUpdate?.Invoke();
        OnRender?.Invoke();

        Thread.Sleep(10);

        StopWindowUpdate();
    }

    private void ConnectWindowEvents()
    {
        
        // WindowsApi.RegisterWindow(handle);
        //
        // WindowsApi.OnWindowResize += _ => { RenderGame(); };
    }
}