using System.Numerics;
using CopperDevs.Core.Utility;
using CopperDevs.Logger;
using CopperDevs.Windowing.Data;
using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace CopperDevs.Windowing.SDL3;

// ReSharper disable once InconsistentNaming
// TODO: Add support for all SDL rendering functions in https://wiki.libsdl.org/SDL3/CategoryRender
public unsafe class SDLRenderer : SafeDisposable, IRenderer<SDL_Renderer>
{
    private SDL_FRect tempRect;
    private SDL_Renderer* native;

    public SDL_Renderer* GetNativeRenderer() => native;
    
    public void CreateRenderer(ManagedSDLWindow window, RendererOptions options)
    {
        native = SDLAPI.CreateRenderer(window.GetNativeWindow());
    }

    public Vector2 Scale
    {
        get => SDLAPI.GetRenderScale(native);
        set => SDLAPI.SetRenderScale(native, value);
    }

    public Vector2 RendererToWindowCoordinates(Vector2 position) => SDLAPI.RenderCoordinatesToWindow(native, position);

    public Vector2 WindowToRendererCoordinates(Vector2 position) => SDLAPI.RenderCoordinatesFromWindow(native, position);

    public void Screenshot()
    {
        var index = 0;

        Directory.CreateDirectory("screenshots");

        while (File.Exists($"screenshots/{index}.bmp"))
            index++;

        var pixels = SDLAPI.RenderReadPixels(native, null);
        SDLAPI.SaveBmp(pixels, $"screenshots/{index}.bmp");
        SDLAPI.DestroySurface(pixels);
    }

    public void Present() => SDLAPI.RenderPresent(native);
    public void Clear() => SDLAPI.RenderClear(native);

    public void Clear(Color color)
    {
        SetDrawColor(color);
        Clear();
    }

    public void Clear(float r, float g, float b, float a = 1)
    {
        SetDrawColor(r, g, b, a);
        Clear();
    }


    public void SetDrawColor(Color color) => SDLAPI.SetRenderDrawColor(native, color.R / 255f, color.G / 255f, color.B / 255f, color.A / 255f);
    public void SetDrawColor(float r, float g, float b, float a) => SDLAPI.SetRenderDrawColor(native, r, g, b, a);

    public void DrawLine(Vector2 posOne, Vector2 posTwo) => SDLAPI.RenderLine(native, posOne, posTwo);

    public void DrawLine(Vector2 posOne, Vector2 posTwo, Color color)
    {
        SetDrawColor(color);
        DrawLine(posOne, posTwo);
    }

    public void DrawLine(Vector2 posOne, Vector2 posTwo, float r, float g, float b, float a = 1)
    {
        SetDrawColor(r, g, b, a);
        DrawLine(posOne, posTwo);
    }

    public void DrawDebugText(string text, Vector2 position) => SDLAPI.RenderDebugText(native, text, position);

    public void DrawDebugText(string text, Vector2 position, Color color)
    {
        SetDrawColor(color);
        DrawDebugText(text, position);
    }

    public void DrawDebugText(string text, Vector2 position, float r, float g, float b, float a = 1)
    {
        SetDrawColor(r, g, b, a);
        DrawDebugText(text, position);
    }

    public void DrawLines(List<Vector2> points) => SDLAPI.RenderLines(native, points);

    public void DrawLines(List<Vector2> points, Color color)
    {
        SetDrawColor(color);
        DrawLines(points);
    }

    public void DrawLines(List<Vector2> points, float r, float g, float b, float a = 1)
    {
        SetDrawColor(r, g, b, a);
        DrawLines(points);
    }

    public void DrawPoint(Vector2 point) => SDLAPI.RenderPoint(native, point);

    public void DrawPoint(Vector2 point, Color color)
    {
        SetDrawColor(color);
        DrawPoint(point);
    }

    public void DrawPoint(Vector2 point, float r, float g, float b, float a = 1)
    {
        SetDrawColor(r, g, b, a);
        DrawPoint(point);
    }

    public void DrawPoints(List<Vector2> points) => SDLAPI.RenderPoints(native, points);

    public void DrawPoints(List<Vector2> points, Color color)
    {
        SetDrawColor(color);
        DrawPoints(points);
    }

    public void DrawPoints(List<Vector2> points, float r, float g, float b, float a = 1)
    {
        SetDrawColor(r, g, b, a);
        DrawPoints(points);
    }

    public void DrawRect(Vector2 position, Vector2 size) => SDLAPI.RenderRect(native, tempRect with { x = position.X, y = position.Y, h = size.X, w = size.Y });

    public void DrawRect(Vector2 position, Vector2 size, Color color)
    {
        SetDrawColor(color);
        DrawRect(position, size);
    }

    public void DrawRect(Vector2 position, Vector2 size, float r, float g, float b, float a = 1)
    {
        SetDrawColor(r, g, b, a);
        DrawRect(position, size);
    }

    public void DrawRects(List<SDL_FRect> rects) => SDLAPI.RenderRects(native, rects);

    public void DrawRects(List<SDL_FRect> rects, Color color)
    {
        SetDrawColor(color);
        DrawRects(rects);
    }

    public void DrawRects(List<SDL_FRect> rects, float r, float g, float b, float a = 1)
    {
        SetDrawColor(r, g, b, a);
        DrawRects(rects);
    }

    public void DrawFillRect(Vector2 position, Vector2 size) => SDLAPI.RenderFillRect(native, tempRect with { x = position.X, y = position.Y, h = size.X, w = size.Y });

    public void DrawFillRect(Vector2 position, Vector2 size, Color color)
    {
        SetDrawColor(color);
        DrawFillRect(position, size);
    }

    public void DrawFillRect(Vector2 position, Vector2 size, float r, float g, float b, float a = 1)
    {
        SetDrawColor(r, g, b, a);
        DrawFillRect(position, size);
    }

    public void DrawFillRects(List<SDL_FRect> rects) => SDLAPI.RenderFillRects(native, rects);

    public void DrawFillRects(List<SDL_FRect> rects, Color color)
    {
        SetDrawColor(color);
        DrawFillRects(rects);
    }

    public void DrawFillRects(List<SDL_FRect> rects, float r, float g, float b, float a = 1)
    {
        SetDrawColor(r, g, b, a);
        DrawFillRects(rects);
    }

    public void SetVSync(int count)
    {
        if (!SDLAPI.SetRenderVSync(native, count))
            Log.Error($"Failed to set Vsync: {SDLAPI.GetError()}");
    }

    /// <summary>
    /// Disposes of the renderer and shuts down its SDL counterpart
    /// </summary>
    /// <remarks>Call <see cref="SDLRenderer.Dispose"/> instead to make sure resources aren't attempted to be disposed of multiple times</remarks>
    public override void DisposeResources()
    {
        SDLAPI.DestroyRenderer(native);
    }
}