using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void CloseIO() => SDL_CloseIO();
    public static void FlushIO() => SDL_FlushIO();
    public static void GetIOProperties() => SDL_GetIOProperties();
    public static void GetIOSize() => SDL_GetIOSize();
    public static void GetIOStatus() => SDL_GetIOStatus();
    public static void IOFromConstMem() => SDL_IOFromConstMem();
    public static void IOFromDynamicMem() => SDL_IOFromDynamicMem();
    public static void IOFromFile() => SDL_IOFromFile();
    public static void IOFromMem() => SDL_IOFromMem();
    public static void IOprintf() => SDL_IOprintf();
    public static void IOvprintf() => SDL_IOvprintf();
    public static void LoadFile() => SDL_LoadFile();
    public static void LoadFile_IO() => SDL_LoadFile_IO();
    public static void OpenIO() => SDL_OpenIO();
    public static void ReadIO() => SDL_ReadIO();
    public static void ReadS16BE() => SDL_ReadS16BE();
    public static void ReadS16LE() => SDL_ReadS16LE();
    public static void ReadS32BE() => SDL_ReadS32BE();
    public static void ReadS32LE() => SDL_ReadS32LE();
    public static void ReadS64BE() => SDL_ReadS64BE();
    public static void ReadS64LE() => SDL_ReadS64LE();
    public static void ReadS8() => SDL_ReadS8();
    public static void ReadU16BE() => SDL_ReadU16BE();
    public static void ReadU16LE() => SDL_ReadU16LE();
    public static void ReadU32BE() => SDL_ReadU32BE();
    public static void ReadU32LE() => SDL_ReadU32LE();
    public static void ReadU64BE() => SDL_ReadU64BE();
    public static void ReadU64LE() => SDL_ReadU64LE();
    public static void ReadU8() => SDL_ReadU8();
    public static void SaveFile() => SDL_SaveFile();
    public static void SaveFile_IO() => SDL_SaveFile_IO();
    public static void SeekIO() => SDL_SeekIO();
    public static void TellIO() => SDL_TellIO();
    public static void WriteIO() => SDL_WriteIO();
    public static void WriteS16BE() => SDL_WriteS16BE();
    public static void WriteS16LE() => SDL_WriteS16LE();
    public static void WriteS32BE() => SDL_WriteS32BE();
    public static void WriteS32LE() => SDL_WriteS32LE();
    public static void WriteS64BE() => SDL_WriteS64BE();
    public static void WriteS64LE() => SDL_WriteS64LE();
    public static void WriteS8() => SDL_WriteS8();
    public static void WriteU16BE() => SDL_WriteU16BE();
    public static void WriteU16LE() => SDL_WriteU16LE();
    public static void WriteU32BE() => SDL_WriteU32BE();
    public static void WriteU32LE() => SDL_WriteU32LE();
    public static void WriteU64BE() => SDL_WriteU64BE();
    public static void WriteU64LE() => SDL_WriteU64LE();
    public static void WriteU8() => SDL_WriteU8();
}