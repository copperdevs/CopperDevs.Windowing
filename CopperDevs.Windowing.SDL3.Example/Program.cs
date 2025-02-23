using System.Numerics;
using CopperDevs.Core.Utility;
using CopperDevs.Windowing.Data;
using CopperDevs.Windowing.SDL3.Data;

namespace CopperDevs.Windowing.SDL3.Example;

public static class Program
{
    private static SDL3Window window = null!;
    private static SDLRenderer renderer = null!;

    private static Vector2 scaleRange = new(0.5f, 10f);
    private static float arrowChanger = 0.5f;
    private static float scale = 1;

    public static void Main()
    {
        var options = SDL3WindowOptions.Default with
        {
            Title = "CopperDevs SDL3 Windowing Example",
            Metadata = new AppMetadata
            {
                Name = "CopperDevs SDL3 Windowing Example",
                Version = "1.0.0",
                Identifier = "com.copperdevs.windowing.sdl3.example",
                Creator = "copperdevs",
                Copyright = "MIT License",
                Url = "https://github.com/copperdevs/CopperDevs.Windowing",
                Type = AppMetadata.AppType.Application
            }
        };

        window = Window.Create<SDL3Window>(options);
        renderer = window.GetRenderer();

        window.OnUpdate += OnUpdate;
        window.OnRender += OnRender;

        window.Run();

        window.Dispose();
    }

    private static void OnUpdate()
    {
        if (Input.IsKeyPressed(InputKey.Left))
            scale -= arrowChanger;

        if (Input.IsKeyPressed(InputKey.Right))
            scale += arrowChanger;

        scale = MathUtil.Clamp(scale, scaleRange.X, scaleRange.Y);

        renderer.Scale = Vector2.One * scale;
    }


    private static void OnRender()
    {
        renderer.Clear(Color.DarkGray);

        RenderDebugText();

        renderer.Present();
    }

    private static void RenderDebugText()
    {
        var oldScale = renderer.Scale;
        renderer.Scale = Vector2.One * 1.5f; // bigger text moment

        renderer.DrawDebugText($"FPS: {Time.FrameRate}", new Vector2(16, 16), Color.Black);
        renderer.DrawDebugText($"Mouse Pos: {Input.GetMousePosition()}", new Vector2(16, 26), Color.Black);
        renderer.DrawDebugText($"Scale: {scale}", new Vector2(16, 36), Color.Black);
        
        renderer.Scale = oldScale;
    }
}