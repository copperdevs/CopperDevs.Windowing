using System.Reflection.Metadata;
using CopperDevs.Windowing.SDL3.Generator;

[assembly: MetadataUpdateHandler(typeof(HotReloadCallbackReceiver))]