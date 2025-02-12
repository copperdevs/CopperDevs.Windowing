﻿using System.Numerics;
using CopperDevs.Core.Data;
using CopperDevs.Windowing.Data;
using CopperDevs.Windowing.SDL3;
using CopperDevs.Windowing.SDL3.Data;

namespace CopperDevs.Windowing.Example;

public static class Program
{
    private static SDL3Window window = null!;
    private static SDLRenderer renderer = null!;

    private const string BaseWindowTitle = "CopperDevs Windowing Example";

    private static readonly List<Vector2> Points = [];
    private static readonly List<Vector2Int> PointIndexes = []; // represents a line, with X and Y being the index of the point in points (Points[X] -> Points[Y])

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
        {
            Points.AddRange([Input.GetMousePosition(), Input.GetMousePosition()]);
            PointIndexes.Add(new Vector2Int(Points.Count - 2, Points.Count - 1));
        }

        if (Input.IsMouseButtonReleased(MouseButton.Left) || Input.IsMouseButtonDown(MouseButton.Left))
            Points[PointIndexes[^1].Y] = Input.GetMousePosition();

        if (Input.IsMouseButtonReleased(MouseButton.Left) && Points[PointIndexes[^1].X] == Points[PointIndexes[^1].Y])
            PointIndexes.Remove(PointIndexes[^1]);
    }

    private static void OnRender()
    {
        renderer.Clear(Color.DarkGray);

        foreach (var pointIndex in PointIndexes)
            renderer.DrawLine(Points[pointIndex.X], Points[pointIndex.Y], Color.White);

        foreach (var point in Points)
        {
            renderer.DrawPoint(point, Color.Red);   
        }

        RenderDebugText();

        renderer.Present();
    }

    private static void RenderDebugText()
    {
        renderer.Scale *= 1.5f; // bigger text moment

        renderer.DrawDebugText($"FPS: {Time.FrameRate}", new Vector2(16, 16), Color.Black);
        renderer.DrawDebugText($"Mouse Pos: {Input.GetMousePosition()}", new Vector2(16, 26), Color.Black);
        renderer.DrawDebugText($"Line Count: {PointIndexes.Count}", new Vector2(16, 36), Color.Black);
        renderer.DrawDebugText($"Points Count: {Points.Count}", new Vector2(16, 46), Color.Black);


        renderer.Scale *= 0.9f; // smaller text for these items
        
        for (var i = 0; i < PointIndexes.Count; i++)
            renderer.DrawDebugText($"Line {i + 1}:{((9 > i && PointIndexes.Count >= 10) ? " " : "")} {Points[PointIndexes[i].X].Round(2)} -> {Points[PointIndexes[i].Y].Round(2)}", new Vector2(20, 64 + i * 10), Color.Black);

        renderer.Scale /= 0.9f;

        renderer.Scale /= 1.5f;
    }
}