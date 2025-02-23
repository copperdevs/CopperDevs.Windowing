using CopperDevs.Windowing.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace CopperDevs.Windowing;

public partial class Window
{
    private IInput? input;

    internal void SetupInput()
    {
        if (input is not null)
            return;

        input = CreateInput();
        input.SetCursorMode(CursorMode.Normal);

        Input.Connect(this, input);
    }

    private void UpdateInput()
    {
        SetupInput();
        input!.UpdateInput();
    }

    protected abstract IInput CreateInput();
}