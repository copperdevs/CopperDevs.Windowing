using CopperDevs.Core.Data;

namespace CopperDevs.Games.Windowing;

public partial class Window
{
    public Vector2Int Size => GetWindowSize();

    protected abstract Vector2Int GetWindowSize();
}