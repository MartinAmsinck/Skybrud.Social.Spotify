﻿using System;
using Skybrud.Social.Http;
using Skybrud.Social.Spotify.Models.Albums;

namespace Skybrud.Social.Spotify.Responses.Albums {

    /// <summary>
    /// Class representing a response with information about a single Spotify album.
    /// </summary>
    public class SpotifyGetAlbumResponse : SpotifyResponse<SpotifyAlbum> {
        
        #region Constructors

        private SpotifyGetAlbumResponse(SocialHttpResponse response) : base(response) {
            
            // Validate the response
            ValidateResponse(response);
            
            // Parse the response body
            Body = ParseJsonObject(response.Body, SpotifyAlbum.Parse);
        
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="SpotifyGetAlbumResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyGetAlbumResponse"/>.</returns>
        public static SpotifyGetAlbumResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new SpotifyGetAlbumResponse(response);
        }

        #endregion

    }

}