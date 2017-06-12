using Skybrud.Social.Http;
using Skybrud.Social.Spotify.Models.Authentication;

namespace Skybrud.Social.Spotify.Responses.Authentication {
    
    public class SpotifyTokenResponse : SpotifyResponse<SpotifyToken> {
        
        #region Constructors

        private SpotifyTokenResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, SpotifyToken.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="SpotifyTokenResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyTokenResponse"/>.</returns>
        public static SpotifyTokenResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new SpotifyTokenResponse(response);
        }

        #endregion

    }

}