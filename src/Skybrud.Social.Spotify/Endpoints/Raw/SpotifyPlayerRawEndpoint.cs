using Skybrud.Social.Http;
using Skybrud.Social.Spotify.OAuth;

namespace Skybrud.Social.Spotify.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the player endpoint.
    /// </summary>
    public class SpotifyPlayerRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public SpotifyOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal SpotifyPlayerRawEndpoint(SpotifyOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Get the object currently being played on the user’s Spotify account.
        /// </summary>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/get-the-users-currently-playing-track/</cref>
        /// </see>
        public SocialHttpResponse GetCurrentlyPlaying() {
            return Client.DoHttpGetRequest("/v1/me/player/currently-playing");
        }

        #endregion

    }

}