// ReSharper disable InconsistentNaming

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace CopperDevs.Windowing.SDL3.Data;

[Flags]
public enum GPUShaderFormat : uint
{
    Private = SDL_GPUShaderFormat.SDL_GPU_SHADERFORMAT_PRIVATE, // Shaders for NDA'd platforms
    SPIRV = SDL_GPUShaderFormat.SDL_GPU_SHADERFORMAT_SPIRV, // SPIR-V shaders for Vulkan
    DXBC = SDL_GPUShaderFormat.SDL_GPU_SHADERFORMAT_DXBC, // DXBC SM5_1 shaders for D3D12
    DXIL = SDL_GPUShaderFormat.SDL_GPU_SHADERFORMAT_DXIL, // DXIL SM6_0 shaders for D3D12
    MSL = SDL_GPUShaderFormat.SDL_GPU_SHADERFORMAT_MSL, // MSL shaders for Metal
    MetalLib = SDL_GPUShaderFormat.SDL_GPU_SHADERFORMAT_METALLIB, // Precompiled metallib shaders for Metal
}