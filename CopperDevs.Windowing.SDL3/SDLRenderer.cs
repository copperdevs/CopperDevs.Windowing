using System.Numerics;
using CopperDevs.Core.Utility;
using CopperDevs.Windowing.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace CopperDevs.Windowing.SDL3;

// ReSharper disable once InconsistentNaming
// TODO: Add support for all SDL rendering functions in https://wiki.libsdl.org/SDL3/CategoryRender
public unsafe class SDLRenderer(SDL_Renderer* native) : SafeDisposable
{
    public Vector2 Scale
    {
        get => SDL.GetRenderScale(native);
        set => SDL.SetRenderScale(native, value);
    }

    public void Present() => SDL.RenderPresent(native);
    public void Clear() => SDL.RenderClear(native);

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


    public void SetDrawColor(Color color) => SDL.SetRenderDrawColor(native, color.R / 255f, color.G / 255f, color.B / 255f, color.A / 255f);
    public void SetDrawColor(float r, float g, float b, float a) => SDL.SetRenderDrawColor(native, r, g, b, a);

    public void DrawLine(Vector2 posOne, Vector2 posTwo) => SDL.RenderLine(native, posOne, posTwo);

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

    public void DrawDebugText(string text, Vector2 position) => SDL.RenderDebugText(native, text, position);

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

    /// <summary>
    /// Disposes of the renderer and shuts down its SDL counterpart
    /// </summary>
    /// <remarks>Call <see cref="SDLRenderer.Dispose"/> instead to make sure resources aren't attempted to be disposed of multiple times</remarks>
    public override void DisposeResources()
    {
        SDL.DestroyRenderer(native);
    }
}