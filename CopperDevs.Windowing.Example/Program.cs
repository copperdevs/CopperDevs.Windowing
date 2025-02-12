using System.Drawing;
using CopperDevs.Logger;
using CopperDevs.Windowing.Data;
using CopperDevs.Windowing.SDL3;
using CopperDevs.Windowing.SDL3.Data;

namespace CopperDevs.Windowing.Example;

public static class Program
{
    private static SDL3Window window = null!;
    private static SDLRenderer renderer = null!;

    private const string BaseWindowTitle = "CopperDevs Windowing Example";

    public static void Main()
    {
        var options = SDL3WindowOptions.Default with { Title = BaseWindowTitle };

        window = Window.Create<SDL3Window>(options);
        renderer = window.GetRenderer();

        window.OnUpdate += OnUpdate;
        window.OnRender += OnRender;

        window.Run();

        window.Dispose();
    }

    private static void OnUpdate()
    {
        window.Title = $"{BaseWindowTitle} | Mouse Pos: {Input.GetMousePosition()}";

        if (Input.IsKeyPressed(InputKey.Space)) Log.Info($"Key pressed {InputKey.Space}");
        if (Input.IsKeyReleased(InputKey.Space)) Log.Info($"Key released {InputKey.Space}");

        if (Input.IsMouseButtonPressed(MouseButton.Left)) Log.Info($"Mouse Button pressed {MouseButton.Left}");
        if (Input.IsMouseButtonReleased(MouseButton.Left)) Log.Info($"Mouse Button released {MouseButton.Left}");
    }

    private static void OnRender()
    {
        var backgroundColor = (window.SystemTheme == SystemTheme.Dark ? Color.Black : Color.White).ToVector4() / 255f;
        
        renderer.SetDrawColor(backgroundColor.X, backgroundColor.Y, backgroundColor.Z, 1);
        renderer.Clear();
        
        renderer.Present();
    }
}