using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDLAPI
{
    public static bool CloseIo(SDL_IOStream* context) => SDL_CloseIO(context);
    public static bool FlushIo(SDL_IOStream* context) => SDL_FlushIO(context);
    public static SDL_PropertiesID GetIoProperties(SDL_IOStream* context) => SDL_GetIOProperties(context);
    public static long GetIoSize(SDL_IOStream* context) => SDL_GetIOSize(context);
    public static SDL_IOStatus GetIoStatus(SDL_IOStream* context) => SDL_GetIOStatus(context);
    public static SDL_IOStream* IoFromConstMem(IntPtr mem, UIntPtr size) => SDL_IOFromConstMem(mem, size);
    public static SDL_IOStream* IoFromDynamicMem() => SDL_IOFromDynamicMem();
    public static SDL_IOStream* IoFromFile(byte* file, byte* mode) => SDL_IOFromFile(file, mode);
    public static SDL_IOStream* IoFromFile(string file, string mode) => SDL_IOFromFile(file, mode);
    public static SDL_IOStream* IoFromMem(IntPtr mem, UIntPtr size) => SDL_IOFromMem(mem, size);
    public static UIntPtr IOprintf(SDL_IOStream* context, byte* fmt) => SDL_IOprintf(context, fmt, __arglist());
    public static UIntPtr Ovprintf(SDL_IOStream* context, byte* fmt, byte* ap) => SDL_IOvprintf(context, fmt, ap);
    public static UIntPtr Ovprintf(SDL_IOStream* context, string fmt, byte* ap) => SDL_IOvprintf(context, fmt, ap);
    public static IntPtr LoadFile(byte* file, UIntPtr* datasize) => SDL_LoadFile(file, datasize);
    public static IntPtr LoadFile(string file, UIntPtr* datasize) => SDL_LoadFile(file, datasize);
    public static IntPtr LoadFile_IO(SDL_IOStream* src, UIntPtr* datasize, bool closeio) => SDL_LoadFile_IO(src, datasize, closeio);
    public static SDL_IOStream* OpenIo(SDL_IOStreamInterface* iface, IntPtr userdata) => SDL_OpenIO(iface, userdata);
    public static UIntPtr ReadIo(SDL_IOStream* context, IntPtr ptr, UIntPtr size) => SDL_ReadIO(context, ptr, size);
    public static bool ReadS16Be(SDL_IOStream* src, short* value) => SDL_ReadS16BE(src, value);
    public static bool ReadS16Le(SDL_IOStream* src, short* value) => SDL_ReadS16LE(src, value);
    public static bool ReadS32Be(SDL_IOStream* src, int* value) => SDL_ReadS32BE(src, value);
    public static bool ReadS32Le(SDL_IOStream* src, int* value) => SDL_ReadS32LE(src, value);
    public static bool ReadS64Be(SDL_IOStream* src, long* value) => SDL_ReadS64BE(src, value);
    public static bool ReadS64Le(SDL_IOStream* src, long* value) => SDL_ReadS64LE(src, value);
    public static bool ReadS8(SDL_IOStream* src, sbyte* value) => SDL_ReadS8(src, value);
    public static bool ReadU16Be(SDL_IOStream* src, ushort* value) => SDL_ReadU16BE(src, value);
    public static bool ReadU16Le(SDL_IOStream* src, ushort* value) => SDL_ReadU16LE(src, value);
    public static bool ReadU32Be(SDL_IOStream* src, uint* value) => SDL_ReadU32BE(src, value);
    public static bool ReadU32Le(SDL_IOStream* src, uint* value) => SDL_ReadU32LE(src, value);
    public static bool ReadU64Be(SDL_IOStream* src, ulong* value) => SDL_ReadU64BE(src, value);
    public static bool ReadU64Le(SDL_IOStream* src, ulong* value) => SDL_ReadU64LE(src, value);
    public static bool ReadU8(SDL_IOStream* src, byte* value) => SDL_ReadU8(src, value);
    public static bool SaveFile(byte* file, IntPtr data, UIntPtr datasize) => SDL_SaveFile(file, data, datasize);
    public static bool SaveFile(string file, IntPtr data, UIntPtr datasize) => SDL_SaveFile(file, data, datasize);
    public static bool SaveFile_IO(SDL_IOStream* src, IntPtr data, UIntPtr datasize, bool closeio) => SDL_SaveFile_IO(src, data, datasize, closeio);
    public static long SeekIo(SDL_IOStream* context, long offset, SDL_IOWhence whence) => SDL_SeekIO(context, offset, whence);
    public static long TellIo(SDL_IOStream* context) => SDL_TellIO(context);
    public static UIntPtr WriteIo(SDL_IOStream* context, IntPtr ptr, UIntPtr size) => SDL_WriteIO(context, ptr, size);
    public static bool WriteS16Be(SDL_IOStream* dst, short value) => SDL_WriteS16BE(dst, value);
    public static bool WriteS16Le(SDL_IOStream* dst, short value) => SDL_WriteS16LE(dst, value);
    public static bool WriteS32Be(SDL_IOStream* dst, int value) => SDL_WriteS32BE(dst, value);
    public static bool WriteS32Le(SDL_IOStream* dst, int value) => SDL_WriteS32LE(dst, value);
    public static bool WriteS64Be(SDL_IOStream* dst, long value) => SDL_WriteS64BE(dst, value);
    public static bool WriteS64Le(SDL_IOStream* dst, long value) => SDL_WriteS64LE(dst, value);
    public static bool WriteS8(SDL_IOStream* dst, sbyte value) => SDL_WriteS8(dst, value);
    public static bool WriteU16Be(SDL_IOStream* dst, ushort value) => SDL_WriteU16BE(dst, value);
    public static bool WriteU16Le(SDL_IOStream* dst, ushort value) => SDL_WriteU16LE(dst, value);
    public static bool WriteU32Be(SDL_IOStream* dst, uint value) => SDL_WriteU32BE(dst, value);
    public static bool WriteU32Le(SDL_IOStream* dst, uint value) => SDL_WriteU32LE(dst, value);
    public static bool WriteU64Be(SDL_IOStream* dst, ulong value) => SDL_WriteU64BE(dst, value);
    public static bool WriteU64Le(SDL_IOStream* dst, ulong value) => SDL_WriteU64LE(dst, value);
    public static bool WriteU8(SDL_IOStream* dst, byte value) => SDL_WriteU8(dst, value);
}