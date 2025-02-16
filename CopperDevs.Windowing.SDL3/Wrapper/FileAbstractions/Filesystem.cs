using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void CopyFile() => SDL_CopyFile();
    public static void CreateDirectory() => SDL_CreateDirectory();
    public static void EnumerateDirectory() => SDL_EnumerateDirectory();
    public static void GetBasePath() => SDL_GetBasePath();
    public static void GetCurrentDirectory() => SDL_GetCurrentDirectory();
    public static void GetPathInfo() => SDL_GetPathInfo();
    public static void GetPrefPath() => SDL_GetPrefPath();
    public static void GetUserFolder() => SDL_GetUserFolder();
    public static void GlobDirectory() => SDL_GlobDirectory();
    public static void RemovePath() => SDL_RemovePath();
    public static void RenamePath() => SDL_RenamePath();
}