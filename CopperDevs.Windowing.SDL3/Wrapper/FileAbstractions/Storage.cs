using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void CloseStorage() => SDL_CloseStorage();
    public static void CopyStorageFile() => SDL_CopyStorageFile();
    public static void CreateStorageDirectory() => SDL_CreateStorageDirectory();
    public static void EnumerateStorageDirectory() => SDL_EnumerateStorageDirectory();
    public static void GetStorageFileSize() => SDL_GetStorageFileSize();
    public static void GetStoragePathInfo() => SDL_GetStoragePathInfo();
    public static void GetStorageSpaceRemaining() => SDL_GetStorageSpaceRemaining();
    public static void GlobStorageDirectory() => SDL_GlobStorageDirectory();
    public static void OpenFileStorage() => SDL_OpenFileStorage();
    public static void OpenStorage() => SDL_OpenStorage();
    public static void OpenTitleStorage() => SDL_OpenTitleStorage();
    public static void OpenUserStorage() => SDL_OpenUserStorage();
    public static void ReadStorageFile() => SDL_ReadStorageFile();
    public static void RemoveStoragePath() => SDL_RemoveStoragePath();
    public static void RenameStoragePath() => SDL_RenameStoragePath();
    public static void StorageReady() => SDL_StorageReady();
    public static void WriteStorageFile() => SDL_WriteStorageFile();
}