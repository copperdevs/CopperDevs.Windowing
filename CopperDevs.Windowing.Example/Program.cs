﻿using CopperDevs.Logger;
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
        if (Input.IsMouseButtonPressed(MouseButton.Left)) 
            Input.SetCursorMode(CursorMode.Locked);
        
        if (Input.IsMouseButtonReleased(MouseButton.Left)) 
            Input.SetCursorMode(CursorMode.Normal);
        
        window.Title = $"{BaseWindowTitle} | Mouse Pos: {Input.GetMousePosition()}";
        
        if (Input.IsKeyPressed(InputKey.Space)) Log.Info($"Key pressed {InputKey.Space}");
        if (Input.IsKeyReleased(InputKey.Space)) Log.Info($"Key released {InputKey.Space}");

        if (Input.IsMouseButtonPressed(MouseButton.Left)) Log.Info($"Mouse Button pressed {MouseButton.Left}");
        if (Input.IsMouseButtonReleased(MouseButton.Left)) Log.Info($"Mouse Button released {MouseButton.Left}");

        // i don't want these always spamming the console so i just threw the false in there 

        if (Input.IsKeyDown(InputKey.Space) && false) Log.Info($"Key down {InputKey.Space}");
        if (Input.IsKeyUp(InputKey.Space) && false) Log.Info($"Key up {InputKey.Space}");

        if (Input.IsMouseButtonDown(MouseButton.Left) && false) Log.Info($"Mouse Button down {MouseButton.Left}");
        if (Input.IsMouseButtonUp(MouseButton.Left) && false) Log.Info($"Mouse Button up {MouseButton.Left}");
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