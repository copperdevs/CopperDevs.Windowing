using CopperDevs.Windowing.SDL3.Data;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void Vulkan_CreateSurface() => SDL_Vulkan_CreateSurface();
    public static void Vulkan_DestroySurface() => SDL_Vulkan_DestroySurface();
    public static void Vulkan_GetInstanceExtensions() => SDL_Vulkan_GetInstanceExtensions();
    public static void Vulkan_GetPresentationSupport() => SDL_Vulkan_GetPresentationSupport();
    public static void Vulkan_GetVkGetInstanceProcAddr() => SDL_Vulkan_GetVkGetInstanceProcAddr();
    public static void Vulkan_LoadLibrary() => SDL_Vulkan_LoadLibrary();
    public static void Vulkan_UnloadLibrary() => SDL_Vulkan_UnloadLibrary();

}