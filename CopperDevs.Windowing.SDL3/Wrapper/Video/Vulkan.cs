using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDLAPI
{
    public static bool Vulkan_CreateSurface(SDL_Window* window, VkInstance_T* instance, VkAllocationCallbacks* allocator, VkSurfaceKHR_T** surface) => SDL_Vulkan_CreateSurface(window, instance, allocator, surface);
    public static void Vulkan_DestroySurface(VkInstance_T* instance, VkSurfaceKHR_T* surface, VkAllocationCallbacks* allocator) => SDL_Vulkan_DestroySurface(instance, surface, allocator);
    public static byte** Vulkan_GetInstanceExtensions(uint* count) => SDL_Vulkan_GetInstanceExtensions(count);
    public static bool Vulkan_GetPresentationSupport(VkInstance_T* instance, VkPhysicalDevice_T* physicalDevice, uint queueFamilyIndex) => SDL_Vulkan_GetPresentationSupport(instance, physicalDevice, queueFamilyIndex);
    public static nint Vulkan_GetVkGetInstanceProcAddr() => SDL_Vulkan_GetVkGetInstanceProcAddr();
    public static bool Vulkan_LoadLibrary(string path) => SDL_Vulkan_LoadLibrary(path);
    public static void Vulkan_UnloadLibrary() => SDL_Vulkan_UnloadLibrary();
}