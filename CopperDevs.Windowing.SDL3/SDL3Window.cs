using CopperDevs.Core.Data;
using CopperDevs.Windowing.Data;

using NativeSDL3 = global::SDL.SDL3;

namespace CopperDevs.Windowing.SDL3;

// ReSharper disable once InconsistentNaming
public class SDL3Window : Window
{
    private ManagedSDLWindow window = null!;

    public override void DisposeResources()
    {
        window.Dispose();
    }

    protected override Vector2Int GetWindowSize()
    {
        return window.Size;
    }

    public override void CreateWindow(WindowOptions options)
    {
        SDL.SetHint(NativeSDL3.SDL_HINT_WINDOWS_CLOSE_ON_ALT_F4, "null byte \0 in string"u8);
        
        SDL.SetHint(NativeSDL3.SDL_HINT_WINDOWS_CLOSE_ON_ALT_F4, "1"u8);
        SDL.SetHint(NativeSDL3.SDL_HINT_WINDOWS_CLOSE_ON_ALT_F4, "1");
        
        window = new ManagedSDLWindow(options);
    }

    public override void UpdateWindow()
    {
        window.Update();   
    }

    public override void DestroyWindow()
    {
        Dispose();
    }
}