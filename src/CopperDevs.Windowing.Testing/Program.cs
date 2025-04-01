using CopperDevs.Windowing.Data;
using CopperDevs.Windowing.SDL3;
using CopperDevs.Windowing.SDL3.Data;

namespace CopperDevs.Windowing.Testing;

// testing project moment
public static class Program
{
    private static SDL3Window window = null!;
    private static SDLRenderer renderer = null!;

    public static void Main()
    {
        var options = SDL3WindowOptions.Default with
        {
            Title = "CopperDevs Windowing Example",
            // Metadata = new AppMetadata
            // {
            //     Name = "CopperDevs Windowing Example",
            //     Version = "1.0.0",
            //     Identifier = "com.copperdevs.windowing.example",
            //     Creator = "copperdevs",
            //     Copyright = "MIT License",
            //     Url = "https://github.com/copperdevs/CopperDevs.Windowing",
            //     Type = AppMetadata.AppType.Application
            // }
        };

        window = Window.Create<SDL3Window>(options);
        renderer = window.GetRenderer()!;

        window.OnLoad += OnLoad;
        window.OnUpdate += OnUpdate;
        window.OnRender += OnRender;
        window.OnClose += OnClose;

        window.Run();

        window.Dispose();
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