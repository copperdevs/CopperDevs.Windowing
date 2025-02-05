using CopperDevs.Core.Data;

namespace CopperDevs.Windowing;

public partial class Window
{
    public Vector2Int Size => GetWindowSize();

    protected abstract Vector2Int GetWindowSize();
}