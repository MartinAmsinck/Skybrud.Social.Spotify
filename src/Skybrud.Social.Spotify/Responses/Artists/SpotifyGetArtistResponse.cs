using Skybrud.Social.Http;
using Skybrud.Social.Spotify.Objects.Artists;

namespace Skybrud.Social.Spotify.Responses.Artists {
    
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
        /// Parses the specified <code>response</code> into an instance of <code>SpotifyGetArtistResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>SpotifyGetArtistResponse</code>.</returns>
        public static SpotifyGetArtistResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new SpotifyGetArtistResponse(response);
        }

        #endregion

    }

}