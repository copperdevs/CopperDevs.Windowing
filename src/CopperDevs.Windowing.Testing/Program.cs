using System.Numerics;
using CopperDevs.Core.Data;
using CopperDevs.Core.Utility;
using CopperDevs.Logger;
using CopperDevs.Windowing.Data;
using CopperDevs.Windowing.SDL3;
using CopperDevs.Windowing.SDL3.Data;
using ImGuiNET;
using SDL;

namespace CopperDevs.Windowing.Testing;

// testing project moment
public static unsafe class Program
{
    private static IntPtr context;
    // private static SDLGPU? gpu;
    private static SDL3Window window = null!;
    private static SDLRenderer renderer = null!;

    private static float scale = 1;

    public static void Main()
    {
        // AppDomain.CurrentDomain.GetAssemblies().ToList().ForEach(assembly => assembly.GetManifestResourceNames().ToList().ForEach(Log.Debug));

        var options = SDL3WindowOptions.Default with
        {
            Title = "CopperDevs Windowing Example",
            Metadata = new AppMetadata
            {
                Name = "CopperDevs Windowing Example",
                Version = "1.0.0",
                Identifier = "com.copperdevs.windowing.example",
                Creator = "copperdevs",
                Copyright = "MIT License",
                Url = "https://github.com/copperdevs/CopperDevs.Windowing",
                Type = AppMetadata.AppType.Application
            },
            RendererOptions = new RendererOptions()
            {
                GPUDebugMode = true,
                GPUShaderFormat = GPUShaderFormat.DXIL | GPUShaderFormat.MSL | GPUShaderFormat.SPIRV,
                TargetRenderer = SDLRenderers.Renderer,
                GPUGraphicsApi = GraphicsAPI.Auto
            },
        };

        window = Window.Create<SDL3Window>(options);
        // gpu = window.GetGPU();
        renderer = window.GetRenderer()!;

        window.OnLoad += OnLoad;
        window.OnUpdate += OnUpdate;
        window.OnRender += OnRender;
        window.HandleEvent += EventHandler;
        window.OnClose += OnClose;

        window.Run();

        window.Dispose();
    }

    private static void EventHandler(EventType type, SDL_Event data)
    {
        ImGuiSdl3.ProcessEvent(&data);
    }

    private static void OnLoad()
    {
        context = ImGui.CreateContext();
        ImGui.SetCurrentContext(context);

        ImGuiSdl3.Init(window.GetNativeWindow(), renderer.GetNativeRenderer());

        var io = ImGui.GetIO();
        io.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard;

        if (!SDLAPI.SetRenderVSync(renderer.GetNativeRenderer(), 1))
            Log.Error($"Failed to set Vsync: {SDLAPI.GetError()}");
    }

    private static void OnUpdate()
    {
        // if (ImGui.GetIO().WantTextInput && !SDLAPI.TextInputActive(window.GetNativeWindow()))
        //     SDLAPI.StartTextInput(window.GetNativeWindow());
        //
        // else if (!ImGui.GetIO().WantTextInput && SDLAPI.TextInputActive(window.GetNativeWindow()))
        //     SDLAPI.StopTextInput(window.GetNativeWindow());
        //
        // ImGui.GetIO().DeltaTime = Time.DeltaTimeAsFloat;
    }


    private static void OnRender()
    {
        ImGuiSdl3.NewFrame();
        ImGui.NewFrame();

        ImGui.ShowDemoWindow();

        if (ImGui.Begin("Scale"))
        {
            if (ImGui.DragFloat("scale", ref scale, 0.001f))
                renderer.Scale = Vector2.One * scale;
        }

        ImGui.End();

        ImGui.Render();

        renderer.Clear(Color.White);

        ImGuiSdl3.RenderDrawData(ImGui.GetDrawData());

        renderer.Present();
    }

    private static void OnClose()
    {
        if (context == IntPtr.Zero)
            return;

        ImGuiSdl3.Shutdown();
        ImGui.DestroyContext(context);
        context = IntPtr.Zero;
    }
}