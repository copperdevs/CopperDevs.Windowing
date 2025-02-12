namespace CopperDevs.Windowing.Data;

public class AppMetadata
{
    public string? Name = null!;
    public string? Version = null!;
    public string? Identifier = null!;
    public string? Creator = null!;
    public string? Copyright = null!;
    public string? Url = null!;
    public AppType Type = AppType.Application;

    public enum AppType
    {
        Application,
        Game,
        MediaPlayer,
    }

    public enum MetadataProperty
    {
        Name,
        Version,
        Identifier,
        Creator,
        Copyright,
        Url,
        Type
    }

    public string GetProperty(MetadataProperty property)
    {
        return property switch
        {
            MetadataProperty.Name => Name,
            MetadataProperty.Version => Version,
            MetadataProperty.Identifier => Identifier,
            MetadataProperty.Creator => Creator,
            MetadataProperty.Copyright => Copyright,
            MetadataProperty.Url => Url,
            MetadataProperty.Type => Type switch
            {
                AppType.Application => "application",
                AppType.Game => "game",
                AppType.MediaPlayer => "mediaplayer",
                _ => throw new ArgumentOutOfRangeException()
            },
            _ => throw new ArgumentOutOfRangeException(nameof(property), property, null)
        } ?? string.Empty;
    }
}