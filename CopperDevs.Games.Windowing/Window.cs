using CopperDevs.Games.Windowing.Data;

namespace CopperDevs.Games.Windowing;

public partial class Window
{
    public static TWindow CreateWindow<TWindow>(WindowOptions options) where TWindow : Window, new()
    {
        var window = new TWindow();
        
        window.CreateWindow(options);

        return window;
    }
}