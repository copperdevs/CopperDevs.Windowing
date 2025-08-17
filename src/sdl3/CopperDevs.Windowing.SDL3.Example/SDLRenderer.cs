using System.Numerics;
using CopperDevs.Core.Utility;
using CopperDevs.Logger;
using CopperDevs.Windowing.Data;
using NativeSDLRenderer = Hexa.NET.SDL3.SDLRenderer;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace CopperDevs.Windowing.SDL3.Example;

// ReSharper disable once InconsistentNaming
// TODO: Add support for all SDL rendering functions in https://wiki.libsdl.org/SDL3/CategoryRender
public unsafe class SDLRenderer : SafeDisposable
{
    private SDLFRect tempRect;
    private NativeSDLRenderer* native;

    public NativeSDLRenderer* GetNativeRenderer() => native;

    public void CreateRenderer(ManagedSDLWindow window, string renderer = "renderer")
    {
        native = NativeSDL.CreateRenderer(window.GetNativeWindow(), renderer);
    }

    public Vector2 Scale
    {
        get
        {
            var vector = new Vector2();
            NativeSDL.GetRenderScale(native, ref vector.X, ref vector.Y);
            return vector;
        }
        set => NativeSDL.SetRenderScale(native, value.X, value.Y);
    }

    public Vector2 RendererToWindowCoordinates(Vector2 position)
    {
        var vector = new Vector2();
        NativeSDL.RenderCoordinatesToWindow(native, position.X, position.Y, ref vector.X, ref vector.Y);
        return vector;
    }

    public Vector2 WindowToRendererCoordinates(Vector2 position)
    {
        var vector = new Vector2();
        NativeSDL.RenderCoordinatesFromWindow(native, position.X, position.Y, ref vector.X, ref vector.Y);
        return vector;
    }

    public void Screenshot()
    {
        var index = 0;

        Directory.CreateDirectory("screenshots");

        while (File.Exists($"screenshots/{index}.bmp"))
            index++;

        var pixels = NativeSDL.RenderReadPixels(native, null);
        NativeSDL.SaveBMP(pixels, $"screenshots/{index}.bmp");
        NativeSDL.DestroySurface(pixels);
    }

    public void Present() => NativeSDL.RenderPresent(native);
    public void Clear() => NativeSDL.RenderClear(native);

    public void Clear(Color color)
    {
        SetDrawColor(color);
        Clear();
    }

    public void Clear(byte r, byte g, byte b, byte a = 1)
    {
        SetDrawColor(r, g, b, a);
        Clear();
    }


    public void SetDrawColor(Color color)
    {
        var sdlColor = color.AsSDLColor();
        NativeSDL.SetRenderDrawColor(native, sdlColor.R, sdlColor.G, sdlColor.B, sdlColor.A);
    }

    public void SetDrawColor(byte r, byte g, byte b, byte a) => NativeSDL.SetRenderDrawColor(native, r, g, b, a);

    public void DrawLine(Vector2 posOne, Vector2 posTwo) => NativeSDL.RenderLine(native, posOne.X, posOne.Y, posTwo.X, posTwo.Y);

    public void DrawLine(Vector2 posOne, Vector2 posTwo, Color color)
    {
        SetDrawColor(color);
        DrawLine(posOne, posTwo);
    }

    public void DrawLine(Vector2 posOne, Vector2 posTwo, byte r, byte g, byte b, byte a = 255)
    {
        SetDrawColor(r, g, b, a);
        DrawLine(posOne, posTwo);
    }

    public void DrawDebugText(string text, Vector2 position) => NativeSDL.RenderDebugText(native, position.X, position.Y, text);

    public void DrawDebugText(string text, Vector2 position, Color color)
    {
        SetDrawColor(color);
        DrawDebugText(text, position);
    }

    public void DrawDebugText(string text, Vector2 position, byte r, byte g, byte b, byte a = 255)
    {
        SetDrawColor(r, g, b, a);
        DrawDebugText(text, position);
    }

    public void DrawLines(List<Vector2> points)
    {
        var mapped = points.Select(vector2 => new SDLFPoint(vector2.X, vector2.Y)).ToArray();

        fixed (SDLFPoint* pointsPtr = mapped)
        {
            NativeSDL.RenderLines(native, pointsPtr, points.Count);
        }
    }

