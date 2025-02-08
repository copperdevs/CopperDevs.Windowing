using CopperDevs.Logger;
using CopperDevs.Windowing;
using CopperDevs.Windowing.SDL3;
using CopperDevs.Windowing.SDL3.Data;

namespace WindowTesting;

public static class Program
{
    private static SDL3Window window = null!;
    private static SDLRenderer renderer = null!;

    public static void Main()
    {
        var options = SDL3WindowOptions.Default with { Title = "Window Testing" };

        window = Window.CreateWindow<SDL3Window>(options);
        renderer = window.GetManagedSDLWindow().GetRenderer();

        window.OnUpdate += OnUpdate;

        window.Run();

        window.Dispose();
    }

    private static void OnUpdate()
    {
        renderer.SetDrawColor(Math.Sin(window.TotalTime) / 2 + 0.5, Math.Cos(window.TotalTime) / 2 + 0.5, 0.3, 1);
        renderer.Clear();
        renderer.Present();
    }
}