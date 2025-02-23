using System.Reflection;
using CopperDevs.Logger;
using SDL;

namespace CopperDevs.Windowing.SDL3.Generator;

internal static class HotReloadCallbackReceiver
{
    public static void UpdateApplication(Type[] updatedTypes)
    {
        Log.Warning("Program Hot Reloaded");

        Program.CreateFiles();
        Program.GenerateMethods();
    }
}

// lol this code is lowkey diabolical
// it does what its suppose to do those so 🤷
public static class Program
{
    private const bool ExcessiveLogs = false;

    private static void LogInfo(string message)
    {
        if (ExcessiveLogs)
            Log.Info(message);
    }

    private static void LogError(string message)
    {
        if (ExcessiveLogs)
            Log.Error(message);
    }

    private static void LogDebug(string message)
    {
        if (ExcessiveLogs)
            Log.Debug(message);
    }

    private static readonly Dictionary<Type, Type> SdlTypeMap = new()
    {
        { typeof(SDLBool), typeof(bool) },
        { typeof(Utf8String), typeof(string) },
        { typeof(SDL_BlendFactor), typeof(BlendFactor) },
        { typeof(SDL_BlendOperation), typeof(BlendOperation) },
        { typeof(SDL_HintPriority), typeof(HintPriority) },
        { typeof(SDL_LogCategory), typeof(LogCategory) },
        { typeof(SDL_LogPriority), typeof(LogPriority) },
    };

    private static readonly Dictionary<string, string> TypeKeywordsMap = new()
    {
        { "System.Boolean", "bool" },
        { "System.Int32", "int" },
        { "System.String", "string" },
        { "System.Void", "void" },
        { "System.UInt16", "ushort" },
        { "System.UInt32", "uint" },
        { "System.UInt64", "ulong" },
        { "System.IntPtr", "IntPtr" },
        { "System.UIntPtr", "UIntPtr" },
        { "System.Single", "float" },
        { "System.Double", "double" },
        { "System.Byte", "byte" },
        { "System.SByte", "sbyte" },
        { "System.Char", "char" },
        { "System.Decimal", "decimal" },
        { "System.DateTime", "DateTime" },
        { "System.TimeSpan", "TimeSpan" },
        { "System.Guid", "Guid" },
        { "System.Object", "object" },
        { "System.Array", "Array" },
        { "System.Int64", "long" },
        { "System.Int16", "short" },
    };

    public static void Main()
    {
        CreateFiles();

        GenerateMethods();

        SetupFileWatcher();
    }

    private static void SetupFileWatcher()
    {
        using var watcher = new FileSystemWatcher(".");

        watcher.NotifyFilter = NotifyFilters.Attributes
                               | NotifyFilters.CreationTime
                               | NotifyFilters.DirectoryName
                               | NotifyFilters.FileName
                               | NotifyFilters.LastAccess
                               | NotifyFilters.LastWrite
                               | NotifyFilters.Security
                               | NotifyFilters.Size;

        watcher.Changed += OnChanged;

        watcher.Filter = "methods.txt";
        watcher.IncludeSubdirectories = true;
        watcher.EnableRaisingEvents = true;

        Log.Info("Press enter to exit.");
        Console.ReadLine();
    }

    private static void OnChanged(object sender, FileSystemEventArgs e)
    {
        if (e.ChangeType != WatcherChangeTypes.Changed)
        {
            return;
        }

        Log.Debug($"Changed: {e.FullPath}");

        CreateFiles();
        GenerateMethods();
    }

