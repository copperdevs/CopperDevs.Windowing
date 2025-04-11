using CopperDevs.Windowing.Data;
using CopperDevs.Windowing.Win32;

namespace CopperDevs.Windowing.Testing;

// testing project moment
public static class Program
{
    // private static Window window = null!;

    public static void Main()
    {
        var window = new ManagedWin32Window(Win32WindowOptions.Default);

        Console.ReadLine();
        return;

        // var options = Win32WindowOptions.Default with
        // {
        //     Title = "CopperDevs Windowing Example"
        // };

        // window = Window.Create<Win32Window>(options);

        // window.OnLoad += OnLoad;
        // window.OnUpdate += OnUpdate;
        // window.OnRender += OnRender;
        // window.OnClose += OnClose;

        // window.Run();

        // window.Dispose();
    }

    private static void OnLoad()
    {
    }

    private static void OnUpdate()
    {
    }

    private static void OnRender()
    {
    }

    private static void OnClose()
    {
    }
}
