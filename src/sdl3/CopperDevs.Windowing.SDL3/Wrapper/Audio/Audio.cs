#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDLAPI
{
    public static bool AudioDevicePaused(SDL_AudioDeviceID devid) => SDL_AudioDevicePaused(devid);
    public static bool AudioStreamDevicePaused(SDL_AudioStream* stream) => SDL_AudioStreamDevicePaused(stream);
    public static bool BindAudioStream(SDL_AudioDeviceID devid, SDL_AudioStream* stream) => SDL_BindAudioStream(devid, stream);
    public static bool BindAudioStreams(SDL_AudioDeviceID devid, SDL_AudioStream** streams, int numStreams) => SDL_BindAudioStreams(devid, streams, numStreams);
    public static bool ClearAudioStream(SDL_AudioStream* stream) => SDL_ClearAudioStream(stream);
    public static void CloseAudioDevice(SDL_AudioDeviceID devid) => SDL_CloseAudioDevice(devid);

    public static bool ConvertAudioSamples(SDL_AudioSpec* srcSpec, byte* srcData, int srcLen, SDL_AudioSpec* dstSpec, byte** dstData, int* dstLen) =>
        SDL_ConvertAudioSamples(srcSpec, srcData, srcLen, dstSpec, dstData, dstLen);

    public static SDL_AudioStream* CreateAudioStream(SDL_AudioSpec* srcSpec, SDL_AudioSpec* dstSpec) => SDL_CreateAudioStream(srcSpec, dstSpec);
    public static void DestroyAudioStream(SDL_AudioStream* stream) => SDL_DestroyAudioStream(stream);
    public static bool FlushAudioStream(SDL_AudioStream* stream) => SDL_FlushAudioStream(stream);
    public static int* GetAudioDeviceChannelMap(SDL_AudioDeviceID devid, int* count) => SDL_GetAudioDeviceChannelMap(devid, count);
    public static bool GetAudioDeviceFormat(SDL_AudioDeviceID devid, SDL_AudioSpec* spec, int* sampleFrames) => SDL_GetAudioDeviceFormat(devid, spec, sampleFrames);
    public static float GetAudioDeviceGain(SDL_AudioDeviceID devid) => SDL_GetAudioDeviceGain(devid);
    public static string GetAudioDeviceName(SDL_AudioDeviceID devid) => SDL_GetAudioDeviceName(devid) ?? string.Empty;
    public static string GetAudioDriver(int index) => SDL_GetAudioDriver(index) ?? string.Empty;
    public static string GetAudioFormatName(SDL_AudioFormat format) => SDL_GetAudioFormatName(format) ?? string.Empty;
    public static SDL_AudioDeviceID* GetAudioPlaybackDevices(int* count) => SDL_GetAudioPlaybackDevices(count);
    public static SDL_AudioDeviceID[] GetAudioPlaybackDevices() => SDLUtil.ToArray(SDL_GetAudioPlaybackDevices());
    public static SDL_AudioDeviceID* GetAudioRecordingDevices(int* count) => SDL_GetAudioRecordingDevices(count);
    public static SDL_AudioDeviceID[] GetAudioRecordingDevices() => SDLUtil.ToArray(SDL_GetAudioRecordingDevices());
    public static int GetAudioStreamAvailable(SDL_AudioStream* stream) => SDL_GetAudioStreamAvailable(stream);
    public static int GetAudioStreamData(SDL_AudioStream* stream, IntPtr buf, int len) => SDL_GetAudioStreamData(stream, buf, len);
    public static SDL_AudioDeviceID GetAudioStreamDevice(SDL_AudioStream* stream) => SDL_GetAudioStreamDevice(stream);
    public static bool GetAudioStreamFormat(SDL_AudioStream* stream, SDL_AudioSpec* srcSpec, SDL_AudioSpec* dstSpec) => SDL_GetAudioStreamFormat(stream, srcSpec, dstSpec);
    public static float GetAudioStreamFrequencyRatio(SDL_AudioStream* stream) => SDL_GetAudioStreamFrequencyRatio(stream);
    public static float GetAudioStreamGain(SDL_AudioStream* stream) => SDL_GetAudioStreamGain(stream);
    public static int* GetAudioStreamInputChannelMap(SDL_AudioStream* stream, int* count) => SDL_GetAudioStreamInputChannelMap(stream, count);
    public static int[] GetAudioStreamInputChannelMap(SDL_AudioStream* stream) => SDLUtil.ToArray(SDL_GetAudioStreamInputChannelMap(stream));
    public static int* GetAudioStreamOutputChannelMap(SDL_AudioStream* stream, int* count) => SDL_GetAudioStreamOutputChannelMap(stream, count);
    public static int[] GetAudioStreamOutputChannelMap(SDL_AudioStream* stream) => SDLUtil.ToArray(SDL_GetAudioStreamOutputChannelMap(stream));
    public static SDL_PropertiesID GetAudioStreamProperties(SDL_AudioStream* stream) => SDL_GetAudioStreamProperties(stream);
    public static int GetAudioStreamQueued(SDL_AudioStream* stream) => SDL_GetAudioStreamQueued(stream);
    public static string GetCurrentAudioDriver() => SDL_GetCurrentAudioDriver() ?? string.Empty;
    public static int GetNumAudioDrivers() => SDL_GetNumAudioDrivers();
    public static int GetSilenceValueForFormat(SDL_AudioFormat format) => SDL_GetSilenceValueForFormat(format);
    public static bool IsAudioDevicePhysical(SDL_AudioDeviceID devid) => SDL_IsAudioDevicePhysical(devid);
    public static bool IsAudioDevicePlayback(SDL_AudioDeviceID devid) => SDL_IsAudioDevicePlayback(devid);
    public static bool LoadWav(byte* path, SDL_AudioSpec* spec, byte** audioBuf, uint* audioLen) => SDL_LoadWAV(path, spec, audioBuf, audioLen);
    public static bool LoadWav(string path, SDL_AudioSpec* spec, byte** audioBuf, uint* audioLen) => SDL_LoadWAV(path, spec, audioBuf, audioLen);
    public static bool LoadWAV_IO(SDL_IOStream* src, bool closeio, SDL_AudioSpec* spec, byte** audioBuf, uint* audioLen) => SDL_LoadWAV_IO(src, closeio, spec, audioBuf, audioLen);
    public static bool LockAudioStream(SDL_AudioStream* stream) => SDL_LockAudioStream(stream);
    public static bool MixAudio(byte* dst, byte* src, SDL_AudioFormat format, uint len, float volume) => SDL_MixAudio(dst, src, format, len, volume);

    public static SDL_AudioDeviceID OpenAudioDevice(SDL_AudioDeviceID devid, SDL_AudioSpec* spec) => SDL_OpenAudioDevice(devid, spec);

    public static SDL_AudioStream* OpenAudioDeviceStream(SDL_AudioDeviceID devid, SDL_AudioSpec* spec, delegate*unmanaged[Cdecl]<IntPtr, SDL_AudioStream*, int, int, void> callback, IntPtr userdata) =>
        SDL_OpenAudioDeviceStream(devid, spec, callback, userdata);

    public static bool PauseAudioDevice(SDL_AudioDeviceID devid) => SDL_PauseAudioDevice(devid);
    public static bool PauseAudioStreamDevice(SDL_AudioStream* stream) => SDL_PauseAudioStreamDevice(stream);
    public static bool PutAudioStreamData(SDL_AudioStream* stream, IntPtr buf, int len) => SDL_PutAudioStreamData(stream, buf, len);
    public static bool ResumeAudioDevice(SDL_AudioDeviceID devid) => SDL_ResumeAudioDevice(devid);
    public static bool ResumeAudioStreamDevice(SDL_AudioStream* stream) => SDL_ResumeAudioStreamDevice(stream);

    public static bool SetAudioDeviceGain(SDL_AudioDeviceID devid, float gain) => SDL_SetAudioDeviceGain(devid, gain);

    public static bool SetAudioPostmixCallback(SDL_AudioDeviceID devid, delegate*unmanaged[Cdecl]<IntPtr, SDL_AudioSpec*, float*, int, void> callback, IntPtr userdata) =>
        SDL_SetAudioPostmixCallback(devid, callback, userdata);

    public static bool SetAudioStreamFormat(SDL_AudioStream* stream, SDL_AudioSpec* srcSpec, SDL_AudioSpec* dstSpec) => SDL_SetAudioStreamFormat(stream, srcSpec, dstSpec);
    public static bool SetAudioStreamFrequencyRatio(SDL_AudioStream* stream, float ratio) => SDL_SetAudioStreamFrequencyRatio(stream, ratio);

    public static bool SetAudioStreamGain(SDL_AudioStream* stream, float gain) => SDL_SetAudioStreamGain(stream, gain);

    public static bool SetAudioStreamGetCallback(SDL_AudioStream* stream, delegate*unmanaged[Cdecl]<IntPtr, SDL_AudioStream*, int, int, void> callback, IntPtr userdata) =>
        SDL_SetAudioStreamGetCallback(stream, callback, userdata);

    public static bool SetAudioStreamInputChannelMap(SDL_AudioStream* stream, int* chmap, int count) => SDL_SetAudioStreamInputChannelMap(stream, chmap, count);

    public static bool SetAudioStreamOutputChannelMap(SDL_AudioStream* stream, int* chmap, int count) => SDL_SetAudioStreamOutputChannelMap(stream, chmap, count);

    public static bool SetAudioStreamPutCallback(SDL_AudioStream* stream, delegate*unmanaged[Cdecl]<IntPtr, SDL_AudioStream*, int, int, void> callback, IntPtr userdata) =>
        SDL_SetAudioStreamPutCallback(stream, callback, userdata);

    public static void UnbindAudioStream(SDL_AudioStream* stream) => SDL_UnbindAudioStream(stream);
    public static void UnbindAudioStreams(SDL_AudioStream** streams, int numStreams) => SDL_UnbindAudioStreams(streams, numStreams);
    public static bool UnlockAudioStream(SDL_AudioStream* stream) => SDL_UnlockAudioStream(stream);
}