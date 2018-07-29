using System;
using Skybrud.Social.Spotify.Endpoints.Raw;
using Skybrud.Social.Spotify.Options.Player;
using Skybrud.Social.Spotify.Responses;
using Skybrud.Social.Spotify.Responses.Common;
using Skybrud.Social.Spotify.Responses.Player;
using Skybrud.Social.Spotify.Scopes;

namespace Skybrud.Social.Spotify.Endpoints {

    /// <summary>
    /// Class representing the implementation of the player endpoint.
    /// </summary>
    public class SpotifyPlayerEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Spotify service.
        /// </summary>
        public SpotifyService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public SpotifyPlayerRawEndpoint Raw => Service.Client.Player;

        #endregion

        #region Constructors

        internal SpotifyPlayerEndpoint(SpotifyService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        // TODO: Implement the "GetPlayer" method

        /// <summary>
        /// Get detailed profile information about the current user (including the current user’s username).
        /// </summary>
        /// <returns>An instance of <see cref="SpotifyGetPlayerResponse"/> representing the response.</returns>
        public SpotifyGetPlayerResponse GetCurrentlyPlaying() {
            return SpotifyGetPlayerResponse.ParseResponse(Raw.GetCurrentlyPlaying());
        }

        // TODO: Implement the "GetRecentlyPlayed" methods

        /// <summary>
        /// Starts or resumes the playback of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="SpotifyResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/start-a-users-playback/</cref>
        /// </see>
        public SpotifyResponse Play() {
            return SpotifyNoContentResponse.ParseResponse(Raw.Play());
        }

        /// <summary>
        /// Pauses the playback of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="SpotifyResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/pause-a-users-playback/</cref>
        /// </see>
        public SpotifyResponse Pause() {
            return SpotifyNoContentResponse.ParseResponse(Raw.Pause());
        }

        /// <summary>
        /// Changes the volume of the current device of the authenticated user. Requires the <see cref="SpotifyScopes.UserModifyPlaybackState"/> scope.
        /// </summary>
        /// <param name="volume">The volume to set. Must be a value from <c>0</c> to <c>100</c> inclusive.</param>
        /// <returns>An instance of <see cref="SpotifyResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/set-volume-for-users-playback/</cref>
        /// </see>
        public SpotifyResponse SetVolume(int volume) {
            return SpotifyNoContentResponse.ParseResponse(Raw.SetVolume(volume));
        }

        /// <summary>
        /// Changes the volume of the device with the specified <paramref name="deviceId"/>. Requires the <see cref="SpotifyScopes.UserModifyPlaybackState"/> scope.
        /// </summary>
        /// <param name="volume">The volume to set. Must be a value from <c>0</c> to <c>100</c> inclusive.</param>
        /// <param name="deviceId">The ID of the device this command is targeting. If not supplied, the user’s currently active device is the target.</param>
        /// <returns>An instance of <see cref="SpotifyResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/set-volume-for-users-playback/</cref>
        /// </see>
        public SpotifyResponse SetVolume(int volume, string deviceId) {
            return SpotifyNoContentResponse.ParseResponse(Raw.SetVolume(volume, deviceId));
        }


        /// <summary>
        /// Skips the user's playback to the next track.
        /// </summary>
        /// <param name="deviceId">The ID of the device this command is targeting. If not supplied, the user’s currently active device is the target.</param>
        /// <returns>An instance of <see cref="SpotifyResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/skip-users-playback-to-next-track/</cref>
        /// </see>
        public SpotifyResponse Next(string deviceId) {
            return SpotifyNoContentResponse.ParseResponse(Raw.Next(deviceId));
        }

        /// <summary>
        /// Skips the user's playback to the previous track.
        /// </summary>
        /// <param name="deviceId">The ID of the device this command is targeting. If not supplied, the user’s currently active device is the target.</param>
        /// <returns>An instance of <see cref="SpotifyResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/skip-users-playback-to-previous-track/</cref>
        /// </see>
        public SpotifyResponse Previous(string deviceId) {
            return SpotifyNoContentResponse.ParseResponse(Raw.Previous(deviceId));
        }

        /// <summary>
        /// Seeks to the given position in the user’s currently playing track.
        /// </summary>
        /// <param name="position">The position to seek to. Must be a positive number. Passing in a position that is greater than the length of the track will cause the player to start playing the next song.</param>
        /// <returns>An instance of <see cref="SpotifyResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/seek-to-position-in-currently-playing-track/</cref>
        /// </see>
        public SpotifyResponse Seek(TimeSpan position) {
            return SpotifyNoContentResponse.ParseResponse(Raw.Seek(position));
        }

        /// <summary>
        /// Seeks to the given position in the user’s currently playing track.
        /// </summary>
        /// <param name="position">The position to seek to. Must be a positive number. Passing in a position that is greater than the length of the track will cause the player to start playing the next song.</param>
        /// <param name="deviceId">The ID of the device this command is targeting. If not supplied, the user’s currently active device is the target.</param>
        /// <returns>An instance of <see cref="SpotifyResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/seek-to-position-in-currently-playing-track/</cref>
        /// </see>
        public SpotifyResponse Seek(TimeSpan position, string deviceId) {
            return SpotifyNoContentResponse.ParseResponse(Raw.Seek(position, deviceId));
        }

        /// <summary>
        /// Seeks to the given position in the user’s currently playing track.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="SpotifyResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/seek-to-position-in-currently-playing-track/</cref>
        /// </see>
        public SpotifyResponse Seek(SpotifyPlayerSeekOptions options) {
            return SpotifyNoContentResponse.ParseResponse(Raw.Seek(options));
        }

        /// <summary>
        /// Sets the repeat mode for the user’s playback. Options are <see cref="SpotifyPlayerRepeatState.Track"/>, <see cref="SpotifyPlayerRepeatState.Context"/>, and <see cref="SpotifyPlayerRepeatState.Off"/>.
        /// </summary>
        /// <param name="state">The repeat state of the player.</param>
        /// <returns>An instance of <see cref="SpotifyResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/set-repeat-mode-on-users-playback/</cref>
        /// </see>
        public SpotifyResponse SetRepeat(SpotifyPlayerRepeatState state) {
            return SpotifyNoContentResponse.ParseResponse(Raw.SetRepeat(state));
        }

        /// <summary>
        /// Sets the repeat mode for the user’s playback. Options are <see cref="SpotifyPlayerRepeatState.Track"/>, <see cref="SpotifyPlayerRepeatState.Context"/>, and <see cref="SpotifyPlayerRepeatState.Off"/>.
        /// </summary>
        /// <param name="state">The repeat state of the player.</param>
        /// <param name="deviceId">The ID of the device this command is targeting. If not supplied, the user’s currently active device is the target.</param>
        /// <returns>An instance of <see cref="SpotifyResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/set-repeat-mode-on-users-playback/</cref>
        /// </see>
        public SpotifyResponse SetRepeat(SpotifyPlayerRepeatState state, string deviceId) {
            return SpotifyNoContentResponse.ParseResponse(Raw.SetRepeat(state, deviceId));
        }

        /// <summary>
        /// Sets the repeat mode for the user’s playback. Options are <see cref="SpotifyPlayerRepeatState.Track"/>, <see cref="SpotifyPlayerRepeatState.Context"/>, and <see cref="SpotifyPlayerRepeatState.Off"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="SpotifyResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/set-repeat-mode-on-users-playback/</cref>
        /// </see>
        public SpotifyResponse SetRepeat(SpotifyPlayerSetRepeatOptions options) {
            return SpotifyNoContentResponse.ParseResponse(Raw.SetRepeat(options));
        }

        /// <summary>
        /// Toggles shuffle on or off for user’s playback.
        /// </summary>
        /// <param name="state">Whether shuffle should be turned on (<c>true</c>) or off (<c>false</c>).</param>
        /// <returns>An instance of <see cref="SpotifyResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/toggle-shuffle-for-users-playback/</cref>
        /// </see>
        public SpotifyResponse SetShuffle(bool state) {
            return SpotifyNoContentResponse.ParseResponse(Raw.SetShuffle(state));
        }

        /// <summary>
        /// Toggles shuffle on or off for user’s playback.
        /// </summary>
        /// <param name="state">Whether shuffle should be turned on (<c>true</c>) or off (<c>false</c>).</param>
        /// <param name="deviceId">The ID of the device this command is targeting. If not supplied, the user’s currently active device is the target.</param>
        /// <returns>An instance of <see cref="SpotifyResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/toggle-shuffle-for-users-playback/</cref>
        /// </see>
        public SpotifyResponse SetShuffle(bool state, string deviceId) {
            return SpotifyNoContentResponse.ParseResponse(Raw.SetShuffle(state, deviceId));
        }

        /// <summary>
        /// Toggles shuffle on or off for user’s playback.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="SpotifyResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/toggle-shuffle-for-users-playback/</cref>
        /// </see>
        public SpotifyResponse SetShuffle(SpotifyPlayerSetShuffleOptions options) {
            return SpotifyNoContentResponse.ParseResponse(Raw.SetShuffle(options));
        }

        #endregion

    }

}