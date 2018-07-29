using Skybrud.Social.Spotify.Endpoints.Raw;
using Skybrud.Social.Spotify.Responses.Player;

namespace Skybrud.Social.Spotify.Endpoints {

    /// <summary>
    /// Class representing the implementation of the player endpoint.
    /// </summary>
    public class SpotifyPlayerEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Spotify service.
        /// </summary>
        public SpotifyService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public SpotifyPlayerRawEndpoint Raw => Service.Client.Player;

        #endregion

        #region Constructors

        internal SpotifyPlayerEndpoint(SpotifyService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Get detailed profile information about the current user (including the current user’s username).
        /// </summary>
        /// <returns>An instance of <see cref="SpotifyGetPlayerResponse"/> representing the response.</returns>
        public SpotifyGetPlayerResponse GetCurrentlyPlaying() {
            return SpotifyGetPlayerResponse.ParseResponse(Raw.GetCurrentlyPlaying());
        }

        #endregion

    }

}