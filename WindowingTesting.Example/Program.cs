// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Text;
using SDL;
using static SDL.SDL3;

namespace WindowingTesting.Example;

public static class Program
{
    public static void Main()
    {
        SDL_SetHint(SDL_HINT_WINDOWS_CLOSE_ON_ALT_F4, "null byte \0 in string"u8);
        
        SDL_SetHint(SDL_HINT_WINDOWS_CLOSE_ON_ALT_F4, "1"u8);
        SDL_SetHint(SDL_HINT_WINDOWS_CLOSE_ON_ALT_F4, "1");

        using (var window = new MyWindow())
        {
            Console.WriteLine($"SDL revision: {SDL_GetRevision()}");

            window.Setup();
            window.Create();

            window.Run();
        }

        SDL_Quit();
    }
}