    public void DrawLines(List<Vector2> points, Color color)
    {
        SetDrawColor(color);
        DrawLines(points);
    }

    public void DrawLines(List<Vector2> points, byte r, byte g, byte b, byte a = 255)
    {
        SetDrawColor(r, g, b, a);
        DrawLines(points);
    }

    public void DrawPoint(Vector2 point) => NativeSDL.RenderPoint(native, point.X, point.Y);

    public void DrawPoint(Vector2 point, Color color)
    {
        SetDrawColor(color);
        DrawPoint(point);
    }

    public void DrawPoint(Vector2 point, byte r, byte g, byte b, byte a = 255)
    {
        SetDrawColor(r, g, b, a);
        DrawPoint(point);
    }

    public void DrawPoints(List<Vector2> points)
    {
        var mapped = points.Select(vector2 => new SDLFPoint(vector2.X, vector2.Y)).ToArray();

        fixed (SDLFPoint* pointsPtr = mapped)
        {
            NativeSDL.RenderPoints(native, pointsPtr, points.Count);
        }
    }

    public void DrawPoints(List<Vector2> points, Color color)
    {
        SetDrawColor(color);
        DrawPoints(points);
    }

    public void DrawPoints(List<Vector2> points, byte r, byte g, byte b, byte a = 255)
    {
        SetDrawColor(r, g, b, a);
        DrawPoints(points);
    }

//    public unsafe void DrawRect(Vector2 position, Vector2 size)
//    {
//        tempRect = (tempRect with { X = position.X, Y = position.Y, H = size.X, W = size.Y });
//
//            NativeSDL.RenderRect(native, &tempRect);
//
//    }
//
//    public void DrawRect(Vector2 position, Vector2 size, Color color)
//    {
//        SetDrawColor(color);
//        DrawRect(position, size);
//    }
//
//    public void DrawRect(Vector2 position, Vector2 size, byte r, byte g, byte b, byte a = 255)
//    {
//        SetDrawColor(r, g, b, a);
//        DrawRect(position, size);
//    }
//
//    public void DrawRects(List<SDLFRect> rects) => NativeSDL.RenderRects(native, rects);
//
//    public void DrawRects(List<SDLFRect> rects, Color color)
//    {
//        SetDrawColor(color);
//        DrawRects(rects);
//    }
//
//    public void DrawRects(List<SDLFRect> rects, byte r, byte g, byte b, byte a = 255)
//    {
//        SetDrawColor(r, g, b, a);
//        DrawRects(rects);
//    }
//
//    public void DrawFillRect(Vector2 position, Vector2 size) => NativeSDL.RenderFillRect(native, tempRect with { x = position.X, y = position.Y, h = size.X, w = size.Y });
//
//    public void DrawFillRect(Vector2 position, Vector2 size, Color color)
//    {
//        SetDrawColor(color);
//        DrawFillRect(position, size);
//    }
//
//    public void DrawFillRect(Vector2 position, Vector2 size, byte r, byte g, byte b, byte a = 255)
//    {
//        SetDrawColor(r, g, b, a);
//        DrawFillRect(position, size);
//    }
//
//    public void DrawFillRects(List<SDLFRect> rects) => NativeSDL.RenderFillRects(native, rects);
//
//    public void DrawFillRects(List<SDLFRect> rects, Color color)
//    {
//        SetDrawColor(color);
//        DrawFillRects(rects);
//    }
//
//    public void DrawFillRects(List<SDLFRect> rects, byte r, byte g, byte b, byte a = 255)
//    {
//        SetDrawColor(r, g, b, a);
//        DrawFillRects(rects);
//    }

    public void SetVSync(int count)
    {
        if (!NativeSDL.SetRenderVSync(native, count))
            Log.Error($"Failed to set Vsync: {NativeSDL.GetError()->ToString()}");
    }

    /// <summary>
    /// Disposes of the renderer and shuts down its SDL counterpart
    /// </summary>
    /// <remarks>Call <see cref="SDLRenderer.Dispose"/> instead to make sure resources aren't attempted to be disposed of multiple times</remarks>
    public override void DisposeResources()
    {
        NativeSDL.DestroyRenderer(native);
    }
}