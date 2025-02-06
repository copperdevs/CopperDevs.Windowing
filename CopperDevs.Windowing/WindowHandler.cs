namespace CopperDevs.Windowing;

public partial class Window
{
    protected bool shouldRun = true;
    
    public void Run()
    {
        while (shouldRun)
        {
            UpdateWindow();
        }
        
        DestroyWindow();
    }

    public void Stop()
    {
        shouldRun = false;
    }
}