using System;
using Skybrud.Social.Http;
using Skybrud.Social.Spotify.Models.Users;

namespace Skybrud.Social.Spotify.Responses.Users {

    /// <summary>
    /// Class representing a response with information about the authenticated Spotify user.
    /// </summary>
    public class SpotifyGetAuthenticatedUserResponse : SpotifyResponse<SpotifyUserPrivate> {
        
        #region Constructors

        private SpotifyGetAuthenticatedUserResponse(SocialHttpResponse response) : base(response) {
            
            // Validate the response
            ValidateResponse(response);
            
            // Parse the response body
            Body = ParseJsonObject(response.Body, SpotifyUserPrivate.Parse);
        
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="SpotifyGetAuthenticatedUserResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyGetAuthenticatedUserResponse"/>.</returns>
        public static SpotifyGetAuthenticatedUserResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new SpotifyGetAuthenticatedUserResponse(response);
        }

        #endregion

    }

}