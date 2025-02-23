using System.Text;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDLAPI
{
    public static delegate*unmanaged[Cdecl]<IntPtr, int, SDL_LogPriority, byte*, void> GetDefaultLogOutputFunction() => SDL_GetDefaultLogOutputFunction();

    public static void GetLogOutputFunction(delegate*unmanaged[Cdecl]<IntPtr, int, SDL_LogPriority, byte*, void>* callback, IntPtr* userdata) => SDL_GetLogOutputFunction(callback, userdata);

    public static LogCategory GetLogPriority(LogCategory category) => (LogCategory)SDL_GetLogPriority((int)category);

    public static void Log(string text)
    {
        fixed (byte* fmtPtr = Encoding.UTF8.GetBytes(text + "\0"))
            SDL_Log(fmtPtr, __arglist());
    }

    public static void LogCritical(LogCategory category, string text)
    {
        fixed (byte* fmtPtr = Encoding.UTF8.GetBytes(text + "\0"))
            SDL_LogCritical((int)category, fmtPtr, __arglist());
    }

    public static void LogDebug(LogCategory category, string text)
    {
        fixed (byte* fmtPtr = Encoding.UTF8.GetBytes(text + "\0"))
            SDL_LogDebug((int)category, fmtPtr, __arglist());
    }

    public static void LogError(LogCategory category, string text)
    {
        fixed (byte* fmtPtr = Encoding.UTF8.GetBytes(text + "\0"))
            SDL_LogError((int)category, fmtPtr, __arglist());
    }

    public static void LogInfo(LogCategory category, string text)
    {
        fixed (byte* fmtPtr = Encoding.UTF8.GetBytes(text + "\0"))
            SDL_LogInfo((int)category, fmtPtr, __arglist());
    }

    public static void LogMessage(LogCategory category, LogPriority priority, string text)
    {
        fixed (byte* fmtPtr = Encoding.UTF8.GetBytes(text + "\0"))
            SDL_LogMessage((int)category, (SDL_LogPriority)priority, fmtPtr, __arglist());
    }

    public static void LogTrace(LogCategory category, string text)
    {
        fixed (byte* fmtPtr = Encoding.UTF8.GetBytes(text + "\0"))
            SDL_LogTrace((int)category, fmtPtr, __arglist());
    }

    public static void LogVerbose(LogCategory category, string text)
    {
        fixed (byte* fmtPtr = Encoding.UTF8.GetBytes(text + "\0"))
            SDL_LogVerbose((int)category, fmtPtr, __arglist());
    }

    public static void LogWarn(LogCategory category, string text)
    {
        fixed (byte* fmtPtr = Encoding.UTF8.GetBytes(text + "\0"))
            SDL_LogWarn((int)category, fmtPtr, __arglist());
    }

    public static void ResetLogPriorities() => SDL_ResetLogPriorities();

    public static void SetLogOutputFunction(delegate*unmanaged[Cdecl]<IntPtr, int, SDL_LogPriority, byte*, void> callback, IntPtr userdata) => SDL_SetLogOutputFunction(callback, userdata);

    public static void SetLogPriorities(LogPriority priority) => SDL_SetLogPriorities((SDL_LogPriority)priority);

    public static void SetLogPriority(LogCategory category, LogPriority priority) => SDL_SetLogPriority((SDL_LogCategory)category, (SDL_LogPriority)priority);

    public static bool SetLogPriorityPrefix(LogPriority priority, string prefix) => SDL_SetLogPriorityPrefix((SDL_LogPriority)priority, prefix);
}