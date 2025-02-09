#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace CopperDevs.Windowing;

public partial class Window
{
    public Action OnLoad = null!;
    public Action OnUpdate = null!;
    public Action OnRender = null!;
    public Action OnClose = null!;
}