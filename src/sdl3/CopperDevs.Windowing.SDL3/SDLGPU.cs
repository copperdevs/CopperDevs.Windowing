using CopperDevs.Celesium;
using CopperDevs.Windowing.SDL3.Data;

namespace CopperDevs.Windowing.SDL3;

public unsafe class SDLGPU : SafeDisposable, IRenderer<SDL_GPUDevice>
{
    private ManagedSDLWindow window = null!;
    private SDL_GPUDevice* native;

    public SDL_GPUDevice* GetNativeRenderer() => native;

    public void CreateRenderer(ManagedSDLWindow window, RendererOptions options)
    {
        this.window = window;

        var api = options.GPUGraphicsApi switch
        {
            GraphicsAPI.Vulkan => "vulkan",
            GraphicsAPI.Direct3D12 => "direct3d12",
            GraphicsAPI.Metal => "metal",
            GraphicsAPI.Auto => null!,
            _ => null!
        };

        native = SDLAPI.CreateGpuDevice((SDL_GPUShaderFormat)options.GPUShaderFormat, options.GPUDebugMode, api);

        if (native == null)
            throw new Exception($"{nameof(SDLAPI.CreateGpuDevice)} Failed: {SDLAPI.GetError()}");

        if (!SDLAPI.ClaimWindowForGpuDevice(native, window.GetNativeWindow()))
            throw new Exception($"{nameof(SDLAPI.ClaimWindowForGpuDevice)} Failed: {SDLAPI.GetError()}");

        Log.Info($"GPU API using {GetDeviceDriver()}");
    }

    public override void DisposeResources()
    {
        SDLAPI.ReleaseWindowFromGpuDevice(native, window.GetNativeWindow());
        SDLAPI.DestroyGpuDevice(native);
    }

    public string GetDeviceDriver() => SDLAPI.GetGpuDeviceDriver(native);
}