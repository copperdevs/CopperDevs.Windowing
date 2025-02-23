using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDLAPI
{
    public static int AddGamepadMapping(byte* mapping) => SDL_AddGamepadMapping(mapping);
    public static int AddGamepadMapping(string mapping) => SDL_AddGamepadMapping(mapping);
    public static int AddGamepadMappingsFromFile(byte* file) => SDL_AddGamepadMappingsFromFile(file);
    public static int AddGamepadMappingsFromFile(string file) => SDL_AddGamepadMappingsFromFile(file);
    public static int AddGamepadMappingsFromIo(SDL_IOStream* src, bool closeio) => SDL_AddGamepadMappingsFromIO(src, closeio);
    public static void CloseGamepad(SDL_Gamepad* gamepad) => SDL_CloseGamepad(gamepad);
    public static bool GamepadConnected(SDL_Gamepad* gamepad) => SDL_GamepadConnected(gamepad);
    public static bool GamepadEventsEnabled() => SDL_GamepadEventsEnabled();
    public static bool GamepadHasAxis(SDL_Gamepad* gamepad, SDL_GamepadAxis axis) => SDL_GamepadHasAxis(gamepad, axis);
    public static bool GamepadHasButton(SDL_Gamepad* gamepad, SDL_GamepadButton button) => SDL_GamepadHasButton(gamepad, button);
    public static bool GamepadHasSensor(SDL_Gamepad* gamepad, SDL_SensorType type) => SDL_GamepadHasSensor(gamepad, type);
    public static bool GamepadSensorEnabled(SDL_Gamepad* gamepad, SDL_SensorType type) => SDL_GamepadSensorEnabled(gamepad, type);
    public static string GetGamepadAppleSfSymbolsNameForAxis(SDL_Gamepad* gamepad, SDL_GamepadAxis axis) => SDL_GetGamepadAppleSFSymbolsNameForAxis(gamepad, axis) ?? string.Empty;
    public static string GetGamepadAppleSfSymbolsNameForButton(SDL_Gamepad* gamepad, SDL_GamepadButton button) => SDL_GetGamepadAppleSFSymbolsNameForButton(gamepad, button) ?? string.Empty;
    public static short GetGamepadAxis(SDL_Gamepad* gamepad, SDL_GamepadAxis axis) => SDL_GetGamepadAxis(gamepad, axis);
    public static SDL_GamepadAxis GetGamepadAxisFromString(byte* str) => SDL_GetGamepadAxisFromString(str);
    public static SDL_GamepadAxis GetGamepadAxisFromString(string str) => SDL_GetGamepadAxisFromString(str);
    public static SDL_GamepadBinding** GetGamepadBindings(SDL_Gamepad* gamepad, int* count) => SDL_GetGamepadBindings(gamepad, count);
    public static SDL_GamepadBinding[] GetGamepadBindings(SDL_Gamepad* gamepad) => SDLUtil.ToArray(SDL_GetGamepadBindings(gamepad));
    public static bool GetGamepadButton(SDL_Gamepad* gamepad, SDL_GamepadButton button) => SDL_GetGamepadButton(gamepad, button);
    public static SDL_GamepadButton GetGamepadButtonFromString(byte* str) => SDL_GetGamepadButtonFromString(str);
    public static SDL_GamepadButton GetGamepadButtonFromString(string str) => SDL_GetGamepadButtonFromString(str);
    public static SDL_GamepadButtonLabel GetGamepadButtonLabel(SDL_Gamepad* gamepad, SDL_GamepadButton button) => SDL_GetGamepadButtonLabel(gamepad, button);
    public static SDL_GamepadButtonLabel GetGamepadButtonLabelForType(SDL_GamepadType type, SDL_GamepadButton button) => SDL_GetGamepadButtonLabelForType(type, button);
    public static SDL_JoystickConnectionState GetGamepadConnectionState(SDL_Gamepad* gamepad) => SDL_GetGamepadConnectionState(gamepad);
    public static ushort GetGamepadFirmwareVersion(SDL_Gamepad* gamepad) => SDL_GetGamepadFirmwareVersion(gamepad);
    public static SDL_Gamepad* GetGamepadFromId(SDL_JoystickID instanceId) => SDL_GetGamepadFromID(instanceId);
    public static SDL_Gamepad* GetGamepadFromPlayerIndex(int playerIndex) => SDL_GetGamepadFromPlayerIndex(playerIndex);
    public static SDL_GUID GetGamepadGuidForId(SDL_JoystickID instanceId) => SDL_GetGamepadGUIDForID(instanceId);
    public static SDL_JoystickID GetGamepadId(SDL_Gamepad* gamepad) => SDL_GetGamepadID(gamepad);
    public static SDL_Joystick* GetGamepadJoystick(SDL_Gamepad* gamepad) => SDL_GetGamepadJoystick(gamepad);
    public static string GetGamepadMapping(SDL_Gamepad* gamepad) => SDL_GetGamepadMapping(gamepad) ?? string.Empty;
    public static string GetGamepadMappingForGuid(SDL_GUID guid) => SDL_GetGamepadMappingForGUID(guid) ?? string.Empty;
    public static string GetGamepadMappingForId(SDL_JoystickID instanceId) => SDL_GetGamepadMappingForID(instanceId) ?? string.Empty;
    public static byte** GetGamepadMappings(int* count) => SDL_GetGamepadMappings(count);
    public static IntPtr[] GetGamepadMappings() => SDLUtil.ToArray(SDL_GetGamepadMappings());
    public static string GetGamepadName(SDL_Gamepad* gamepad) => SDL_GetGamepadName(gamepad) ?? string.Empty;
    public static string GetGamepadNameForId(SDL_JoystickID instanceId) => SDL_GetGamepadNameForID(instanceId) ?? string.Empty;
    public static string GetGamepadPath(SDL_Gamepad* gamepad) => SDL_GetGamepadPath(gamepad) ?? string.Empty;
    public static string GetGamepadPathForId(SDL_JoystickID instanceId) => SDL_GetGamepadPathForID(instanceId) ?? string.Empty;
    public static int GetGamepadPlayerIndex(SDL_Gamepad* gamepad) => SDL_GetGamepadPlayerIndex(gamepad);
    public static int GetGamepadPlayerIndexForId(SDL_JoystickID instanceId) => SDL_GetGamepadPlayerIndexForID(instanceId);
    public static SDL_PowerState GetGamepadPowerInfo(SDL_Gamepad* gamepad, int* percent) => SDL_GetGamepadPowerInfo(gamepad, percent);
    public static ushort GetGamepadProduct(SDL_Gamepad* gamepad) => SDL_GetGamepadProduct(gamepad);
    public static ushort GetGamepadProductForId(SDL_JoystickID instanceId) => SDL_GetGamepadProductForID(instanceId);
    public static ushort GetGamepadProductVersion(SDL_Gamepad* gamepad) => SDL_GetGamepadProductVersion(gamepad);
    public static ushort GetGamepadProductVersionForId(SDL_JoystickID instanceId) => SDL_GetGamepadProductVersionForID(instanceId);
    public static SDL_PropertiesID GetGamepadProperties(SDL_Gamepad* gamepad) => SDL_GetGamepadProperties(gamepad);
    public static SDL_JoystickID* GetGamepads(int* count) => SDL_GetGamepads(count);
    public static SDL_JoystickID[] GetGamepads() => SDLUtil.ToArray(SDL_GetGamepads());
    public static bool GetGamepadSensorData(SDL_Gamepad* gamepad, SDL_SensorType type, float* data, int numValues) => SDL_GetGamepadSensorData(gamepad, type, data, numValues);
    public static float GetGamepadSensorDataRate(SDL_Gamepad* gamepad, SDL_SensorType type) => SDL_GetGamepadSensorDataRate(gamepad, type);
    public static string GetGamepadSerial(SDL_Gamepad* gamepad) => SDL_GetGamepadSerial(gamepad) ?? string.Empty;
    public static ulong GetGamepadSteamHandle(SDL_Gamepad* gamepad) => SDL_GetGamepadSteamHandle(gamepad);
    public static string GetGamepadStringForAxis(SDL_GamepadAxis axis) => SDL_GetGamepadStringForAxis(axis) ?? string.Empty;
    public static string GetGamepadStringForButton(SDL_GamepadButton button) => SDL_GetGamepadStringForButton(button) ?? string.Empty;
    public static string GetGamepadStringForType(SDL_GamepadType type) => SDL_GetGamepadStringForType(type) ?? string.Empty;
    public static bool GetGamepadTouchpadFinger(SDL_Gamepad* gamepad, int touchpad, int finger, SDLBool* down, float* x, float* y, float* pressure) => SDL_GetGamepadTouchpadFinger(gamepad, touchpad, finger, down, x, y, pressure);
    public static SDL_GamepadType GetGamepadType(SDL_Gamepad* gamepad) => SDL_GetGamepadType(gamepad);
    public static SDL_GamepadType GetGamepadTypeForId(SDL_JoystickID instanceId) => SDL_GetGamepadTypeForID(instanceId);
    public static SDL_GamepadType GetGamepadTypeFromString(byte* str) => SDL_GetGamepadTypeFromString(str);
    public static SDL_GamepadType GetGamepadTypeFromString(string str) => SDL_GetGamepadTypeFromString(str);
    public static ushort GetGamepadVendor(SDL_Gamepad* gamepad) => SDL_GetGamepadVendor(gamepad);
    public static ushort GetGamepadVendorForId(SDL_JoystickID instanceId) => SDL_GetGamepadVendorForID(instanceId);
    public static int GetNumGamepadTouchpadFingers(SDL_Gamepad* gamepad, int touchpad) => SDL_GetNumGamepadTouchpadFingers(gamepad, touchpad);
    public static int GetNumGamepadTouchpads(SDL_Gamepad* gamepad) => SDL_GetNumGamepadTouchpads(gamepad);
    public static SDL_GamepadType GetRealGamepadType(SDL_Gamepad* gamepad) => SDL_GetRealGamepadType(gamepad);
    public static SDL_GamepadType GetRealGamepadTypeForId(SDL_JoystickID instanceId) => SDL_GetRealGamepadTypeForID(instanceId);
    public static bool HasGamepad() => SDL_HasGamepad();
    public static bool IsGamepad(SDL_JoystickID instanceId) => SDL_IsGamepad(instanceId);
    public static SDL_Gamepad* OpenGamepad(SDL_JoystickID instanceId) => SDL_OpenGamepad(instanceId);
    public static bool ReloadGamepadMappings() => SDL_ReloadGamepadMappings();
    public static bool RumbleGamepad(SDL_Gamepad* gamepad, ushort lowFrequencyRumble, ushort highFrequencyRumble, uint durationMs) => SDL_RumbleGamepad(gamepad, lowFrequencyRumble, highFrequencyRumble, durationMs);
    public static bool RumbleGamepadTriggers(SDL_Gamepad* gamepad, ushort leftRumble, ushort rightRumble, uint durationMs) => SDL_RumbleGamepadTriggers(gamepad, leftRumble, rightRumble, durationMs);
    public static bool SendGamepadEffect(SDL_Gamepad* gamepad, IntPtr data, int size) => SDL_SendGamepadEffect(gamepad, data, size);
    public static void SetGamepadEventsEnabled(bool enabled) => SDL_SetGamepadEventsEnabled(enabled);
    public static bool SetGamepadLed(SDL_Gamepad* gamepad, byte red, byte green, byte blue) => SDL_SetGamepadLED(gamepad, red, green, blue);
    public static bool SetGamepadMapping(SDL_JoystickID instanceId, byte* mapping) => SDL_SetGamepadMapping(instanceId, mapping);
    public static bool SetGamepadMapping(SDL_JoystickID instanceId, string mapping) => SDL_SetGamepadMapping(instanceId, mapping);
    public static bool SetGamepadPlayerIndex(SDL_Gamepad* gamepad, int playerIndex) => SDL_SetGamepadPlayerIndex(gamepad, playerIndex);
    public static bool SetGamepadSensorEnabled(SDL_Gamepad* gamepad, SDL_SensorType type, bool enabled) => SDL_SetGamepadSensorEnabled(gamepad, type, enabled);
    public static void UpdateGamepads() => SDL_UpdateGamepads();
}