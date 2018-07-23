using Skybrud.Social.Http;
using Skybrud.Social.Spotify.Models.Artists;
using Skybrud.Social.Spotify.Models.UserProfile;
using Skybrud.Social.Spotify.Responses.Artists;

namespace Skybrud.Social.Spotify.Responses.UserProfile {
    
    public class SpotifyGetUserProfileResponse : SpotifyResponse<SpotifyUserProfile> {
        
        #region Constructors

        private SpotifyGetUserProfileResponse(SocialHttpResponse response) : base(response) {
            
            // Validate the response
            ValidateResponse(response);
            
            // Parse the response body
            Body = ParseJsonObject(response.Body, SpotifyUserProfile.Parse);
        
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="SpotifyGetUserProfileResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyGetArtistResponse"/>.</returns>
        public static SpotifyGetUserProfileResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new SpotifyGetUserProfileResponse(response);
        }

        #endregion

    }

}