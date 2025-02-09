#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace CopperDevs.Windowing.SDL3;

// ReSharper disable once InconsistentNaming
// TODO: Add support for all SDL rendering functions in https://wiki.libsdl.org/SDL3/CategoryRender
public unsafe class SDLRenderer(SDL_Renderer* native)
{
    public void SetDrawColor(float r, float g, float b, float a) => SDL.SetRenderDrawColor(native, r, g, b, a);
    public void SetDrawColor(double r, double g, double b, double a) => SDL.SetRenderDrawColor(native, (float)r, (float)g, (float)b, (float)a);
    public void Clear() => SDL.RenderClear(native);
    public void Present() => SDL.RenderPresent(native);
}