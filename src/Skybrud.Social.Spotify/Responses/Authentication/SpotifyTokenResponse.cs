using System;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Http;
using Skybrud.Social.Spotify.Objects.Authentication;

namespace Skybrud.Social.Spotify.Responses.Authentication {
    
    public class SpotifyTokenResponse : SpotifyResponse<SpotifyToken> {
        
        #region Constructors

        private SpotifyTokenResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>SpotifyTokenResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>SpotifyTokenResponse</code>.</returns>
        public static SpotifyTokenResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");
            
            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new SpotifyTokenResponse(response) {
                Body =  SpotifyToken.Parse(JObject.Parse(response.Body))
            };

        }

        #endregion

    }

}