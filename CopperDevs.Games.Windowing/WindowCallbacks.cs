namespace CopperDevs.Games.Windowing;

public partial class Window
{
    public Action OnLoad = null!;
    public Action OnUpdate = null!;
    public Action OnRender = null!;
    public Action OnClose = null!;
}