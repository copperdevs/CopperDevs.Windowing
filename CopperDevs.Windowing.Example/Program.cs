using CopperDevs.Logger;
using CopperDevs.Windowing.Data;
using CopperDevs.Windowing.SDL3;
using CopperDevs.Windowing.SDL3.Data;

namespace CopperDevs.Windowing.Example;

public static class Program
{
    private static SDL3Window window = null!;
    private static SDLRenderer renderer = null!;

    public static void Main()
    {
        var options = SDL3WindowOptions.Default with { Title = "Copper Windowing Example" };

        window = Window.Create<SDL3Window>(options);
        renderer = window.GetRenderer();

        window.OnUpdate += OnUpdate;
        window.OnRender += OnRender;

        window.Run();

        window.Dispose();
    }

    private static void OnUpdate()
    {
        if (window.IsKeyPressed(InputKey.Space))
            Log.Info($"Key pressed {InputKey.Space}");

        if (window.IsKeyReleased(InputKey.Space))
            Log.Info($"Key released {InputKey.Space}");
    }

    private static void OnRender()
    {
        renderer.SetDrawColor(
            Math.Sin(window.TotalTime) / 2 + 0.5,
            Math.Cos(window.TotalTime) / 2 + 0.5,
            0.3,
            1);
        renderer.Clear();
        renderer.Present();
    }
}