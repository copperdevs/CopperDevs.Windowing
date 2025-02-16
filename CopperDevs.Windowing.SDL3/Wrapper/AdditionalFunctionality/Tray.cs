using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void ClickTrayEntry() => SDL_ClickTrayEntry();
    public static void CreateTray() => SDL_CreateTray();
    public static void CreateTrayMenu() => SDL_CreateTrayMenu();
    public static void CreateTraySubmenu() => SDL_CreateTraySubmenu();
    public static void DestroyTray() => SDL_DestroyTray();
    public static void GetTrayEntries() => SDL_GetTrayEntries();
    public static void GetTrayEntryChecked() => SDL_GetTrayEntryChecked();
    public static void GetTrayEntryEnabled() => SDL_GetTrayEntryEnabled();
    public static void GetTrayEntryLabel() => SDL_GetTrayEntryLabel();
    public static void GetTrayEntryParent() => SDL_GetTrayEntryParent();
    public static void GetTrayMenu() => SDL_GetTrayMenu();
    public static void GetTrayMenuParentEntry() => SDL_GetTrayMenuParentEntry();
    public static void GetTrayMenuParentTray() => SDL_GetTrayMenuParentTray();
    public static void GetTraySubmenu() => SDL_GetTraySubmenu();
    public static void InsertTrayEntryAt() => SDL_InsertTrayEntryAt();
    public static void RemoveTrayEntry() => SDL_RemoveTrayEntry();
    public static void SetTrayEntryCallback() => SDL_SetTrayEntryCallback();
    public static void SetTrayEntryChecked() => SDL_SetTrayEntryChecked();
    public static void SetTrayEntryEnabled() => SDL_SetTrayEntryEnabled();
    public static void SetTrayEntryLabel() => SDL_SetTrayEntryLabel();
    public static void SetTrayIcon() => SDL_SetTrayIcon();
    public static void SetTrayTooltip() => SDL_SetTrayTooltip();
    public static void UpdateTrays() => SDL_UpdateTrays();
}