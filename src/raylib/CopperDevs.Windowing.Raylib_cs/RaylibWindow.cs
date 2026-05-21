using CopperDevs.Celesium;
using CopperDevs.Windowing.Data;
using Raylib_cs;

namespace CopperDevs.Windowing.Raylib_cs;

public class RaylibWindow : Window
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    protected override Vector2Int GetWindowSize() => new(Raylib.GetScreenWidth(), Raylib.GetScreenHeight());
    protected override void SetWindowSize(Vector2Int size) => Raylib.SetWindowSize(size.X, size.Y);
    protected override Vector2Int GetWindowMaximumSize() => throw new NotImplementedException();
    protected override void SetWindowMaximumSize(Vector2Int size) => Raylib.SetWindowMaxSize(size.X, size.Y);
    protected override Vector2Int GetWindowMinimumSize() => throw new NotImplementedException();
    protected override void SetWindowMinimumSize(Vector2Int size) => Raylib.SetWindowMinSize(size.X, size.Y);
    protected override Vector2Int GetWindowPosition() => Raylib.GetWindowPosition();
    protected override void SetWindowPosition(Vector2Int position) => Raylib.SetWindowPosition(position.X, position.Y);
    protected override string GetWindowTitle() => throw new NotImplementedException();
    protected override void SetWindowTitle(string title) => Raylib.SetWindowTitle(title);

    protected override void SetFullscreen(bool fullscreen)
    {
        if (fullscreen)
        {
            if (!GetFullscreen()) 
                Raylib.ToggleFullscreen();
        }
        else
        {
            if (GetFullscreen()) 
                Raylib.ToggleFullscreen();
        }
    }

    protected override bool GetFullscreen() => Raylib.IsWindowFullscreen();
    protected override void SetAlwaysOnTop(bool alwaysOnTop) => window.AlwaysOnTop = alwaysOnTop;
    protected override bool GetAlwaysOnTop() => window.AlwaysOnTop;
    protected override bool GetMinimized() => window.Minimized;
    protected override void SetMinimize() => window.Minimize();
    protected override bool GetMaximized() => window.Maximized;
    protected override void SetMaximize() => window.Maximize();
    protected override bool GetFocused() => window.Focused;
    protected override bool GetHovered() => window.Hovered;
    protected override SystemTheme GetSystemTheme() => SDLAPI.GetSystemTheme();
    protected override double GetTotalTime() => totalTime;
    protected override double GetDeltaTime() => deltaTime;

    protected override void WindowFlash(bool untilFocus = true) => window.Flash(untilFocus);
    protected override void StopWindowFlash() => window.StopFlash();
    protected override IInput CreateInput() => new SDLInput(this);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}