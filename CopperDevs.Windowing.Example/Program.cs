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

    private static readonly List<Point> Points = [];

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
            Points.Add((Input.GetMousePosition(), Input.GetMousePosition()));

        if (Input.IsMouseButtonReleased(MouseButton.Left) || Input.IsMouseButtonDown(MouseButton.Left))
            Points[^1] = (Points[^1].Item1, Input.GetMousePosition());

        if (Input.IsMouseButtonReleased(MouseButton.Left) && Points[^1].Item1 == Points[^1].Item2)
            Points.Remove(Points[^1]);
    }

    private static void OnRender()
    {
        renderer.Clear(Color.DarkGray);
        
        foreach (var point in Points)
            renderer.DrawLine(point.Item1, point.Item2, Color.White);

        RenderDebugText();
        
        renderer.Present();
    }

    private static void RenderDebugText()
    {
        renderer.Scale *= 1.5f; // bigger text moment

        renderer.DrawDebugText($"FPS: {Time.FrameRate}", new Vector2(16, 16), Color.Black);
        renderer.DrawDebugText($"Mouse Pos: {Input.GetMousePosition()}", new Vector2(16, 26), Color.Black);
        renderer.DrawDebugText($"Line Count: {Points.Count}", new Vector2(16, 36), Color.Black);

        renderer.Scale *= 0.9f;
        
        for (var i = 0; i < Points.Count; i++)
            renderer.DrawDebugText($"Point {i + 1}: {Points[i].Item1} -> {Points[i].Item2}", new Vector2(20, 50 + i * 10), Color.Black);
        
        renderer.Scale /= 0.9f;

        renderer.Scale /= 1.5f;
    }
}