using System;
using Skybrud.Social.Http;
using Skybrud.Social.Spotify.Models.Artists;

namespace Skybrud.Social.Spotify.Responses.Artists {
    
    /// <summary>
    /// Class representing a response with information about a single artist.
    /// </summary>
    public class SpotifyGetArtistResponse : SpotifyResponse<SpotifyArtist> {
        
        #region Constructors

        private SpotifyGetArtistResponse(SocialHttpResponse response) : base(response) {
            
            // Validate the response
            ValidateResponse(response);
            
            // Parse the response body
            Body = ParseJsonObject(response.Body, SpotifyArtist.Parse);
        
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="SpotifyGetArtistResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyGetArtistResponse"/>.</returns>
        public static SpotifyGetArtistResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new SpotifyGetArtistResponse(response);
        }

        #endregion

    }

}