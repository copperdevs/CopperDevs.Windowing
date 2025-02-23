namespace CopperDevs.Windowing.Data;

/// <summary>
/// Metadata of the app to set
/// </summary>
public class AppMetadata
{
    /// <summary>
    /// The human-readable name of the application. This will show up anywhere the OS shows the name of the application separately from window titles.
    /// </summary>
    public string? Name = null!;
    
    /// <summary>
    /// The version of the app that is running.
    /// </summary>
    public string? Version = null!;
    
    /// <summary>
    /// A unique string that identifies this app. This must be in reverse-domain format, like "com.example.mygame2".
    /// </summary>
    public string? Identifier = null!;
    
    /// <summary>
    /// The human-readable name of the creator/developer/maker of this app.
    /// </summary>
    public string? Creator = null!;
    
    /// <summary>
    /// The human-readable copyright notice, like "Copyright (c) 2024 MojoWorkshop, LLC" or whatnot. Keep this to one line, don't paste a copy of a whole software license in here. 
    /// </summary>
    public string? Copyright = null!;
    
    /// <summary>
    /// A URL to the app on the web.
    /// </summary>
    public string? Url = null!;
    
    /// <summary>
    /// The type of application this is.
    /// </summary>
    public AppType Type = AppType.Application;

    /// <summary>
    /// The type of application.
    /// </summary>
    public enum AppType
    {
        /// <summary>
        /// A General Application
        /// </summary>
        Application,
        
        /// <summary>
        /// A Video Game
        /// </summary>
        Game,
        
        /// <summary>
        /// A Media Player
        /// </summary>
        MediaPlayer,
    }

    /// <summary>
    /// Metadata of the app to set
    /// </summary>
    public enum MetadataProperty
    {
        /// <summary>
        /// The human-readable name of the application. This will show up anywhere the OS shows the name of the application separately from window titles.
        /// </summary>
        Name,
        
        /// <summary>
        /// The version of the app that is running.
        /// </summary>
        Version,
        
        /// <summary>
        /// A unique string that identifies this app. This must be in reverse-domain format, like "com.example.mygame2".
        /// </summary>
        Identifier,
        
        /// <summary>
        /// The human-readable name of the creator/developer/maker of this app.
        /// </summary>
        Creator,
        
        /// <summary>
        /// The human-readable copyright notice, like "Copyright (c) 2024 MojoWorkshop, LLC" or whatnot. Keep this to one line, don't paste a copy of a whole software license in here.
        /// </summary>
        Copyright,
        
        /// <summary>
        /// A URL to the app on the web.
        /// </summary>
        Url,
        
        /// <summary>
        /// The type of application this is.
        /// </summary>
        Type
    }

    /// <summary>
    /// Get a metadata property value from its type
    /// </summary>
    /// <param name="property">Property to get the value from</param>
    /// <returns>The value</returns>
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