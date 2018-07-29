using System;
using Skybrud.Social.Spotify.Endpoints;
using Skybrud.Social.Spotify.OAuth;
using Skybrud.Social.Spotify.Responses.Authentication;

namespace Skybrud.Social.Spotify {

    /// <summary>
    /// Class working as an entry point to the Spotify Web API.
    /// </summary>
    public class SpotifyService {

        #region Properties

        /// <summary>
        /// Gets a reference to the internal OAuth client.
        /// </summary>
        public SpotifyOAuthClient Client { get; }

        /// <summary>
        /// Gets a reference to the albums endpoint.
        /// </summary>
        public SpotifyAlbumsEndpoint Albums { get; }

        /// <summary>
        /// Gets a reference to the artists endpoint.
        /// </summary>
        public SpotifyArtistsEndpoint Artists { get; }

        /// <summary>
        /// Gets a reference to the player endpoint.
        /// </summary>
        public SpotifyPlayerEndpoint Player { get; }
        public SpotifyTracksEndpoint Tracks{ get; }

        /// <summary>
        /// Gets a reference to the users endpoint.
        /// </summary>
        public SpotifyUsersEndpoint Users { get; }

        #endregion

        #region Constructors

        private SpotifyService(SpotifyOAuthClient client) {
            Client = client;
            Albums = new SpotifyAlbumsEndpoint(this);
            Artists = new SpotifyArtistsEndpoint(this);
            Player = new SpotifyPlayerEndpoint(this);
            Tracks = new SpotifyTracksEndpoint(this);
            Users = new SpotifyUsersEndpoint(this);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initialize a new service instance from the specified OAuth <paramref name="client"/>.
        /// </summary>
        /// <param name="client">The OAuth client.</param>
        /// <returns>The created instance of <see cref="Skybrud.Social.Spotify.SpotifyService" />.</returns>
        public static SpotifyService CreateFromOAuthClient(SpotifyOAuthClient client) {
            if (client == null) throw new ArgumentNullException(nameof(client));
            return new SpotifyService(client);
        }

        /// <summary>
        /// Initializes a new service instance from the specifie OAuth 2 <paramref name="accessToken"/>.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <returns>The created instance of <see cref="Skybrud.Social.Spotify.SpotifyService" />.</returns>
        public static SpotifyService GreateFromAccessToken(string accessToken) {
            if (String.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException(nameof(accessToken));
            return new SpotifyService(new SpotifyOAuthClient(accessToken));
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="refreshToken"/>.
        /// </summary>
        /// <param name="clientId">The client ID.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <param name="refreshToken">The refresh token of the user.</param>
        /// <returns>The created instance of <see cref="Skybrud.Social.Spotify.SpotifyService" />.</returns>
        public static SpotifyService CreateFromRefreshToken(string clientId, string clientSecret, string refreshToken) {

            if (String.IsNullOrWhiteSpace(clientId)) throw new ArgumentNullException(nameof(clientId));
            if (String.IsNullOrWhiteSpace(clientSecret)) throw new ArgumentNullException(nameof(clientSecret));
            if (String.IsNullOrWhiteSpace(refreshToken)) throw new ArgumentNullException(nameof(refreshToken));

            // Initialize a new OAuth client
            SpotifyOAuthClient client = new SpotifyOAuthClient(clientId, clientSecret);

            // Get an access token from the refresh token.
            SpotifyTokenResponse response = client.GetAccessTokenFromRefreshToken(refreshToken);

            // Update the OAuth client with the access token
            client.AccessToken = response.Body.AccessToken;

            // Initialize a new service instance
            return new SpotifyService(client);

        }

        #endregion

    }

}