// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using SDL;
using static SDL.SDL3;

namespace WindowingTesting.Example
{
    public sealed unsafe class MyWindow : IDisposable
    {
        private SDL_Window* sdlWindowHandle;
        private SDL_Renderer* renderer;
        private readonly bool initSuccess;

        private const SDL_InitFlags init_flags = SDL_InitFlags.SDL_INIT_VIDEO | SDL_InitFlags.SDL_INIT_GAMEPAD;

        public MyWindow()
        {
            if (!SDL_InitSubSystem(init_flags))
                throw new InvalidOperationException($"failed to initialise SDL. Error: {SDL_GetError()}");

            initSuccess = true;
        }

        public void Setup()
        {
            SDL_SetGamepadEventsEnabled(true);
        }

        public void Create()
        {
            sdlWindowHandle = SDL_CreateWindow("hello"u8, 800, 600, SDL_WindowFlags.SDL_WINDOW_RESIZABLE | SDL_WindowFlags.SDL_WINDOW_HIGH_PIXEL_DENSITY);
            renderer = SDL_CreateRenderer(sdlWindowHandle, (Utf8String)null);
        }
 
        private void handleEvent(SDL_Event e)
        {
            switch (e.Type)
            {
                case SDL_EventType.SDL_EVENT_QUIT:
                    run = false;
                    break;

                case SDL_EventType.SDL_EVENT_KEY_DOWN:
                    switch (e.key.key)
                    {
                        case SDL_Keycode.SDLK_R:
                            bool old = SDL_GetWindowRelativeMouseMode(sdlWindowHandle);
                            SDL_SetWindowRelativeMouseMode(sdlWindowHandle, !old);
                            break;

                        case SDL_Keycode.SDLK_V:
                            string? text = SDL_GetClipboardText();
                            Console.WriteLine($"clipboard: {text}");
                            break;

                        case SDL_Keycode.SDLK_F10:
                            SDL_SetWindowFullscreen(sdlWindowHandle, false);
                            break;

                        case SDL_Keycode.SDLK_F11:
                            SDL_SetWindowFullscreen(sdlWindowHandle, true);
                            break;

                        case SDL_Keycode.SDLK_J:
                        {
                            using var gamepads = SDL_GetGamepads();

                            if (gamepads == null || gamepads.Count == 0)
                                break;

                            var gamepad = SDL_OpenGamepad(gamepads[0]);

                            int count;
                            var bindings = SDL_GetGamepadBindings(gamepad, &count);

                            for (int i = 0; i < count; i++)
                            {
                                var binding = *bindings[i];
                                Console.WriteLine(binding.input_type);
                                Console.WriteLine(binding.output_type);
                                Console.WriteLine();
                            }

                            SDL_CloseGamepad(gamepad);
                            break;
                        }

                        case SDL_Keycode.SDLK_F1:
                            SDL_StartTextInput(sdlWindowHandle);
                            break;

                        case SDL_Keycode.SDLK_F2:
                            SDL_StopTextInput(sdlWindowHandle);
                            break;

                        case SDL_Keycode.SDLK_M:
                            SDL_Keymod mod = e.key.mod;
                            Console.WriteLine(mod);
                            break;
                    }

                    break;

                case SDL_EventType.SDL_EVENT_TEXT_INPUT:
                    Console.WriteLine(e.text.GetText());
                    break;

                case SDL_EventType.SDL_EVENT_GAMEPAD_ADDED:
                    Console.WriteLine($"gamepad added: {e.gdevice.which}");
                    break;

                case SDL_EventType.SDL_EVENT_PEN_PROXIMITY_IN:
                    Console.WriteLine($"pen proximity in: {e.pproximity.which}");
                    break;
            }
        }

        private bool run = true;

        private const int events_per_peep = 64;
        private readonly SDL_Event[] events = new SDL_Event[events_per_peep];

        private void pollEvents()
        {
            SDL_PumpEvents();

            int eventsRead;

            do
            {
                eventsRead = SDL_PeepEvents(events, SDL_EventAction.SDL_GETEVENT, SDL_EventType.SDL_EVENT_FIRST, SDL_EventType.SDL_EVENT_LAST);
                for (int i = 0; i < eventsRead; i++)
                    handleEvent(events[i]);
            } while (eventsRead == events_per_peep);
        }

        private float frame;

        public void Run()
        {
            while (run)
            {
                pollEvents();

                
                SDL_SetRenderDrawColorFloat(renderer, SDL_sinf(frame) / 2 + 0.5f, SDL_cosf(frame) / 2 + 0.5f, 0.3f, 1.0f);
                SDL_RenderClear(renderer);
                SDL_RenderPresent(renderer);

                frame += 0.015f;

                Thread.Sleep(10);
            }
        }

        public void Dispose()
        {
            if (initSuccess)
                SDL_QuitSubSystem(init_flags);
        }
    }
}