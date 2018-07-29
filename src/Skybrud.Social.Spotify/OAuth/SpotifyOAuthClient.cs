using System;
using Skybrud.Essentials.Common;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;
using Skybrud.Social.Spotify.Endpoints.Raw;
using Skybrud.Social.Spotify.Responses.Authentication;
using Skybrud.Social.Spotify.Scopes;

namespace Skybrud.Social.Spotify.OAuth {

    /// <summary>
    /// Class for handling the raw communication with the Spotify Web API as well as any OAuth 2.0 communication.
    /// </summary>
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
        public SpotifyArtistsRawEndpoint Artists { get; }

        public SpotifyTracksRawEndpoint	 Tracks { get; set; }
        public SpotifyUserProfileRawEndpoint UserProfile { get; set; }

        #endregion
        
        #region Constructors

        /// <summary>
        /// Initializes a new OAuth client with default options.
        /// </summary>
        public SpotifyOAuthClient()
        {
            Artists = new SpotifyArtistsRawEndpoint(this);
            Tracks = new SpotifyTracksRawEndpoint(this);
            UserProfile = new SpotifyUserProfileRawEndpoint(this);
        }

        /// <summary>
        /// Initializes a new OAuth client with the specified <paramref name="accessToken"/>.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        public SpotifyOAuthClient(string accessToken) : this() {
            AccessToken = accessToken;
        }
        
        /// <summary>
        /// Initializes a new OAuth client with the specified <paramref name="clientId"/> and
        /// <paramref name="clientSecret"/>.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        public SpotifyOAuthClient(string clientId, string clientSecret) : this() {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Initializes a new OAuth client with the specified <paramref name="clientId"/>,
        /// <paramref name="clientSecret"/> and <paramref name="redirectUri"/>.
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
        /// Generates the authorization URL using the specified <paramref name="state"/>.
        /// </summary>
        /// <param name="state">The state to send to the Spotify OAuth login page.</param>
        /// <returns>An authorization URL based on <paramref name="state"/>.</returns>
        public string GetAuthorizationUrl(string state) {
            return GetAuthorizationUrl(state, default(string[]));
        }

        /// <summary>
        /// Generates the authorization URL using the specified <paramref name="state"/> and <paramref name="scope"/>.
        /// </summary>
        /// <param name="state">The state to send to the Spotify OAuth login page.</param>
        /// <param name="scope">The scope of the application.</param>
        /// <returns>An authorization URL based on <paramref name="state"/> and <paramref name="scope"/>.</returns>
        public string GetAuthorizationUrl(string state, SpotifyScopeCollection scope) {
            return GetAuthorizationUrl(state, scope == null ? null : scope.ToString());
        }
        
        /// <summary>
        /// Generates the authorization URL using the specified <paramref name="state"/> and <paramref name="scope"/>.
        /// </summary>
        /// <param name="state">The state to send to the Spotify OAuth login page.</param>
        /// <param name="scope">The scope of the application.</param>
        /// <returns>An authorization URL based on <paramref name="state"/> and <paramref name="scope"/>.</returns>
        public string GetAuthorizationUrl(string state, params string[] scope) {

            // Input validation
            if (String.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException(nameof(ClientId));
            if (String.IsNullOrWhiteSpace(RedirectUri)) throw new PropertyNotSetException(nameof(RedirectUri));
            
            // Do we have a valid "state" ?
            if (String.IsNullOrWhiteSpace(state)) {
                throw new ArgumentNullException(nameof(state), "A valid state should be specified as it is part of the security of OAuth 2.0.");
            }

            // Construct the query string
            IHttpQueryString query = new SocialHttpQueryString();
            query.Add("client_id", ClientId);
            query.Add("response_type", "code");
            query.Add("redirect_uri", RedirectUri);
            query.Add("state", state);
            query.Add("scope", String.Join(" ", scope ?? new string[0]));

            // Construct the authorization URL
            return "https://accounts.spotify.com/authorize?" + query;

        }
        
        /// <summary>
        /// Exchanges the specified <paramref name="authorizationCode"/> for a refresh token and an access token.
        /// </summary>
        /// <param name="authorizationCode">The authorization code received from the Spotify OAuth dialog.</param>
        /// <returns>An instance of <see cref="SpotifyTokenResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/web-api/authorization-guide/</cref>
        /// </see>
        public SpotifyTokenResponse GetAccessTokenFromAuthorizationCode(string authorizationCode) {

            // Input validation
            if (String.IsNullOrWhiteSpace(authorizationCode)) throw new ArgumentNullException(nameof(authorizationCode));
            if (String.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException(nameof(ClientId));
            if (String.IsNullOrWhiteSpace(ClientSecret)) throw new PropertyNotSetException(nameof(ClientSecret));
            if (String.IsNullOrWhiteSpace(RedirectUri)) throw new PropertyNotSetException(nameof(RedirectUri));

            // Initialize the POST data
            IHttpPostData postData = new SocialHttpPostData();
            postData.Add("grant_type", "authorization_code");
            postData.Add("code", authorizationCode);
            postData.Add("redirect_uri", RedirectUri);
            postData.Add("client_id", ClientId);
            postData.Add("client_secret", ClientSecret);

            // Initialize the request
            SocialHttpRequest request = new SocialHttpRequest {
                Method = SocialHttpMethod.Post,
                Url = "https://accounts.spotify.com/api/token",
                PostData = postData
            };

            // Make a call to the server
            SocialHttpResponse response = request.GetResponse();

            // Parse the JSON response
            return SpotifyTokenResponse.ParseResponse(response);

        }

        /// <summary>
        /// Gets a new access token from the specified <paramref name="refreshToken"/>.
        /// </summary>
        /// <param name="refreshToken">The refresh token of the user.</param>
        /// <returns>An instance of <see cref="SpotifyTokenResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/web-api/authorization-guide/#request-access-token-from-refresh-token</cref>
        /// </see>
        public SpotifyTokenResponse GetAccessTokenFromRefreshToken(string refreshToken) {

            // Input validation
            if (String.IsNullOrWhiteSpace(refreshToken)) throw new ArgumentNullException(nameof(refreshToken));
            if (String.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException(nameof(ClientId));
            if (String.IsNullOrWhiteSpace(ClientSecret)) throw new PropertyNotSetException(nameof(ClientSecret));

            // Initialize the POST data
            IHttpPostData postData = new SocialHttpPostData();
            postData.Add("client_id", ClientId);
            postData.Add("client_secret", ClientSecret);
            postData.Add("refresh_token", refreshToken);
            postData.Add("grant_type", "refresh_token");

            SocialHttpRequest request = new SocialHttpRequest {
                Method = SocialHttpMethod.Post,
                Url = "https://accounts.spotify.com/api/token",
                PostData = postData
            };

            // Make a call to the server
            SocialHttpResponse response = request.GetResponse();

            // Parse the JSON response
            return SpotifyTokenResponse.ParseResponse(response);

        }

        #endregion

        protected override void PrepareHttpRequest(SocialHttpRequest request)
        {

            // Append the access token to the query string if present in the client and not already
            // specified in the query string
            if (!request.QueryString.ContainsKey("access_token") && !String.IsNullOrWhiteSpace(AccessToken))
            {
                request.QueryString.Add("access_token", AccessToken);
            }
        }
    }

}
