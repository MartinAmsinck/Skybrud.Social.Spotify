using System;
using Skybrud.Social.Http;
using Skybrud.Social.Spotify.Models.Tracks;

namespace Skybrud.Social.Spotify.Responses.Albums {

    /// <summary>
    /// Class representing a response with a collection of tracks of a Spotify artist.
    /// </summary>
    public class SpotifyGetAlbumTracksResponse : SpotifyResponse<SpotifyTracksCollection> {
        
        #region Constructors

        private SpotifyGetAlbumTracksResponse(SocialHttpResponse response) : base(response) {
            
            // Validate the response
            ValidateResponse(response);
            
            // Parse the response body
            Body = ParseJsonObject(response.Body, SpotifyTracksCollection.Parse);
        
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="SpotifyGetAlbumTracksResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyGetAlbumTracksResponse"/>.</returns>
        public static SpotifyGetAlbumTracksResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new SpotifyGetAlbumTracksResponse(response);
        }

        #endregion

    }

}