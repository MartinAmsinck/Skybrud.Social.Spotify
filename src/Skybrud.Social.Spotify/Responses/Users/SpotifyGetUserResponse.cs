using System;
using Skybrud.Social.Http;
using Skybrud.Social.Spotify.Models.Users;

namespace Skybrud.Social.Spotify.Responses.Users {

    /// <summary>
    /// Class representing a response with information about a single Spotify user.
    /// </summary>
    public class SpotifyGetUserResponse : SpotifyResponse<SpotifyUser> {
        
        #region Constructors

        private SpotifyGetUserResponse(SocialHttpResponse response) : base(response) {
            
            // Validate the response
            ValidateResponse(response);
            
            // Parse the response body
            Body = ParseJsonObject(response.Body, SpotifyUser.Parse);
        
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="SpotifyGetUserResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyGetUserResponse"/>.</returns>
        public static SpotifyGetUserResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new SpotifyGetUserResponse(response);
        }

        #endregion

    }

}