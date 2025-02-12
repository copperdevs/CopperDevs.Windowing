using System.Numerics;
using CopperDevs.Windowing.Data;
using CopperDevs.Windowing.SDL3;
using CopperDevs.Windowing.SDL3.Data;
using Point = (System.Numerics.Vector2, System.Numerics.Vector2);

namespace CopperDevs.Windowing.Example;

public static class Program
{
    private static SDL3Window window = null!;
    private static SDLRenderer renderer = null!;

    private const string BaseWindowTitle = "CopperDevs Windowing Example";

    private static List<Point> points = [];

    public static void Main()
    {
        var options = SDL3WindowOptions.Default with { Title = BaseWindowTitle };

        window = Window.Create<SDL3Window>(options);
        renderer = window.GetRenderer();

        window.OnLoad += OnLoad;
        window.OnUpdate += OnUpdate;
        window.OnRender += OnRender;

        window.Run();

        window.Dispose();
    }

    private static void OnLoad()
    {
        renderer.Scale = Vector2.One * 2;
    }

    private static void OnUpdate()
    {
        if (Input.IsMouseButtonPressed(MouseButton.Left))
            points.Add((Input.GetMousePosition(), Input.GetMousePosition()));

        if (Input.IsMouseButtonReleased(MouseButton.Left) || Input.IsMouseButtonDown(MouseButton.Left))
            points[^1] = (points[^1].Item1, Input.GetMousePosition());

        window.Title = $"{BaseWindowTitle} | Mouse Pos: {Input.GetMousePosition()}";
    }

    private static void OnRender()
    {
        renderer.Clear(Color.DarkGray);

        renderer.SetDrawColor(Color.White);

        foreach (var point in points)
            renderer.DrawLine(point.Item1, point.Item2);

        renderer.Present();
    }
}