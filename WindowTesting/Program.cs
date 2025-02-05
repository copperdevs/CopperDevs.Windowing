using CopperDevs.Windowing;
using CopperDevs.Windowing.SDL3;
using CopperDevs.Windowing.SDL3.Data;

namespace WindowTesting;

public static class Program
{
    public static void Main()
    {
        var options = SDL3WindowOptions.Default with { Title = "Window Testing" };

        using var window = Window.CreateWindow<SDL3Window>(options);
        window.Run();
    }
}