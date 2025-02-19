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

    public static TTarget[] ToArray<TTarget>(SDLPointerArray<TTarget>? pointerArray) where TTarget : unmanaged
    {
        if (pointerArray is null)
            return [];

        var array = new TTarget[pointerArray.Count];

        for (var i = 0; i < pointerArray.Count; i++)
            array[i] = pointerArray[i];

        pointerArray.Dispose();

        return array;
    }

    public static TTarget[] ToArray<TTarget>(SDLArray<TTarget>? pointerArray) where TTarget : unmanaged
    {
        if (pointerArray is null)
            return [];

        var array = new TTarget[pointerArray.Count];

        for (var i = 0; i < pointerArray.Count; i++)
            array[i] = pointerArray[i];

        pointerArray.Dispose();
        
        return array;
    }
}

// ReSharper disable once InconsistentNaming
internal static unsafe class SDLUtilExtensions
{
    public static TTarget* ToPointer<TType, TTarget>(this List<TType> items) where TTarget : unmanaged => SDLUtil.ToPointer<TType, TTarget>(items);

    public static TTarget* ToPointer<TType, TTarget>(this List<TType> items, Func<TType, TTarget> targetCreation) where TTarget : unmanaged => SDLUtil.ToPointer(items, targetCreation);

    public static TTarget[] ToArray<TTarget>(this SDLPointerArray<TTarget>? pointerArray) where TTarget : unmanaged => SDLUtil.ToArray(pointerArray);

    public static TTarget[] ToArray<TTarget>(this SDLArray<TTarget>? pointerArray) where TTarget : unmanaged => SDLUtil.ToArray(pointerArray);
}