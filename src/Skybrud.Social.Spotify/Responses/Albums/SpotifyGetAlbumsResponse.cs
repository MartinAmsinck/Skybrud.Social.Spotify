using System;
using Skybrud.Social.Http;
using Skybrud.Social.Spotify.Models.Albums;

namespace Skybrud.Social.Spotify.Responses.Albums {

    /// <summary>
    /// Class representing a response with a collection of Spotify albums.
    /// </summary>
    public class SpotifyGetAlbumsResponse : SpotifyResponse<SpotifyAlbumsCollection> {
        
        #region Constructors

        private SpotifyGetAlbumsResponse(SocialHttpResponse response) : base(response) {
            
            // Validate the response
            ValidateResponse(response);
            
            // Parse the response body
            Body = ParseJsonObject(response.Body, SpotifyAlbumsCollection.Parse);
        
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="SpotifyGetAlbumsResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyGetAlbumsResponse"/>.</returns>
        public static SpotifyGetAlbumsResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new SpotifyGetAlbumsResponse(response);
        }

        #endregion

    }

}