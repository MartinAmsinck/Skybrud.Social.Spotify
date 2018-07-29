namespace Skybrud.Social.Spotify.Models.Albums {

    /// <summary>
    /// Enum class representing the relation between an artist and an album.
    /// </summary>
    public enum SpotifyAlbumGroup {

        Unspecified,

        /// <summary>
        /// Indicates that the album is a normal album.
        /// </summary>
        Album,

        /// <summary>
        /// Indicates that the album represents a single.
        /// </summary>
        Single,

        /// <summary>
        /// Indicates that the artist appears on the album.
        /// </summary>
        AppearsOn,

        /// <summary>
        /// Indicates that the album represents a compilation.
        /// </summary>
        Compilation

    }

}