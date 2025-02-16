using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void CloseSensor() => SDL_CloseSensor();
    public static void GetSensorData() => SDL_GetSensorData();
    public static void GetSensorFromID() => SDL_GetSensorFromID();
    public static void GetSensorID() => SDL_GetSensorID();
    public static void GetSensorName() => SDL_GetSensorName();
    public static void GetSensorNameForID() => SDL_GetSensorNameForID();
    public static void GetSensorNonPortableType() => SDL_GetSensorNonPortableType();
    public static void GetSensorNonPortableTypeForID() => SDL_GetSensorNonPortableTypeForID();
    public static void GetSensorProperties() => SDL_GetSensorProperties();
    public static void GetSensors() => SDL_GetSensors();
    public static void GetSensorType() => SDL_GetSensorType();
    public static void GetSensorTypeForID() => SDL_GetSensorTypeForID();
    public static void OpenSensor() => SDL_OpenSensor();
    public static void UpdateSensors() => SDL_UpdateSensors();
}