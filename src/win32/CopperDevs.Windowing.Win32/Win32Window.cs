using System;
using System.Runtime.Versioning;
using CopperDevs.Core.Data;
using CopperDevs.Windowing.Data;

namespace CopperDevs.Windowing.Win32;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

[SupportedOSPlatform("windows5.0")]
public class Win32Window : Window
{
    private ManagedWin32Window managed = null!;

    public override void DisposeResources()
    {
        managed.Dispose();
    }

    protected override IInput CreateInput()
    {
        return new Win32Input();
    }

    protected override void CreateWindow(WindowOptions options)
    {
        managed = new(options);
    }

    protected override void DestroyWindow()
    {
        Dispose();
    }

    protected override bool GetAlwaysOnTop()
    {
        return false;
    }

    protected override double GetDeltaTime()
    {
        return 0;
    }

    protected override bool GetFocused()
    {
        return false;
    }

    protected override bool GetFullscreen()
    {
        return false;
    }

    protected override bool GetHovered()
    {
        return false;
    }

    protected override bool GetMaximized()
    {
        return false;
    }

    protected override bool GetMinimized()
    {
        return false;
    }

    protected override SystemTheme GetSystemTheme()
    {
        return SystemTheme.Unknown;
    }

    protected override double GetTotalTime()
    {
        return 0;
    }

    protected override Vector2Int GetWindowMaximumSize()
    {
        return Vector2Int.Zero;
    }

    protected override Vector2Int GetWindowMinimumSize()
    {
        return Vector2Int.Zero;
    }

    protected override Vector2Int GetWindowPosition()
    {
        return Vector2Int.Zero;
    }

    protected override Vector2Int GetWindowSize()
    {
        return Vector2Int.Zero;
    }

    protected override string GetWindowTitle()
    {
        return string.Empty;
    }

    protected override void SetAlwaysOnTop(bool alwaysOnTop)
    {
    }

    protected override void SetFullscreen(bool fullscreen)
    {
    }

    protected override void SetMaximize()
    {
    }

    protected override void SetMinimize()
    {
    }

    protected override void SetWindowMaximumSize(Vector2Int size)
    {
    }

    protected override void SetWindowMinimumSize(Vector2Int size)
    {
    }

    protected override void SetWindowPosition(Vector2Int position)
    {
    }

    protected override void SetWindowSize(Vector2Int size)
    {

    }

    protected override void SetWindowTitle(string title)
    {

    }

    protected override void StartWindowUpdate()
    {

    }

    protected override void StopWindowFlash()
    {

    }

    protected override void StopWindowUpdate()
    {

    }

    protected override void WindowFlash(bool untilFocus = true)
    {

    }
}
