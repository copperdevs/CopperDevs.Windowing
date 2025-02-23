#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3.Wrapper.Data;

public class PowerInfo
{
    public PowerState State { get; init; }
    public int Seconds;
    public int Percent;

    internal PowerInfo()
    {
    }
}