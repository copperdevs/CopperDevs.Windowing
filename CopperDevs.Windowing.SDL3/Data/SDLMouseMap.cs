using CopperDevs.Windowing.Data;

namespace CopperDevs.Windowing.SDL3.Data;

internal class SDLMouseMap : Dictionary<MouseButton, SDLButton>
{
    public SDLMouseMap()
    {
        this[MouseButton.Left] = SDLButton.SDL_BUTTON_LEFT;
        this[MouseButton.Middle] = SDLButton.SDL_BUTTON_MIDDLE;
        this[MouseButton.Right] = SDLButton.SDL_BUTTON_RIGHT;
    }
}