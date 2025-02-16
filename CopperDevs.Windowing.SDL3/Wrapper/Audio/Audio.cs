using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void AudioDevicePaused() => SDL_AudioDevicePaused();
    public static void AudioStreamDevicePaused() => SDL_AudioStreamDevicePaused();
    public static void BindAudioStream() => SDL_BindAudioStream();
    public static void BindAudioStreams() => SDL_BindAudioStreams();
    public static void ClearAudioStream() => SDL_ClearAudioStream();
    public static void CloseAudioDevice() => SDL_CloseAudioDevice();
    public static void ConvertAudioSamples() => SDL_ConvertAudioSamples();
    public static void CreateAudioStream() => SDL_CreateAudioStream();
    public static void DestroyAudioStream() => SDL_DestroyAudioStream();
    public static void FlushAudioStream() => SDL_FlushAudioStream();
    public static void GetAudioDeviceChannelMap() => SDL_GetAudioDeviceChannelMap();
    public static void GetAudioDeviceFormat() => SDL_GetAudioDeviceFormat();
    public static void GetAudioDeviceGain() => SDL_GetAudioDeviceGain();
    public static void GetAudioDeviceName() => SDL_GetAudioDeviceName();
    public static void GetAudioDriver() => SDL_GetAudioDriver();
    public static void GetAudioFormatName() => SDL_GetAudioFormatName();
    public static void GetAudioPlaybackDevices() => SDL_GetAudioPlaybackDevices();
    public static void GetAudioRecordingDevices() => SDL_GetAudioRecordingDevices();
    public static void GetAudioStreamAvailable() => SDL_GetAudioStreamAvailable();
    public static void GetAudioStreamData() => SDL_GetAudioStreamData();
    public static void GetAudioStreamDevice() => SDL_GetAudioStreamDevice();
    public static void GetAudioStreamFormat() => SDL_GetAudioStreamFormat();
    public static void GetAudioStreamFrequencyRatio() => SDL_GetAudioStreamFrequencyRatio();
    public static void GetAudioStreamGain() => SDL_GetAudioStreamGain();
    public static void GetAudioStreamInputChannelMap() => SDL_GetAudioStreamInputChannelMap();
    public static void GetAudioStreamOutputChannelMap() => SDL_GetAudioStreamOutputChannelMap();
    public static void GetAudioStreamProperties() => SDL_GetAudioStreamProperties();
    public static void GetAudioStreamQueued() => SDL_GetAudioStreamQueued();
    public static void GetCurrentAudioDriver() => SDL_GetCurrentAudioDriver();
    public static void GetNumAudioDrivers() => SDL_GetNumAudioDrivers();
    public static void GetSilenceValueForFormat() => SDL_GetSilenceValueForFormat();
    public static void IsAudioDevicePhysical() => SDL_IsAudioDevicePhysical();
    public static void IsAudioDevicePlayback() => SDL_IsAudioDevicePlayback();
    public static void LoadWAV() => SDL_LoadWAV();
    public static void LoadWAV_IO() => SDL_LoadWAV_IO();
    public static void LockAudioStream() => SDL_LockAudioStream();
    public static void MixAudio() => SDL_MixAudio();
    public static void OpenAudioDevice() => SDL_OpenAudioDevice();
    public static void OpenAudioDeviceStream() => SDL_OpenAudioDeviceStream();
    public static void PauseAudioDevice() => SDL_PauseAudioDevice();
    public static void PauseAudioStreamDevice() => SDL_PauseAudioStreamDevice();
    public static void PutAudioStreamData() => SDL_PutAudioStreamData();
    public static void ResumeAudioDevice() => SDL_ResumeAudioDevice();
    public static void ResumeAudioStreamDevice() => SDL_ResumeAudioStreamDevice();
    public static void SetAudioDeviceGain() => SDL_SetAudioDeviceGain();
    public static void SetAudioPostmixCallback() => SDL_SetAudioPostmixCallback();
    public static void SetAudioStreamFormat() => SDL_SetAudioStreamFormat();
    public static void SetAudioStreamFrequencyRatio() => SDL_SetAudioStreamFrequencyRatio();
    public static void SetAudioStreamGain() => SDL_SetAudioStreamGain();
    public static void SetAudioStreamGetCallback() => SDL_SetAudioStreamGetCallback();
    public static void SetAudioStreamInputChannelMap() => SDL_SetAudioStreamInputChannelMap();
    public static void SetAudioStreamOutputChannelMap() => SDL_SetAudioStreamOutputChannelMap();
    public static void SetAudioStreamPutCallback() => SDL_SetAudioStreamPutCallback();
    public static void UnbindAudioStream() => SDL_UnbindAudioStream();
    public static void UnbindAudioStreams() => SDL_UnbindAudioStreams();
    public static void UnlockAudioStream() => SDL_UnlockAudioStream();
}