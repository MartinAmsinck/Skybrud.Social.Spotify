using System;
using System.Collections.Specialized;
using Skybrud.Social.Http;
using Skybrud.Social.Spotify.Endpoints.Raw;
using Skybrud.Social.Spotify.Responses.Authentication;
using Skybrud.Social.Spotify.Scopes;

namespace Skybrud.Social.Spotify.OAuth {

    public class SpotifyOAuthClient : SocialHttpClient {

        #region Properties

        /// <summary>
        /// Gets or sets the client ID of the app.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client secret of the app.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the redirect URI of your application.
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets a reference to the raw artists endpoint.
        /// </summary>
        public SpotifyArtistsRawEndpoint Artists { get; private set; }

        #endregion
        
        #region Constructors

        /// <summary>
        /// Initializes an OAuth client with empty information.
        /// </summary>
        public SpotifyOAuthClient() {
            Artists = new SpotifyArtistsRawEndpoint(this);
        }

        /// <summary>
        /// Initializes an OAuth client with the specified access token.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        public SpotifyOAuthClient(string accessToken) : this() {
            AccessToken = accessToken;
        }
        
        /// <summary>
        /// Initializes an OAuth client with the specified client ID and client secret.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        public SpotifyOAuthClient(string clientId, string clientSecret) : this() {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID, client secret and return URI.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        /// <param name="redirectUri">The redirect URI of the client.</param>
        public SpotifyOAuthClient(string clientId, string clientSecret, string redirectUri) : this() {
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        }

        #endregion

        #region Member methods
        
        /// <summary>
        /// Generates the authorization URL using the specified <code>state</code>.
        /// </summary>
        /// <param name="state">The state to send to the Spotify OAuth login page.</param>
        /// <returns>Returns an authorization URL based on <code>state</code>.</returns>
        public string GetAuthorizationUrl(string state) {
            return GetAuthorizationUrl(state, default(string[]));
        }

        /// <summary>
        /// Generates the authorization URL using the specified state and scope.
        /// </summary>
        /// <param name="state">The state to send to the Spotify OAuth login page.</param>
        /// <param name="scope">The scope of the application.</param>
        /// <returns>Returns an authorization URL based on <code>state</code> and <code>scope</code>.</returns>
        public string GetAuthorizationUrl(string state, SpotifyScopeCollection scope) {
            return GetAuthorizationUrl(state, scope == null ? null : scope.ToString());
        }
        
        /// <summary>
        /// Generates the authorization URL using the specified state and scope.
        /// </summary>
        /// <param name="state">The state to send to the Spotify OAuth login page.</param>
        /// <param name="scope">The scope of the application.</param>
        /// <returns>Returns an authorization URL based on <code>state</code> and <code>scope</code>.</returns>
        public string GetAuthorizationUrl(string state, params string[] scope) {

            // Input validation
            if (String.IsNullOrWhiteSpace(state)) throw new ArgumentNullException("state");
            if (String.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException("ClientId");
            if (String.IsNullOrWhiteSpace(RedirectUri)) throw new PropertyNotSetException("RedirectUri");
            
            // Construct the authorization URL
            return "https://accounts.spotify.com/authorize?" + SocialUtils.Misc.NameValueCollectionToQueryString(new NameValueCollection {
                {"client_id", ClientId},
                {"response_type", "code"},
                {"redirect_uri", RedirectUri},
                {"state", state},
                {"scope", String.Join(" ", scope ?? new string[0])}
            });
        
        }

        /// <summary>
        /// Exchanges the specified authorization code for a refresh token and an access token.
        /// </summary>
        /// <param name="authCode">The authorization code received from the Spotify OAuth dialog.</param>
        /// <returns>Returns an access token based on the specified <code>authCode</code>.</returns>
        public SpotifyTokenResponse GetAccessTokenFromAuthCode(string authCode) {

            // Input validation
            if (String.IsNullOrWhiteSpace(authCode)) throw new ArgumentNullException("authCode");
            if (String.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException("ClientId");
            if (String.IsNullOrWhiteSpace(ClientSecret)) throw new PropertyNotSetException("ClientSecret");
            if (String.IsNullOrWhiteSpace(RedirectUri)) throw new PropertyNotSetException("RedirectUri");

            // Initialize the POST data
            NameValueCollection data = new NameValueCollection {
                {"grant_type", "authorization_code"},
                {"code", authCode },
                {"redirect_uri", RedirectUri},
                {"client_id", ClientId},
                {"client_secret", ClientSecret}
            };

            // Make the call to the API
            SocialHttpResponse response = SocialUtils.Http.DoHttpPostRequest("https://accounts.spotify.com/api/token", null, data);

            // Parse the response
            return SpotifyTokenResponse.ParseResponse(response);

        }

        /// <summary>
        /// Gets a new access token from the specified <code>refreshToken</code>.
        /// </summary>
        /// <param name="refreshToken">The refresh token of the user.</param>
        /// <returns>Returns an access token based on the specified <code>refreshToken</code>.</returns>
        public SpotifyTokenResponse GetAccessTokenFromRefreshToken(string refreshToken) {

            // Input validation
            if (String.IsNullOrWhiteSpace(refreshToken)) throw new ArgumentNullException("refreshToken");
            if (String.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException("ClientId");
            if (String.IsNullOrWhiteSpace(ClientSecret)) throw new PropertyNotSetException("ClientSecret");
            if (String.IsNullOrWhiteSpace(RedirectUri)) throw new PropertyNotSetException("RedirectUri");

            // Initialize the POST data
            NameValueCollection data = new NameValueCollection {
                {"client_id", ClientId},
                {"redirect_uri", RedirectUri},
                {"client_secret", ClientSecret},
                {"refresh_token", refreshToken },
                {"grant_type", "refresh_token"}
            };

            // Make the call to the API
            SocialHttpResponse response = SocialUtils.Http.DoHttpPostRequest("https://accounts.spotify.com/api/token", null, data);

            // Parse the response
            return SpotifyTokenResponse.ParseResponse(response);

        }

        #endregion

    }

}