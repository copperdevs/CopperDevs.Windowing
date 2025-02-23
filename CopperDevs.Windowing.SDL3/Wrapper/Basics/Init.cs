using CopperDevs.Windowing.SDL3.Data;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDLAPI
{
    public static string GetAppMetadataProperty(string name) => SDL_GetAppMetadataProperty(name) ?? string.Empty;

    public static bool Init(InitFlags flags) => SDL_Init((SDL_InitFlags)flags);

    public static bool InitSubSystem(InitFlags flags) => SDL_InitSubSystem((SDL_InitFlags)flags);

    public static bool IsMainThread() => SDL_IsMainThread();

    public static void Quit() => SDL_Quit();

    public static void QuitSubSystem(InitFlags flags) => SDL_QuitSubSystem((SDL_InitFlags)flags);

    public static bool SetAppMetadata(string appName, string appVersion, string appIdentifier) => SDL_SetAppMetadata(appName, appVersion, appIdentifier);

    public static bool SetAppMetadataProperty(string name, string value) => SDL_SetAppMetadataProperty(name, value);

    public static bool SetAppMetadataProperty(byte* name, byte* value) => SDL_SetAppMetadataProperty(name, value);

    public static InitFlags WasInit(InitFlags flags) => (InitFlags)SDL_WasInit((SDL_InitFlags)flags);
}