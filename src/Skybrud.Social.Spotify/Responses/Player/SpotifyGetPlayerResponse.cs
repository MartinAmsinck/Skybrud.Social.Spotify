using Skybrud.Social.Http;
using Skybrud.Social.Spotify.Models.Player;
using Skybrud.Social.Spotify.Models.UserProfile;
using Skybrud.Social.Spotify.Responses.Artists;
using Skybrud.Social.Spotify.Responses.UserProfile;

namespace Skybrud.Social.Spotify.Responses.Player {
    
    public class SpotifyGetPlayerResponse : SpotifyResponse<SpotifyPlayer> {
        
        #region Constructors

        private SpotifyGetPlayerResponse(SocialHttpResponse response) : base(response) {
            
            // Validate the response
            ValidateResponse(response);
            
            // Parse the response body
            Body = ParseJsonObject(response.Body, SpotifyPlayer.Parse);
        
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="SpotifyGetPlayerResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyGetPlayerResponse"/>.</returns>
        public static SpotifyGetPlayerResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new SpotifyGetPlayerResponse(response);
        }

        #endregion

    }

}