    public static void GenerateMethods()
    {
        var methodsInfo = typeof(SDL.SDL3).GetMethods(BindingFlags.Static | BindingFlags.Public);
        var readLines = File.ReadAllLines("methods.txt");

        foreach (var line in readLines)
        {
            var method = $"SDL.SDL3.{line}";

            var methodInfos = methodsInfo.Where(x => x.Name == line).ToList();

            foreach (var methodInfo in methodInfos)
            {
                var wasError = false;

                var returnType = methodInfo.ReturnType != typeof(void) && !string.IsNullOrWhiteSpace(methodInfo.ReturnParameter.ParameterType.FullName) ? GetName(methodInfo.ReturnType) : "void";

                if (ReturnTypeIsArray(methodInfo))
                {
                    LogDebug($"array arguments index 0 moment {GetName(methodInfo.ReturnParameter.ParameterType.GetGenericArguments()[0])}");
                    returnType = $"{GetName(methodInfo.ReturnParameter.ParameterType.GetGenericArguments()[0])}[]";
                }

                var parameters = methodInfo.GetParameters().ToList();

                var parametersInputString = string.Empty;
                var parametersOutputString = string.Empty;


                foreach (var parameter in parameters)
                {
                    try
                    {
                        LogDebug($"{methodInfo.Name}: {parameter.ParameterType.FullName}");

                        if (string.IsNullOrEmpty(methodInfo.ReturnParameter.ParameterType.FullName) || methodInfo.ReturnParameter.ParameterType.FullName is null)
                            continue;

                        parametersInputString += $"{GetName(parameter.ParameterType)} {parameter.Name}{(IsLastItem(parameters, parameter) ? string.Empty : ", ")}";

                        // var needsToCast = VerifyType(parameter.ParameterType).Name != GetName(parameter.ParameterType);
                        // var castingString = needsToCast ? $"({VerifyType(parameter.ParameterType).Name})" : string.Empty;

                        parametersOutputString += $"{parameter.Name}{(IsLastItem(parameters, parameter) ? string.Empty : ", ")}";
                    }
                    catch (Exception e)
                    {
                        LogError($"Error: {e.Message}");
                        wasError = true;
                    }
                }

                LogInfo(parametersInputString);

                AppendOutputLine(
                    $"{(wasError ? " // TODO: " : string.Empty)}public static {returnType} {methodInfo.Name[4..]}({parametersInputString}) => {(ReturnTypeIsArray(methodInfo) ? "SDLUtil.ToArray(" : string.Empty)}SDL.SDL3.{methodInfo.Name}({parametersOutputString}){(ReturnTypeIsArray(methodInfo) ? ")" : string.Empty)}{(methodInfo.ReturnType == typeof(string) ? " ?? string.Empty" : string.Empty)};");
            }

            LogDebug($"{method} {methodInfos.Count}");
        }
    }


    private static Type VerifyType(Type type) => SdlTypeMap.GetValueOrDefault(type, type);

    private static string GetName(Type type)
    {
        var shortenedString = VerifyType(type).FullName!;
        var isPointer = shortenedString.EndsWith('*');

        var fullString = shortenedString;

        var pointerString = "";

        while (shortenedString.EndsWith('*'))
        {
            shortenedString = shortenedString.Remove(shortenedString.Length - 1);
            pointerString += "*";
        }

        LogDebug($"shortenedString {shortenedString} | isPointer {isPointer} | pointerString {pointerString} | fullString {fullString}");


        return TypeKeywordsMap.TryGetValue(isPointer ? shortenedString : fullString, out var value) ? $"{value}{(isPointer ? pointerString : string.Empty)}" : VerifyType(type).Name;
    }

    private static void AppendOutputLine(object line) => File.AppendAllText("output.txt", $"{line}\n");

    private static bool IsLastItem<T>(List<T> list, T item) => list.IndexOf(item) == list.Count - 1;

    private static bool ReturnTypeIsArray(MethodInfo methodInfo)
    {
        return methodInfo.ReturnParameter.ParameterType.IsGenericType &&
               (methodInfo.ReturnParameter.ParameterType.GetGenericTypeDefinition() == typeof(SDLArray<>) ||
                methodInfo.ReturnParameter.ParameterType.GetGenericTypeDefinition() == typeof(SDLPointerArray<>));
    }

    public static void CreateFiles()
    {
        if (CreateFile("methods.txt") && CreateFile("output.txt"))
            LogError($"No methods were found");

        File.WriteAllText("output.txt", string.Empty);

        return;

        bool CreateFile(string path)
        {
            if (File.Exists(path))
                return false;

            LogDebug($"Creating {path}");
            File.Create(path).Close();

            return true;
        }
    }
}