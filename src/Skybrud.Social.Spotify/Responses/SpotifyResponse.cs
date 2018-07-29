using System.Net;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Http;
using Skybrud.Social.Spotify.Exceptions;

namespace Skybrud.Social.Spotify.Responses {

    /// <summary>
    /// Class representing a response from the Spotify Web API.
    /// </summary>
    public abstract class SpotifyResponse : SocialResponse {

        #region Constructor

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response.</param>
        protected SpotifyResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Validates the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response to be validated.</param>
        public static void ValidateResponse(SocialHttpResponse response) {

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;
            if (response.StatusCode == HttpStatusCode.NoContent) return;

            // Parse the response body
            JObject obj = ParseJsonObject(response.Body);

            // Now throw some exceptions
            throw new SpotifyHttpException(
                response,
                obj.GetString("error"),
                obj.GetString("error_description")
            );

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

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response.</param>
        protected SpotifyResponse(SocialHttpResponse response) : base(response) { }

        #endregion

    }

}