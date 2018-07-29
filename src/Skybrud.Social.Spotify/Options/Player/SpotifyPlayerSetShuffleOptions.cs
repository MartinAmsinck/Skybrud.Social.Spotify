using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.Spotify.Options.Player {

    /// <summary>
    /// Class with options for changing the repeat shuffle of a Spotify player.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/toggle-shuffle-for-users-playback/</cref>
    /// </see>
    public class SpotifyPlayerSetShuffleOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets whether shuffle should be turned on (<c>true</c>) or off (<c>false</c>).
        /// </summary>
        public bool State { get; set; }

        /// <summary>
        /// Gets or sets the ID of the device this command is targeting. If not supplied, the user’s currently active device is the target.
        /// </summary>
        public string DeviceId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public SpotifyPlayerSetShuffleOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="state"/>.
        /// </summary>
        /// <param name="state">Whether shuffle should be turned on (<c>true</c>) or off (<c>false</c>).</param>
        public SpotifyPlayerSetShuffleOptions(bool state) {
            State = state;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="state"/>.
        /// </summary>
        /// <param name="state">Whether shuffle should be turned on (<c>true</c>) or off (<c>false</c>).</param>
        /// <param name="deviceId">The ID of the device this command is targeting. If not supplied, the user’s currently active device is the target.</param>
        public SpotifyPlayerSetShuffleOptions(bool state, string deviceId) {
            State = state;
            DeviceId = deviceId;
        }

        #endregion

        #region Member methods

        public IHttpQueryString GetQueryString() {
            IHttpQueryString query = new SocialHttpQueryString();
            query.Add("state", State ? "true" : "false");
            if (!String.IsNullOrWhiteSpace(DeviceId)) query.Add("device_id", DeviceId);
            return query;
        }

        #endregion

    }

}