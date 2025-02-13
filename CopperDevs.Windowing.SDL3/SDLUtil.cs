namespace CopperDevs.Windowing.SDL3;

// ReSharper disable once InconsistentNaming
internal static unsafe class SDLUtil
{
    public static TTarget* ToPointer<TTarget>(List<TTarget> items) where TTarget : unmanaged
    {
        return ToPointer<TTarget, TTarget>(items);
    }
    
    public static TTarget* ToPointer<TType, TTarget>(List<TType> items) where TTarget : unmanaged
    {
        fixed (TTarget* nativeArrayPtr = items.Cast<TTarget>().ToArray())
            return nativeArrayPtr;
    }

    public static TTarget* ToPointer<TType, TTarget>(List<TType> items, Func<TType, TTarget> targetCreation) where TTarget : unmanaged
    {
        var nativePoint = new TTarget[items.Count];

        for (var i = 0; i < items.Count; i++)
            nativePoint[i] = targetCreation.Invoke(items[i]);

        fixed (TTarget* pointsPtr = nativePoint)
            return pointsPtr;
    }
}