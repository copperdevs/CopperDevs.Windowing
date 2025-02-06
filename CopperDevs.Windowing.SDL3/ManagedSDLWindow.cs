using CopperDevs.Core.Data;
using CopperDevs.Core.Utility;
using CopperDevs.Logger;
using CopperDevs.Windowing.Data;
using CopperDevs.Windowing.SDL3.Data;
using SDL;

namespace CopperDevs.Windowing.SDL3;

// ReSharper disable once InconsistentNaming
internal unsafe class ManagedSDLWindow : SafeDisposable
{
    private bool createdSuccessfully = false;

    // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
    private readonly SDL_Window* window;
    private readonly SDL_Renderer* renderer;

    // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
    private readonly WindowFlags windowFlags;
    private readonly InitFlags initFlags;

    private Events events = new();

    public Vector2Int Size => SDL.GetWindowSize(window);
    
    public ManagedSDLWindow(WindowOptions options)
    {
        initFlags = InitFlags.Video;
        windowFlags = WindowFlags.Resizable | WindowFlags.Hidden;

        if (options.GetType() == typeof(SDL3WindowOptions))
        {
            var windowOptions = (SDL3WindowOptions)options;

            initFlags = windowOptions.InitFlags;
            windowFlags = windowOptions.WindowFlags;
        }

        if (!(createdSuccessfully = SDL.InitSubSystem(initFlags)))
        {
            throw new InvalidOperationException($"Failed to initialise SDL. Error: {SDL.GetError()}");
        }

        events.HandleEvent += HandleEvents;

        window = SDL.CreateWindow(options.Title, options.Size, windowFlags);
        renderer = SDL.CreateRenderer(window);
    }

    public void Update()
    {
        events.Poll();
        Thread.Sleep(10);
    }

    private void HandleEvents(SDL_Event e)
    {
        Log.Info(e.Type);
    }
    
    public override void DisposeResources()
    {
        if (createdSuccessfully)
            SDL.QuitSubSystem(initFlags);

        SDL.Quit();
    }

    private class Events
    {
        private const int EventsPerPeep = 64;
        private readonly SDL_Event[] events = new SDL_Event[EventsPerPeep];

        public Action<SDL_Event> HandleEvent = null!;

        public void Poll()
        {
            SDL.PumpEvents();

            int eventsRead;

            do
            {
                eventsRead = SDL.PeepEvents(events, SDL_EventAction.SDL_GETEVENT, SDL_EventType.SDL_EVENT_FIRST, SDL_EventType.SDL_EVENT_LAST);
                for (var i = 0; i < eventsRead; i++)
                    HandleEvent?.Invoke(events[i]);
            } while (eventsRead == EventsPerPeep);
        }
    }
}