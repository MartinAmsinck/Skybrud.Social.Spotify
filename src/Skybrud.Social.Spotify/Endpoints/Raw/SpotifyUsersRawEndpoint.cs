using System;
using Skybrud.Social.Http;
using Skybrud.Social.Spotify.OAuth;

namespace Skybrud.Social.Spotify.Endpoints.Raw {
    
    /// <summary>
    /// Class representing the raw implementation of the profiles endpoint.
    /// </summary>
    public class SpotifyUsersRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public SpotifyOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal SpotifyUsersRawEndpoint(SpotifyOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets detailed profile information about the current user (including the current user's username).
        /// </summary>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/web-api/get-current-users-profile/</cref>
        /// </see>
        public SocialHttpResponse GetUser() {
            return Client.DoHttpGetRequest("/v1/me");
        }

        /// <summary>
        /// Gets public profile information about the Spotify user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the Spotify user.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/web-api/get-current-users-profile/</cref>
        /// </see>
        public SocialHttpResponse GetUser(string userId) {
            if (String.IsNullOrWhiteSpace(userId)) throw new ArgumentNullException(nameof(userId));
            return Client.DoHttpGetRequest($"/v1/users/{userId}");
        }

        #endregion

    }

}