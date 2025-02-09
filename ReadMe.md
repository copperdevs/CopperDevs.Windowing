# Copper Windowing
> Simple, thin, windowing abstraction

## Installation
### Nuget Packages
- Base Package: https://www.nuget.org/packages/CopperDevs.Windowing/
- SDL3 Support:https://www.nuget.org/packages/CopperDevs.Windowing.SDL3/

## Example
*A full, simple, example project can be found [here](./CopperDevs.Windowing.Example)*

Example of the creation of an empty window using SDL3
```csharp
    public static void Main()
    {
        var options = SDL3WindowOptions.Default with { Title = "Example" };

        using var window = Window.Create<SDL3Window>(options);

        window.Run();
    }
```
