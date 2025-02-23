using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDLAPI
{
    public static bool CloseStorage(SDL_Storage* storage) => SDL_CloseStorage(storage);
    public static bool CopyStorageFile(SDL_Storage* storage, byte* oldpath, byte* newpath) => SDL_CopyStorageFile(storage, oldpath, newpath);
    public static bool CopyStorageFile(SDL_Storage* storage, string oldpath, string newpath) => SDL_CopyStorageFile(storage, oldpath, newpath);
    public static bool CreateStorageDirectory(SDL_Storage* storage, byte* path) => SDL_CreateStorageDirectory(storage, path);
    public static bool CreateStorageDirectory(SDL_Storage* storage, string path) => SDL_CreateStorageDirectory(storage, path);

    // TODO: public static bool EnumerateStorageDirectory(SDL_Storage* storage, byte* path, IntPtr userdata) => SDL.SDL3.SDL_EnumerateStorageDirectory(storage, path, userdata);
    // TODO: public static bool EnumerateStorageDirectory(SDL_Storage* storage, string path, IntPtr userdata) => SDL.SDL3.SDL_EnumerateStorageDirectory(storage, path, userdata);

    public static bool GetStorageFileSize(SDL_Storage* storage, byte* path, ulong* length) => SDL_GetStorageFileSize(storage, path, length);
    public static bool GetStorageFileSize(SDL_Storage* storage, string path, ulong* length) => SDL_GetStorageFileSize(storage, path, length);
    public static bool GetStoragePathInfo(SDL_Storage* storage, byte* path, SDL_PathInfo* info) => SDL_GetStoragePathInfo(storage, path, info);
    public static bool GetStoragePathInfo(SDL_Storage* storage, string path, SDL_PathInfo* info) => SDL_GetStoragePathInfo(storage, path, info);
    public static ulong GetStorageSpaceRemaining(SDL_Storage* storage) => SDL_GetStorageSpaceRemaining(storage);
    public static byte** GlobStorageDirectory(SDL_Storage* storage, byte* path, byte* pattern, SDL_GlobFlags flags, int* count) => SDL_GlobStorageDirectory(storage, path, pattern, flags, count);
    public static IntPtr[] GlobStorageDirectory(SDL_Storage* storage, byte* path, byte* pattern, SDL_GlobFlags flags) => SDLUtil.ToArray(SDL_GlobStorageDirectory(storage, path, pattern, flags));
    public static byte** GlobStorageDirectory(SDL_Storage* storage, string path, string pattern, SDL_GlobFlags flags, int* count) => SDL_GlobStorageDirectory(storage, path, pattern, flags, count);
    public static SDL_Storage* OpenFileStorage(byte* path) => SDL_OpenFileStorage(path);
    public static SDL_Storage* OpenFileStorage(string path) => SDL_OpenFileStorage(path);
    public static SDL_Storage* OpenStorage(SDL_StorageInterface* iface, IntPtr userdata) => SDL_OpenStorage(iface, userdata);
    public static SDL_Storage* OpenTitleStorage(byte* @override, SDL_PropertiesID props) => SDL_OpenTitleStorage(@override, props);
    public static SDL_Storage* OpenTitleStorage(string @override, SDL_PropertiesID props) => SDL_OpenTitleStorage(@override, props);
    public static SDL_Storage* OpenUserStorage(byte* org, byte* app, SDL_PropertiesID props) => SDL_OpenUserStorage(org, app, props);
    public static SDL_Storage* OpenUserStorage(string org, string app, SDL_PropertiesID props) => SDL_OpenUserStorage(org, app, props);
    public static bool ReadStorageFile(SDL_Storage* storage, byte* path, IntPtr destination, ulong length) => SDL_ReadStorageFile(storage, path, destination, length);
    public static bool ReadStorageFile(SDL_Storage* storage, string path, IntPtr destination, ulong length) => SDL_ReadStorageFile(storage, path, destination, length);
    public static bool RemoveStoragePath(SDL_Storage* storage, byte* path) => SDL_RemoveStoragePath(storage, path);
    public static bool RemoveStoragePath(SDL_Storage* storage, string path) => SDL_RemoveStoragePath(storage, path);
    public static bool RenameStoragePath(SDL_Storage* storage, byte* oldpath, byte* newpath) => SDL_RenameStoragePath(storage, oldpath, newpath);
    public static bool RenameStoragePath(SDL_Storage* storage, string oldpath, string newpath) => SDL_RenameStoragePath(storage, oldpath, newpath);
    public static bool StorageReady(SDL_Storage* storage) => SDL_StorageReady(storage);
    public static bool WriteStorageFile(SDL_Storage* storage, byte* path, IntPtr source, ulong length) => SDL_WriteStorageFile(storage, path, source, length);
    public static bool WriteStorageFile(SDL_Storage* storage, string path, IntPtr source, ulong length) => SDL_WriteStorageFile(storage, path, source, length);
}