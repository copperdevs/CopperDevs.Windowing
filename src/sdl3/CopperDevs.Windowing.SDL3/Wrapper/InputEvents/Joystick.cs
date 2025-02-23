using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDLAPI
{
    public static SDL_JoystickID AttachVirtualJoystick(SDL_VirtualJoystickDesc* desc) => SDL_AttachVirtualJoystick(desc);
    public static void CloseJoystick(SDL_Joystick* joystick) => SDL_CloseJoystick(joystick);
    public static bool DetachVirtualJoystick(SDL_JoystickID instanceId) => SDL_DetachVirtualJoystick(instanceId);
    public static short GetJoystickAxis(SDL_Joystick* joystick, int axis) => SDL_GetJoystickAxis(joystick, axis);
    public static bool GetJoystickAxisInitialState(SDL_Joystick* joystick, int axis, short* state) => SDL_GetJoystickAxisInitialState(joystick, axis, state);
    public static bool GetJoystickBall(SDL_Joystick* joystick, int ball, int* dx, int* dy) => SDL_GetJoystickBall(joystick, ball, dx, dy);
    public static bool GetJoystickButton(SDL_Joystick* joystick, int button) => SDL_GetJoystickButton(joystick, button);
    public static SDL_JoystickConnectionState GetJoystickConnectionState(SDL_Joystick* joystick) => SDL_GetJoystickConnectionState(joystick);
    public static ushort GetJoystickFirmwareVersion(SDL_Joystick* joystick) => SDL_GetJoystickFirmwareVersion(joystick);
    public static SDL_Joystick* GetJoystickFromId(SDL_JoystickID instanceId) => SDL_GetJoystickFromID(instanceId);
    public static SDL_Joystick* GetJoystickFromPlayerIndex(int playerIndex) => SDL_GetJoystickFromPlayerIndex(playerIndex);
    public static SDL_GUID GetJoystickGuid(SDL_Joystick* joystick) => SDL_GetJoystickGUID(joystick);
    public static SDL_GUID GetJoystickGuidForId(SDL_JoystickID instanceId) => SDL_GetJoystickGUIDForID(instanceId);
    public static void GetJoystickGuidInfo(SDL_GUID guid, ushort* vendor, ushort* product, ushort* version, ushort* crc16) => SDL_GetJoystickGUIDInfo(guid, vendor, product, version, crc16);
    public static byte GetJoystickHat(SDL_Joystick* joystick, int hat) => SDL_GetJoystickHat(joystick, hat);
    public static SDL_JoystickID GetJoystickId(SDL_Joystick* joystick) => SDL_GetJoystickID(joystick);
    public static string GetJoystickName(SDL_Joystick* joystick) => SDL_GetJoystickName(joystick) ?? string.Empty;
    public static string GetJoystickNameForId(SDL_JoystickID instanceId) => SDL_GetJoystickNameForID(instanceId) ?? string.Empty;
    public static string GetJoystickPath(SDL_Joystick* joystick) => SDL_GetJoystickPath(joystick) ?? string.Empty;
    public static string GetJoystickPathForId(SDL_JoystickID instanceId) => SDL_GetJoystickPathForID(instanceId) ?? string.Empty;
    public static int GetJoystickPlayerIndex(SDL_Joystick* joystick) => SDL_GetJoystickPlayerIndex(joystick);
    public static int GetJoystickPlayerIndexForId(SDL_JoystickID instanceId) => SDL_GetJoystickPlayerIndexForID(instanceId);
    public static SDL_PowerState GetJoystickPowerInfo(SDL_Joystick* joystick, int* percent) => SDL_GetJoystickPowerInfo(joystick, percent);
    public static ushort GetJoystickProduct(SDL_Joystick* joystick) => SDL_GetJoystickProduct(joystick);
    public static ushort GetJoystickProductForId(SDL_JoystickID instanceId) => SDL_GetJoystickProductForID(instanceId);
    public static ushort GetJoystickProductVersion(SDL_Joystick* joystick) => SDL_GetJoystickProductVersion(joystick);
    public static ushort GetJoystickProductVersionForId(SDL_JoystickID instanceId) => SDL_GetJoystickProductVersionForID(instanceId);
    public static SDL_PropertiesID GetJoystickProperties(SDL_Joystick* joystick) => SDL_GetJoystickProperties(joystick);
    public static SDL_JoystickID* GetJoysticks(int* count) => SDL_GetJoysticks(count);
    public static SDL_JoystickID[] GetJoysticks() => SDLUtil.ToArray(SDL_GetJoysticks());
    public static string GetJoystickSerial(SDL_Joystick* joystick) => SDL_GetJoystickSerial(joystick) ?? string.Empty;
    public static SDL_JoystickType GetJoystickType(SDL_Joystick* joystick) => SDL_GetJoystickType(joystick);
    public static SDL_JoystickType GetJoystickTypeForId(SDL_JoystickID instanceId) => SDL_GetJoystickTypeForID(instanceId);
    public static ushort GetJoystickVendor(SDL_Joystick* joystick) => SDL_GetJoystickVendor(joystick);
    public static ushort GetJoystickVendorForId(SDL_JoystickID instanceId) => SDL_GetJoystickVendorForID(instanceId);
    public static int GetNumJoystickAxes(SDL_Joystick* joystick) => SDL_GetNumJoystickAxes(joystick);
    public static int GetNumJoystickBalls(SDL_Joystick* joystick) => SDL_GetNumJoystickBalls(joystick);
    public static int GetNumJoystickButtons(SDL_Joystick* joystick) => SDL_GetNumJoystickButtons(joystick);
    public static int GetNumJoystickHats(SDL_Joystick* joystick) => SDL_GetNumJoystickHats(joystick);
    public static bool HasJoystick() => SDL_HasJoystick();
    public static bool IsJoystickVirtual(SDL_JoystickID instanceId) => SDL_IsJoystickVirtual(instanceId);
    public static bool JoystickConnected(SDL_Joystick* joystick) => SDL_JoystickConnected(joystick);
    public static bool JoystickEventsEnabled() => SDL_JoystickEventsEnabled();
    public static void LockJoysticks() => SDL_LockJoysticks();
    public static SDL_Joystick* OpenJoystick(SDL_JoystickID instanceId) => SDL_OpenJoystick(instanceId);
    public static bool RumbleJoystick(SDL_Joystick* joystick, ushort lowFrequencyRumble, ushort highFrequencyRumble, uint durationMs) => SDL_RumbleJoystick(joystick, lowFrequencyRumble, highFrequencyRumble, durationMs);
    public static bool RumbleJoystickTriggers(SDL_Joystick* joystick, ushort leftRumble, ushort rightRumble, uint durationMs) => SDL_RumbleJoystickTriggers(joystick, leftRumble, rightRumble, durationMs);
    public static bool SendJoystickEffect(SDL_Joystick* joystick, IntPtr data, int size) => SDL_SendJoystickEffect(joystick, data, size);
    public static bool SendJoystickVirtualSensorData(SDL_Joystick* joystick, SDL_SensorType type, ulong sensorTimestamp, float* data, int numValues) => SDL_SendJoystickVirtualSensorData(joystick, type, sensorTimestamp, data, numValues);
    public static void SetJoystickEventsEnabled(bool enabled) => SDL_SetJoystickEventsEnabled(enabled);
    public static bool SetJoystickLed(SDL_Joystick* joystick, byte red, byte green, byte blue) => SDL_SetJoystickLED(joystick, red, green, blue);
    public static bool SetJoystickPlayerIndex(SDL_Joystick* joystick, int playerIndex) => SDL_SetJoystickPlayerIndex(joystick, playerIndex);
    public static bool SetJoystickVirtualAxis(SDL_Joystick* joystick, int axis, short value) => SDL_SetJoystickVirtualAxis(joystick, axis, value);
    public static bool SetJoystickVirtualBall(SDL_Joystick* joystick, int ball, short xrel, short yrel) => SDL_SetJoystickVirtualBall(joystick, ball, xrel, yrel);
    public static bool SetJoystickVirtualButton(SDL_Joystick* joystick, int button, bool down) => SDL_SetJoystickVirtualButton(joystick, button, down);
    public static bool SetJoystickVirtualHat(SDL_Joystick* joystick, int hat, byte value) => SDL_SetJoystickVirtualHat(joystick, hat, value);
    public static bool SetJoystickVirtualTouchpad(SDL_Joystick* joystick, int touchpad, int finger, bool down, float x, float y, float pressure) => SDL_SetJoystickVirtualTouchpad(joystick, touchpad, finger, down, x, y, pressure);
    public static void UnlockJoysticks() => SDL_UnlockJoysticks();
    public static void UpdateJoysticks() => SDL_UpdateJoysticks();
}