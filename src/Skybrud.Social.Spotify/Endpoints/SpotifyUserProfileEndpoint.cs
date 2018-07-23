using System;
using Skybrud.Social.Http;
using Skybrud.Social.Spotify.Endpoints.Raw;
using Skybrud.Social.Spotify.Options.Artists;
using Skybrud.Social.Spotify.Responses.Artists;
using Skybrud.Social.Spotify.Responses.Player;
using Skybrud.Social.Spotify.Responses.UserProfile;

namespace Skybrud.Social.Spotify.Endpoints
{

    /// <summary>
    /// Class representing the implementation of the user profile endpoint.
    /// </summary>
    public class SpotifyUserProfileEndpoint
    {

        #region Properties

        /// <summary>
        /// Gets a reference to the Spotify service.
        /// </summary>
        public SpotifyService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        //public SpotifyUserProfileRawEndpoint Raw => Service.Client.UserProfile;
        public SpotifyUserProfileRawEndpoint Raw => Service.Client.UserProfile;

        #endregion

        #region Constructors

        internal SpotifyUserProfileEndpoint(SpotifyService service)
        {
            Service = service;
            
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Get detailed profile information about the current user (including the current user’s username).
        /// </summary>
        /// <returns>An instance of <see cref="SpotifyGetUserProfileResponse"/> representing the response.</returns>
        public SpotifyGetUserProfileResponse GetMe()
        {
            return SpotifyGetUserProfileResponse.ParseResponse(Raw.GetMe());
        }

        /// <summary>
        /// Get detailed profile information about the current user (including the current user’s username).
        /// </summary>
        /// <returns>An instance of <see cref="SpotifyGetPlayerResponse"/> representing the response.</returns>
        public SpotifyGetPlayerResponse GetCurrentlyPlaying()
        {
            return SpotifyGetPlayerResponse.ParseResponse(Raw.GetCurrentlyPlaying());
        }

        /// <summary>
        /// Get public profile information about a Spotify user identified by their unique user ID.
        /// </summary>
        /// <param name="id">The Spotify user ID for the user. </param>
        /// <returns>An instance of <see cref="SpotifyGetUserProfileResponse"/> representing the response.</returns>
        public SpotifyGetUserProfileResponse GetUser(string id)
        {
            return SpotifyGetUserProfileResponse.ParseResponse(Raw.GetUser(id));
        }

        #endregion
    }
}