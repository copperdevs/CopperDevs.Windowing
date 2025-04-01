namespace CopperDevs.Windowing.SDL3.Data;

public class RendererOptions
{
    /// <summary>
    /// Target renderer to initialize
    /// </summary>
    public SDLRenderers TargetRenderer = SDLRenderers.Renderer;

    public GPUShaderFormat GPUShaderFormat;
    public bool GPUDebugMode = false;
    public GraphicsAPI GPUGraphicsApi = GraphicsAPI.Auto;
}

/// <summary>
/// SDL Renderers types
/// </summary>
public enum SDLRenderers
{
    /// <summary>
    /// SDLs 3D Rendering and GPU Compute
    /// </summary>
    // ReSharper disable once InconsistentNaming
    GPU,

    /// <summary>
    /// SDLs 2D Accelerated Rendering
    /// </summary>
    Renderer,

    /// <summary>
    /// Nothing
    /// </summary>
    None,
}


public enum GraphicsAPI
{
    Vulkan,
    Direct3D12,
    Metal,
    Auto,
}