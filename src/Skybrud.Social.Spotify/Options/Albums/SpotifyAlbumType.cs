namespace Skybrud.Social.Spotify.Options.Albums {

    /// <summary>
    /// Enum class representing the type of a Spotify album.
    /// </summary>
    public enum SpotifyAlbumType {

        /// <summary>
        /// Indicates that normal albums should be returned.
        /// </summary>
        Album,

        /// <summary>
        /// Indicates that albums representing a single should be returned.
        /// </summary>
        Single,

        /// <summary>
        /// Indicates that albums the artist appears on should be returned.
        /// </summary>
        AppearsOn,

        /// <summary>
        /// Indicates that compilation albums should be returned.
        /// </summary>
        Compilation

    }

}