using Skybrud.Social.Spotify.OAuth;

namespace Skybrud.Social.Spotify.Endpoints.Raw {
    
    /// <summary>
    /// Class representing the raw implementation of the user profile endpoint.
    /// </summary>
    public class SpotifyPersonalizationRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public SpotifyOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal SpotifyPersonalizationRawEndpoint(SpotifyOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods
        
        #endregion

    }

}