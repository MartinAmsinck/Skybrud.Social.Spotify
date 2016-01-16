using System;
using System.Net;
using Skybrud.Social.Http;

namespace Skybrud.Social.Spotify.Responses {

    /// <summary>
    /// Class representing a response from the Spotify Web API.
    /// </summary>
    public abstract class SpotifyResponse : SocialResponse {

        #region Constructor

        protected SpotifyResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Validates the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The response to be validated.</param>
        public static void ValidateResponse(SocialHttpResponse response) {

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;

            // Now throw some exceptions
            throw new Exception("WTF?");

        }

        #endregion

    }

    /// <summary>
    /// Class representing a response from the Spotify Web API.
    /// </summary>
    public class SpotifyResponse<T> : SpotifyResponse {

        #region Properties

        /// <summary>
        /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; }

        #endregion

        #region Constructors

        protected SpotifyResponse(SocialHttpResponse response) : base(response) { }

        #endregion

    }

}