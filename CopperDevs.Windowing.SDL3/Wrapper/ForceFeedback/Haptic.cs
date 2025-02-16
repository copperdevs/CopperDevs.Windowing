using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void CloseHaptic() => SDL_CloseHaptic();
    public static void CreateHapticEffect() => SDL_CreateHapticEffect();
    public static void DestroyHapticEffect() => SDL_DestroyHapticEffect();
    public static void GetHapticEffectStatus() => SDL_GetHapticEffectStatus();
    public static void GetHapticFeatures() => SDL_GetHapticFeatures();
    public static void GetHapticFromID() => SDL_GetHapticFromID();
    public static void GetHapticID() => SDL_GetHapticID();
    public static void GetHapticName() => SDL_GetHapticName();
    public static void GetHapticNameForID() => SDL_GetHapticNameForID();
    public static void GetHaptics() => SDL_GetHaptics();
    public static void GetMaxHapticEffects() => SDL_GetMaxHapticEffects();
    public static void GetMaxHapticEffectsPlaying() => SDL_GetMaxHapticEffectsPlaying();
    public static void GetNumHapticAxes() => SDL_GetNumHapticAxes();
    public static void HapticEffectSupported() => SDL_HapticEffectSupported();
    public static void HapticRumbleSupported() => SDL_HapticRumbleSupported();
    public static void InitHapticRumble() => SDL_InitHapticRumble();
    public static void IsJoystickHaptic() => SDL_IsJoystickHaptic();
    public static void IsMouseHaptic() => SDL_IsMouseHaptic();
    public static void OpenHaptic() => SDL_OpenHaptic();
    public static void OpenHapticFromJoystick() => SDL_OpenHapticFromJoystick();
    public static void OpenHapticFromMouse() => SDL_OpenHapticFromMouse();
    public static void PauseHaptic() => SDL_PauseHaptic();
    public static void PlayHapticRumble() => SDL_PlayHapticRumble();
    public static void ResumeHaptic() => SDL_ResumeHaptic();
    public static void RunHapticEffect() => SDL_RunHapticEffect();
    public static void SetHapticAutocenter() => SDL_SetHapticAutocenter();
    public static void SetHapticGain() => SDL_SetHapticGain();
    public static void StopHapticEffect() => SDL_StopHapticEffect();
    public static void StopHapticEffects() => SDL_StopHapticEffects();
    public static void StopHapticRumble() => SDL_StopHapticRumble();
    public static void UpdateHapticEffect() => SDL_UpdateHapticEffect();
}