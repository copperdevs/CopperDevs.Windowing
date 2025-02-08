using CopperDevs.Core.Data;
using CopperDevs.Core.Utility;
using CopperDevs.Windowing.Data;
using CopperDevs.Windowing.SDL3.Data;
using SDL;
using NativeSDL3 = global::SDL.SDL3;

namespace CopperDevs.Windowing.SDL3;

// ReSharper disable once InconsistentNaming
public class SDL3Window : Window
{
    private ManagedSDLWindow window = null!;

    // ReSharper disable once InconsistentNaming
    public ManagedSDLWindow GetManagedSDLWindow() => window;
    public SDLRenderer GetRenderer() => window.GetRenderer();

    public override void DisposeResources()
    {
        window.Dispose();
    }

    protected override Vector2Int GetWindowSize() => window.Size;

    protected override double GetTotalTime() => totalTime;

    protected override double GetDeltaTime() => deltaTime;

    protected override unsafe void ConnectWindowEvents()
    {
        fixed (byte* pointerPointer = NativeSDL3.SDL_PROP_WINDOW_WIN32_HWND_POINTER)
        {
            var pointer = NativeSDL3.SDL_GetPointerProperty(NativeSDL3.SDL_GetWindowProperties(window.GetNativeWindow()), pointerPointer, (IntPtr)null);
            
            WindowsApi.RegisterWindow(pointer);
            WindowsApi.OnWindowResize += _ => RenderWindow();
        }
    }

    public override unsafe void CreateWindow(WindowOptions options)
    {
        SDL.SetHint(NativeSDL3.SDL_HINT_WINDOWS_CLOSE_ON_ALT_F4, "null byte \0 in string"u8);

        SDL.SetHint(NativeSDL3.SDL_HINT_WINDOWS_CLOSE_ON_ALT_F4, "1"u8);
        SDL.SetHint(NativeSDL3.SDL_HINT_WINDOWS_CLOSE_ON_ALT_F4, "1");

        window = new ManagedSDLWindow(options);
        window.HandleEvent += EventsHandler;
    }

    public override void StartWindowUpdate()
    {
        deltaTimeStartTime = totalTime;

        window.Update();
    }

    public override void StopWindowUpdate()
    {
        deltaTime = totalTime - deltaTimeStartTime;
    }

    // ReSharper disable once InconsistentNaming
    private double totalTime => SDL.GetTicks() / (double)1000;
    private double deltaTime;
    private double deltaTimeStartTime;


    public override void DestroyWindow()
    {
        Dispose();
    }

    private void EventsHandler(EventType type, SDL_Event e)
    {
        // ReSharper disable once SwitchStatementMissingSomeEnumCasesNoDefault
        // ReSharper disable once ConvertSwitchStatementToSwitchExpression
        switch (type)
        {
            case EventType.Quit:
                ShouldRun = false;
                break;
        }
    }
}