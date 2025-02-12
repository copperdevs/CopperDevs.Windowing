namespace CopperDevs.Windowing;

public partial class Window
{
    /// <summary>
    /// Flash the window
    /// </summary>
    /// <param name="untilFocus">If true, flashes the window until focused, otherwise only briefly flashes</param>
    public void Flash(bool untilFocus = true) => WindowFlash(untilFocus);

    /// <summary>
    /// Cancel any window flash state
    /// </summary>
    public void StopFlash() => StopWindowFlash();

    #region Internal

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    protected abstract void WindowFlash(bool untilFocus = true);
    protected abstract void StopWindowFlash();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    #endregion
}