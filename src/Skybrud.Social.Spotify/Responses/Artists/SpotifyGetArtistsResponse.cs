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
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="SpotifyGetArtistsResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyGetArtistsResponse"/>.</returns>
        public static SpotifyGetArtistsResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new SpotifyGetArtistsResponse(response);
        }

        #endregion

    }

}