using System;
using Skybrud.Social.Http;
using Skybrud.Social.Spotify.OAuth;
using Skybrud.Social.Spotify.Options.Player;
using Skybrud.Social.Spotify.Scopes;

namespace Skybrud.Social.Spotify.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the player endpoint.
    /// </summary>
    public class SpotifyPlayerRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public SpotifyOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal SpotifyPlayerRawEndpoint(SpotifyOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the current playback of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/get-information-about-the-users-current-playback/</cref>
        /// </see>
        public SocialHttpResponse GetPlayer() {
            return Client.DoHttpGetRequest("/v1/me/player");
        }

        /// <summary>
        /// Gets the object currently being played on the user’s Spotify account.
        /// </summary>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/get-the-users-currently-playing-track/</cref>
        /// </see>
        public SocialHttpResponse GetCurrentlyPlaying() {
            return Client.DoHttpGetRequest("/v1/me/player/currently-playing");
        }

        /// <summary>
        /// Gets the recently played tracks of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/get-recently-played/</cref>
        /// </see>
        public SocialHttpResponse GetRecentlyPlayed() {
            return GetRecentlyPlayed(new SpotifyGetRecentlyPlayedOptions());
        }

        /// <summary>
        /// Gets the recently played tracks of the authenticated user.
        /// </summary>
        /// <param name="limit">The maximum number of items to return. Default: <c>20</c>. Minimum: <c>1</c>. Maximum: <c>50</c>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/get-recently-played/</cref>
        /// </see>
        public SocialHttpResponse GetRecentlyPlayed(int limit) {
            return GetRecentlyPlayed(new SpotifyGetRecentlyPlayedOptions(limit));
        }

        /// <summary>
        /// Gets the recently played tracks of the authenticated user.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/get-recently-played/</cref>
        /// </see>
        public SocialHttpResponse GetRecentlyPlayed(SpotifyGetRecentlyPlayedOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.DoHttpGetRequest("/v1/me/player/recently-played", options);
        }
        
        /// <summary>
        /// Starts or resumes the playback of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/start-a-users-playback/</cref>
        /// </see>
        public SocialHttpResponse Play() {
            return Client.DoHttpPutRequest("/v1/me/player/play");
        }

        /// <summary>
        /// Pauses the playback of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/pause-a-users-playback/</cref>
        /// </see>
        public SocialHttpResponse Pause() {
            return Client.DoHttpPutRequest("/v1/me/player/pause");
        }

        /// <summary>
        /// Changes the volume of the current device of the authenticated user. Requires the <see cref="SpotifyScopes.UserModifyPlaybackState"/> scope.
        /// </summary>
        /// <param name="volume">The volume to set. Must be a value from <c>0</c> to <c>100</c> inclusive.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/set-volume-for-users-playback/</cref>
        /// </see>
        public SocialHttpResponse SetVolume(int volume) {
            return SetVolume(volume, default(string));
        }

        /// <summary>
        /// Changes the volume of the device with the specified <paramref name="deviceId"/>. Requires the <see cref="SpotifyScopes.UserModifyPlaybackState"/> scope.
        /// </summary>
        /// <param name="volume">The volume to set. Must be a value from <c>0</c> to <c>100</c> inclusive.</param>
        /// <param name="deviceId">The ID of the device this command is targeting. If not supplied, the user’s currently active device is the target.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/set-volume-for-users-playback/</cref>
        /// </see>
        public SocialHttpResponse SetVolume(int volume, string deviceId) {

            // Initialize the query string
            SocialHttpQueryString query = new SocialHttpQueryString {
                {"volume_percent", volume }
            };

            // Append the device ID (if present)
            if (!String.IsNullOrWhiteSpace(deviceId)) query.Add("device_id", deviceId);

            // Make the request to the API
            return Client.DoHttpPutRequest("/v1/me/player/volume", query);

        }

        /// <summary>
        /// Skips the user's playback to the next track.
        /// </summary>
        /// <param name="deviceId">The ID of the device this command is targeting. If not supplied, the user’s currently active device is the target.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/skip-users-playback-to-next-track/</cref>
        /// </see>
        public SocialHttpResponse Next(string deviceId) {

            // Initialize the query string
            SocialHttpQueryString query = new SocialHttpQueryString();

            // Append the device ID (if present)
            if (!String.IsNullOrWhiteSpace(deviceId)) query.Add("device_id", deviceId);

            // Make the request to the API
            return Client.DoHttpPostRequest("/v1/me/player/next", query);

        }

        /// <summary>
        /// Skips the user's playback to the previous track.
        /// </summary>
        /// <param name="deviceId">The ID of the device this command is targeting. If not supplied, the user’s currently active device is the target.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/skip-users-playback-to-previous-track/</cref>
        /// </see>
        public SocialHttpResponse Previous(string deviceId) {

            // Initialize the query string
            SocialHttpQueryString query = new SocialHttpQueryString();

            // Append the device ID (if present)
            if (!String.IsNullOrWhiteSpace(deviceId)) query.Add("device_id", deviceId);

            // Make the request to the API
            return Client.DoHttpPostRequest("/v1/me/player/previous", query);

        }

        /// <summary>
        /// Seeks to the given position in the user’s currently playing track.
        /// </summary>
        /// <param name="position">The position to seek to. Must be a positive number. Passing in a position that is greater than the length of the track will cause the player to start playing the next song.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/seek-to-position-in-currently-playing-track/</cref>
        /// </see>
        public SocialHttpResponse Seek(TimeSpan position) {
            return Seek(new SpotifyPlayerSeekOptions(position));
        }

        /// <summary>
        /// Seeks to the given position in the user’s currently playing track.
        /// </summary>
        /// <param name="position">The position to seek to. Must be a positive number. Passing in a position that is greater than the length of the track will cause the player to start playing the next song.</param>
        /// <param name="deviceId">The ID of the device this command is targeting. If not supplied, the user’s currently active device is the target.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/seek-to-position-in-currently-playing-track/</cref>
        /// </see>
        public SocialHttpResponse Seek(TimeSpan position, string deviceId) {
            return Seek(new SpotifyPlayerSeekOptions(position, deviceId));
        }

        /// <summary>
        /// Seeks to the given position in the user’s currently playing track.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/seek-to-position-in-currently-playing-track/</cref>
        /// </see>
        public SocialHttpResponse Seek(SpotifyPlayerSeekOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.DoHttpPutRequest("/v1/me/player/seek", options);
        }

        /// <summary>
        /// Sets the repeat mode for the user’s playback. Options are <see cref="SpotifyPlayerRepeatState.Track"/>, <see cref="SpotifyPlayerRepeatState.Context"/>, and <see cref="SpotifyPlayerRepeatState.Off"/>.
        /// </summary>
        /// <param name="state">The repeat state of the player.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/set-repeat-mode-on-users-playback/</cref>
        /// </see>
        public SocialHttpResponse SetRepeat(SpotifyPlayerRepeatState state) {
            return SetRepeat(new SpotifyPlayerSetRepeatOptions(state));
        }

        /// <summary>
        /// Sets the repeat mode for the user’s playback. Options are <see cref="SpotifyPlayerRepeatState.Track"/>, <see cref="SpotifyPlayerRepeatState.Context"/>, and <see cref="SpotifyPlayerRepeatState.Off"/>.
        /// </summary>
        /// <param name="state">The repeat state of the player.</param>
        /// <param name="deviceId">The ID of the device this command is targeting. If not supplied, the user’s currently active device is the target.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/set-repeat-mode-on-users-playback/</cref>
        /// </see>
        public SocialHttpResponse SetRepeat(SpotifyPlayerRepeatState state, string deviceId) {
            return SetRepeat(new SpotifyPlayerSetRepeatOptions(state, deviceId));
        }

        /// <summary>
        /// Sets the repeat mode for the user’s playback. Options are <see cref="SpotifyPlayerRepeatState.Track"/>, <see cref="SpotifyPlayerRepeatState.Context"/>, and <see cref="SpotifyPlayerRepeatState.Off"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/set-repeat-mode-on-users-playback/</cref>
        /// </see>
        public SocialHttpResponse SetRepeat(SpotifyPlayerSetRepeatOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.DoHttpPutRequest("/v1/me/player/repeat", options);
        }

        /// <summary>
        /// Toggles shuffle on or off for user’s playback.
        /// </summary>
        /// <param name="state">Whether shuffle should be turned on (<c>true</c>) or off (<c>false</c>).</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/toggle-shuffle-for-users-playback/</cref>
        /// </see>
        public SocialHttpResponse SetShuffle(bool state) {
            return SetShuffle(new SpotifyPlayerSetShuffleOptions(state));
        }

        /// <summary>
        /// Toggles shuffle on or off for user’s playback.
        /// </summary>
        /// <param name="state">Whether shuffle should be turned on (<c>true</c>) or off (<c>false</c>).</param>
        /// <param name="deviceId">The ID of the device this command is targeting. If not supplied, the user’s currently active device is the target.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/toggle-shuffle-for-users-playback/</cref>
        /// </see>
        public SocialHttpResponse SetShuffle(bool state, string deviceId) {
            return SetShuffle(new SpotifyPlayerSetShuffleOptions(state, deviceId));
        }

        /// <summary>
        /// Toggles shuffle on or off for user’s playback.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/toggle-shuffle-for-users-playback/</cref>
        /// </see>
        public SocialHttpResponse SetShuffle(SpotifyPlayerSetShuffleOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.DoHttpPutRequest("/v1/me/player/shuffle", options);
        }

        #endregion

    }

}