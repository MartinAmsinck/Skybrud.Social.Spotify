using System;
using Skybrud.Social.Http;

namespace Skybrud.Social.Spotify.Responses.Common {

    public class SpotifyNoContentResponse : SpotifyResponse {
        
        #region Constructors

        private SpotifyNoContentResponse(SocialHttpResponse response) : base(response) {
            
            // Validate the response
            ValidateResponse(response);
        
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="SpotifyNoContentResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyNoContentResponse"/>.</returns>
        public static SpotifyNoContentResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new SpotifyNoContentResponse(response);
        }

        #endregion

    }

}