using System;
using CopperDevs.Core.Data;
using CopperDevs.Windowing.Data;

namespace CopperDevs.Windowing.Win32;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

public class Win32Window : Window
{
    public override void DisposeResources()
    {
        throw new NotImplementedException();
    }

    protected override IInput CreateInput()
    {
        throw new NotImplementedException();
    }

    protected override void CreateWindow(WindowOptions options)
    {
        throw new NotImplementedException();
    }

    protected override void DestroyWindow()
    {
        throw new NotImplementedException();
    }

    protected override bool GetAlwaysOnTop()
    {
        throw new NotImplementedException();
    }

    protected override double GetDeltaTime()
    {
        throw new NotImplementedException();
    }

    protected override bool GetFocused()
    {
        throw new NotImplementedException();
    }

    protected override bool GetFullscreen()
    {
        throw new NotImplementedException();
    }

    protected override bool GetHovered()
    {
        throw new NotImplementedException();
    }

    protected override bool GetMaximized()
    {
        throw new NotImplementedException();
    }

    protected override bool GetMinimized()
    {
        throw new NotImplementedException();
    }

    protected override SystemTheme GetSystemTheme()
    {
        throw new NotImplementedException();
    }

    protected override double GetTotalTime()
    {
        throw new NotImplementedException();
    }

    protected override Vector2Int GetWindowMaximumSize()
    {
        throw new NotImplementedException();
    }

    protected override Vector2Int GetWindowMinimumSize()
    {
        throw new NotImplementedException();
    }

    protected override Vector2Int GetWindowPosition()
    {
        throw new NotImplementedException();
    }

    protected override Vector2Int GetWindowSize()
    {
        throw new NotImplementedException();
    }

    protected override string GetWindowTitle()
    {
        throw new NotImplementedException();
    }

    protected override void SetAlwaysOnTop(bool alwaysOnTop)
    {
        throw new NotImplementedException();
    }

    protected override void SetFullscreen(bool fullscreen)
    {
        throw new NotImplementedException();
    }

    protected override void SetMaximize()
    {
        throw new NotImplementedException();
    }

    protected override void SetMinimize()
    {
        throw new NotImplementedException();
    }

    protected override void SetWindowMaximumSize(Vector2Int size)
    {
        throw new NotImplementedException();
    }

    protected override void SetWindowMinimumSize(Vector2Int size)
    {
        throw new NotImplementedException();
    }

    protected override void SetWindowPosition(Vector2Int position)
    {
        throw new NotImplementedException();
    }

    protected override void SetWindowSize(Vector2Int size)
    {
        throw new NotImplementedException();
    }

    protected override void SetWindowTitle(string title)
    {
        throw new NotImplementedException();
    }

    protected override void StartWindowUpdate()
    {
        throw new NotImplementedException();
    }

    protected override void StopWindowFlash()
    {
        throw new NotImplementedException();
    }

    protected override void StopWindowUpdate()
    {
        throw new NotImplementedException();
    }

    protected override void WindowFlash(bool untilFocus = true)
    {
        throw new NotImplementedException();
    }
}
