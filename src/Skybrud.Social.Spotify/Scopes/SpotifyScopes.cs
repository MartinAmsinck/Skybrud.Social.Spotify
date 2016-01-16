namespace Skybrud.Social.Spotify.Scopes {
    
    /// <summary>
    /// Static class with properties representing scopes of available for the Spotify Web API.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.spotify.com/web-api/using-scopes/#list-of-scopes</cref>
    /// </see>
    public class SpotifyScopes {
        
        /// <summary>
        /// Read access to user's private playlists.
        /// </summary>
        public static readonly SpotifyScope PlaylistReadPrivate = new SpotifyScope("playlist-read-private", "Read access to user's private playlists.");
        
        /// <summary>
        /// Include collaborative playlists when requesting a user's playlists.
        /// </summary>
        public static readonly SpotifyScope PlaylistReadCollaborative = new SpotifyScope("playlist-read-collaborative", "Include collaborative playlists when requesting a user's playlists.");

        /// <summary>
        /// Write access to a user's public playlists.
        /// </summary>
        public static readonly SpotifyScope PlaylistModifyPublic = new SpotifyScope("playlist-modify-public", "Write access to a user's public playlists.");

        /// <summary>
        /// Write access to a user's private playlists.
        /// </summary>
        public static readonly SpotifyScope PlaylistModifyPrivate = new SpotifyScope("playlist-modify-private", "Write access to a user's private playlists.");

        /// <summary>
        /// Control playback of a Spotify track. This scope is currently only available to Spotify native SDKs (for example, the iOS SDK and the Android SDK). The user must have a Spotify Premium account.
        /// </summary>
        public static readonly SpotifyScope Streaming = new SpotifyScope("streaming	", "Control playback of a Spotify track. This scope is currently only available to Spotify native SDKs (for example, the iOS SDK and the Android SDK). The user must have a Spotify Premium account.");

        /// <summary>
        /// Write/delete access to the list of artists and other users that the user follows.
        /// </summary>
        public static readonly SpotifyScope UserFollowModify = new SpotifyScope("user-follow-modify", "Write/delete access to the list of artists and other users that the user follows.");

        /// <summary>
        /// Read access to the list of artists and other users that the user follows.
        /// </summary>
        public static readonly SpotifyScope UserFollowRead = new SpotifyScope("user-follow-read", "Read access to the list of artists and other users that the user follows.");

        /// <summary>
        /// Read access to a user's "Your Music" library.
        /// </summary>
        public static readonly SpotifyScope UserLibraryRead = new SpotifyScope("user-library-read", "Read access to a user's \"Your Music\" library.");

        /// <summary>
        /// Write/delete access to a user's "Your Music" library.
        /// </summary>
        public static readonly SpotifyScope UserLibraryModify = new SpotifyScope("user-library-modify", "Write/delete access to a user's \"Your Music\" library.");

        /// <summary>
        /// Read access to user’s subscription details (type of user account).
        /// </summary>
        public static readonly SpotifyScope UserReadPrivate = new SpotifyScope("user-read-private", "Read access to user’s subscription details (type of user account).");

        /// <summary>
        /// Read access to the user's birthdate.
        /// </summary>
        public static readonly SpotifyScope UserReadBirthdate = new SpotifyScope("user-read-birthdate", "Read access to the user's birthdate.");

        /// <summary>
        /// Read access to user’s email address.
        /// </summary>
        public static readonly SpotifyScope UserReadEmail = new SpotifyScope("user-read-email", "Read access to user’s email address.");

    }

}