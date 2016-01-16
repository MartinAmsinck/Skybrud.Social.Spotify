using System;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.Spotify.Objects.Authentication {
    
    /// <summary>
    /// Class representing the response body of a call to get a refresh token or an access token.
    /// </summary>
    public class SpotifyToken : SpotifyObject {

        #region Properties

        public string AccessToken { get; private set; }

        public string TokenType { get; private set; }

        public TimeSpan ExpiresIn { get; private set; }

        public string RefreshToken { get; private set; }

        #endregion

        #region Constructors

        private SpotifyToken(JObject obj) : base(obj) {
            AccessToken = obj.GetString("access_token");
            TokenType = obj.GetString("token_type");
            ExpiresIn = obj.GetDouble("expires_in", TimeSpan.FromSeconds);
            RefreshToken = obj.GetString("refresh_token");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>SpotifyToken</code> from the specified <code>JObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JObject</code> to parse.</param>
        public static SpotifyToken Parse(JObject obj) {
            return obj == null ? null : new SpotifyToken(obj);
        }

        #endregion

    }

}