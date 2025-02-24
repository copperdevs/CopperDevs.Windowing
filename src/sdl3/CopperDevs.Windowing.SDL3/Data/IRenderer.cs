namespace CopperDevs.Windowing.SDL3.Data;

internal interface IRenderer<T> where T : unmanaged
{
    public void CreateRenderer(ManagedSDLWindow window, RendererOptions options);
    
    public unsafe T* GetNativeRenderer();
}