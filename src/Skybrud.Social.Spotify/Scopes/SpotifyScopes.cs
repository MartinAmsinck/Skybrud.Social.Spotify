namespace Skybrud.Social.Spotify.Scopes {

    /// <summary>
    /// Static class with properties representing scopes of available for the Spotify Web API.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.spotify.com/documentation/general/guides/scopes/</cref>
    /// </see>
    public class SpotifyScopes {

        /// <summary>
        /// Remote control playback of Spotify. This scope is currently available to Spotify iOS and Android App Remote SDKs.
        /// </summary>
        public static readonly SpotifyScope AppRemoteControl = new SpotifyScope("app-remote-control", "Remote control playback of Spotify. This scope is currently available to Spotify iOS and Android App Remote SDKs.");

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
        /// Read access to a user’s currently playing track.
        /// </summary>
        public static readonly SpotifyScope UserReadCurrentlyPlaying = new SpotifyScope("user-read-currently-playing", "Read access to a user’s currently playing track.");

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
        /// Write access to a user’s playback state.
        /// </summary>
        public static readonly SpotifyScope UserModifyPlaybackState = new SpotifyScope("user-modify-playback-state", "Write access to a user’s playback state.");

        /// <summary>
        /// Read access to a user’s player state.
        /// </summary>
        public static readonly SpotifyScope UserReadPlaybackState = new SpotifyScope("user-read-playback-state", "Read access to a user’s player state.");

        /// <summary>
        /// Read access to user’s subscription details (type of user account).
        /// </summary>
        public static readonly SpotifyScope UserReadPrivate = new SpotifyScope("user-read-private", "Read access to user’s subscription details (type of user account).");

        /// <summary>
        /// 	Read access to a user’s recently played tracks.
        /// </summary>
        public static readonly SpotifyScope UserReadRecentlyPlayed = new SpotifyScope("user-read-recently-played", "Read access to a user’s recently played tracks.");

        /// <summary>
        /// Read access to the user's birthdate.
        /// </summary>
        public static readonly SpotifyScope UserReadBirthdate = new SpotifyScope("user-read-birthdate", "Read access to the user's birthdate.");

        /// <summary>
        /// Read access to user’s email address.
        /// </summary>
        public static readonly SpotifyScope UserReadEmail = new SpotifyScope("user-read-email", "Read access to user’s email address.");

        /// <summary>
        /// Read access to a user's top artists and tracks.
        /// </summary>
        public static readonly SpotifyScope UserTopRead = new SpotifyScope("user-top-read", "Read access to a user's top artists and tracks.");

    }

}