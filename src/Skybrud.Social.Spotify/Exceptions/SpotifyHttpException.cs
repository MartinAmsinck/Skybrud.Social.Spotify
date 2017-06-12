using System;
using Skybrud.Social.Http;

namespace Skybrud.Social.Spotify.Exceptions {

    /// <summary>
    /// Class representing an exception/error returned by the Spotify Web API.
    /// </summary>
    public class SpotifyHttpException : Exception {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <see cref="SocialHttpResponse"/>.
        /// </summary>
        public SocialHttpResponse Response { get; private set; }

        /// <summary>
        /// Gets the type of the error.
        /// </summary>
        public string Error { get; private set; }

        /// <summary>
        /// Gets the description of the error.
        /// </summary>
        public string ErrorDescription { get; private set; }

        #endregion

        #region Constructors
        
        internal SpotifyHttpException(SocialHttpResponse response, string error, string errorDescription) {
            Response = response;
            Error = error;
            ErrorDescription = errorDescription;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets the message of the exception.
        /// </summary>
        public override string Message {
            get {
                string message = "Invalid response received from the Spotify Web API (Status: " + ((int) Response.StatusCode) + ")";
                return String.IsNullOrEmpty(ErrorDescription) ? message : message + ": " + ErrorDescription;
            }
        }

        #endregion

    }

}