#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDLAPI
{
    public static bool CopyFile(byte* oldpath, byte* newpath) => SDL_CopyFile(oldpath, newpath);
    public static bool CopyFile(string oldpath, string newpath) => SDL_CopyFile(oldpath, newpath);
    public static bool CreateDirectory(byte* path) => SDL_CreateDirectory(path);
    public static bool CreateDirectory(string path) => SDL_CreateDirectory(path);

    public static bool EnumerateDirectory(byte* path, delegate*unmanaged[Cdecl]<IntPtr, byte*, byte*, SDL_EnumerationResult> callback, IntPtr userdata) =>
        SDL_EnumerateDirectory(path, callback, userdata);

    public static bool EnumerateDirectory(string path, delegate*unmanaged[Cdecl]<IntPtr, byte*, byte*, SDL_EnumerationResult> callback, IntPtr userdata) =>
        SDL_EnumerateDirectory(path, callback, userdata);

    public static string GetBasePath() => SDL_GetBasePath() ?? string.Empty;
    public static string GetCurrentDirectory() => SDL_GetCurrentDirectory() ?? string.Empty;
    public static bool GetPathInfo(byte* path, SDL_PathInfo* info) => SDL_GetPathInfo(path, info);
    public static bool GetPathInfo(string path, SDL_PathInfo* info) => SDL_GetPathInfo(path, info);
    public static string GetPrefPath(string org, string app) => SDL_GetPrefPath(org, app) ?? string.Empty;
    public static string GetUserFolder(SDL_Folder folder) => SDL_GetUserFolder(folder) ?? string.Empty;
    public static byte** GlobDirectory(byte* path, byte* pattern, SDL_GlobFlags flags, int* count) => SDL_GlobDirectory(path, pattern, flags, count);
    public static byte** GlobDirectory(string path, string pattern, SDL_GlobFlags flags, int* count) => SDL_GlobDirectory(path, pattern, flags, count);
    public static bool RemovePath(byte* path) => SDL_RemovePath(path);
    public static bool RemovePath(string path) => SDL_RemovePath(path);
    public static bool RenamePath(byte* oldpath, byte* newpath) => SDL_RenamePath(oldpath, newpath);
    public static bool RenamePath(string oldpath, string newpath) => SDL_RenamePath(oldpath, newpath);
}