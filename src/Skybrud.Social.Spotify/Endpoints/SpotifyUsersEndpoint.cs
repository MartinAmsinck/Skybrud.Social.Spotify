using Skybrud.Social.Spotify.Endpoints.Raw;
using Skybrud.Social.Spotify.Responses.Users;

namespace Skybrud.Social.Spotify.Endpoints {
    
    /// <summary>
    /// Class representing the implementation of the profiles endpoint.
    /// </summary>
    public class SpotifyUsersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Spotify service.
        /// </summary>
        public SpotifyService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public SpotifyUsersRawEndpoint Raw => Service.Client.Users;

        #endregion

        #region Constructors

        internal SpotifyUsersEndpoint(SpotifyService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets detailed profile information about the current user (including the current user’s username).
        /// </summary>
        /// <returns>An instance of <see cref="SpotifyGetAuthenticatedUserResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/web-api/get-current-users-profile/</cref>
        /// </see>
        public SpotifyGetAuthenticatedUserResponse GetUser() {
            return SpotifyGetAuthenticatedUserResponse.ParseResponse(Raw.GetUser());
        }

        /// <summary>
        /// Gets public profile information about the Spotify user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the Spotify user.</param>
        /// <returns>An instance of <see cref="SpotifyGetUserResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/web-api/get-current-users-profile/</cref>
        /// </see>
        public SpotifyGetUserResponse GetUser(string userId) {
            return SpotifyGetUserResponse.ParseResponse(Raw.GetUser(userId));
        }

        #endregion

    }

}