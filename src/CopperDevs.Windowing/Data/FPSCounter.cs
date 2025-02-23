namespace CopperDevs.Windowing.Data;

// lowkey there's *probably* a better way to do this but idc 

// ReSharper disable once InconsistentNaming
internal class FPSCounter
{
    private const float PollingTime = 1f;
    private double time;
    private int frameCount;
    private int frameRate;
    
    public int FrameRate => frameRate;

    public void Update()
    {
        time += Time.DeltaTime;

        // Count this frame.
        frameCount++;

        if (!(time >= PollingTime))
            return;

        // Update frame rate.
        frameRate = (int)Math.Round(frameCount / time);
        
        // Reset time and frame count.
        time -= PollingTime;
        frameCount = 0;
    }
}