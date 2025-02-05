using CopperDevs.Core.Data;
using CopperDevs.Windowing.Data;

namespace CopperDevs.Windowing.SDL3;

// ReSharper disable once InconsistentNaming
public class SDL3Window : Window
{
    private bool createdSuccessfully = false;

    private ManagedSDLWindow window = null!;

    public override void DisposeResources()
    {
        window.Dispose();
    }

    protected override Vector2Int GetWindowSize()
    {
        throw new NotImplementedException();
    }

    public override void CreateWindow(WindowOptions options)
    {
        window = new ManagedSDLWindow(options);
    }

    public override void UpdateWindow()
    {
        throw new NotImplementedException();
    }

    public override void DestroyWindow()
    {
        throw new NotImplementedException();
    }
}