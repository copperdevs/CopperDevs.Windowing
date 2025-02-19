using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void CloseHaptic(SDL_Haptic* haptic) => SDL_CloseHaptic(haptic);
    public static int CreateHapticEffect(SDL_Haptic* haptic, SDL_HapticEffect* effect) => SDL_CreateHapticEffect(haptic, effect);
    public static void DestroyHapticEffect(SDL_Haptic* haptic, int effect) => SDL_DestroyHapticEffect(haptic, effect);
    public static bool GetHapticEffectStatus(SDL_Haptic* haptic, int effect) => SDL_GetHapticEffectStatus(haptic, effect);
    public static uint GetHapticFeatures(SDL_Haptic* haptic) => SDL_GetHapticFeatures(haptic);
    public static SDL_Haptic* GetHapticFromID(SDL_HapticID id) => SDL_GetHapticFromID(id);
    public static SDL_HapticID GetHapticID(SDL_Haptic* haptic) => SDL_GetHapticID(haptic);
    public static string GetHapticName(SDL_Haptic* haptic) => SDL_GetHapticName(haptic) ?? string.Empty;
    public static string GetHapticNameForID(SDL_HapticID id) => SDL_GetHapticNameForID(id) ?? string.Empty;
    public static SDL_HapticID[] GetHaptics() => SDLUtil.ToArray(SDL_GetHaptics());
    public static int GetMaxHapticEffects(SDL_Haptic* haptic) => SDL_GetMaxHapticEffects(haptic);
    public static int GetMaxHapticEffectsPlaying(SDL_Haptic* haptic) => SDL_GetMaxHapticEffectsPlaying(haptic);
    public static int GetNumHapticAxes(SDL_Haptic* haptic) => SDL_GetNumHapticAxes(haptic);
    public static bool HapticEffectSupported(SDL_Haptic* haptic, SDL_HapticEffect* effect) => SDL_HapticEffectSupported(haptic, effect);
    public static bool HapticRumbleSupported(SDL_Haptic* haptic) => SDL_HapticRumbleSupported(haptic);
    public static bool InitHapticRumble(SDL_Haptic* haptic) => SDL_InitHapticRumble(haptic);
    public static bool IsJoystickHaptic(SDL_Joystick* stick) => SDL_IsJoystickHaptic(stick);
    public static bool IsMouseHaptic() => SDL_IsMouseHaptic();
    public static SDL_Haptic* OpenHaptic(SDL_HapticID haptic) => SDL_OpenHaptic(haptic);
    public static SDL_Haptic* OpenHapticFromJoystick(SDL_Joystick* stick) => SDL_OpenHapticFromJoystick(stick);
    public static SDL_Haptic* OpenHapticFromMouse() => SDL_OpenHapticFromMouse();
    public static bool PauseHaptic(SDL_Haptic* haptic) => SDL_PauseHaptic(haptic);
    public static bool PlayHapticRumble(SDL_Haptic* haptic, float strength, uint length) => SDL_PlayHapticRumble(haptic, strength, length);
    public static bool ResumeHaptic(SDL_Haptic* haptic) => SDL_ResumeHaptic(haptic);
    public static bool RunHapticEffect(SDL_Haptic* haptic, int effect, uint iteration) => SDL_RunHapticEffect(haptic, effect, iteration);
    public static bool SetHapticAutocenter(SDL_Haptic* haptic, int autocenter) => SDL_SetHapticAutocenter(haptic, autocenter);
    public static bool SetHapticGain(SDL_Haptic* haptic, int gain) => SDL_SetHapticGain(haptic, gain);
    public static bool StopHapticEffect(SDL_Haptic* haptic, int effect) => SDL_StopHapticEffect(haptic, effect);
    public static bool StopHapticEffects(SDL_Haptic* haptic) => SDL_StopHapticEffects(haptic);
    public static bool StopHapticRumble(SDL_Haptic* haptic) => SDL_StopHapticRumble(haptic);
    public static bool UpdateHapticEffect(SDL_Haptic* haptic, int effect, SDL_HapticEffect* data) => SDL_UpdateHapticEffect(haptic, effect, data);
}