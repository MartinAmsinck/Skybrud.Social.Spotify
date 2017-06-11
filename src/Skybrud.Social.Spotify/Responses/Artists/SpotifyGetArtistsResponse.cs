using Skybrud.Social.Http;
using Skybrud.Social.Spotify.Models.Artists;

namespace Skybrud.Social.Spotify.Responses.Artists {

    public class SpotifyGetArtistsResponse : SpotifyResponse<SpotifyArtistCollection> {
        
        #region Constructors

        private SpotifyGetArtistsResponse(SocialHttpResponse response) : base(response) {
            
            // Validate the response
            ValidateResponse(response);
            
            // Parse the response body
            Body = ParseJsonObject(response.Body, SpotifyArtistCollection.Parse);
        
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>SpotifyGetArtistsResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>SpotifyGetArtistsResponse</code>.</returns>
        public static SpotifyGetArtistsResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new SpotifyGetArtistsResponse(response);
        }

        #endregion

    }

}