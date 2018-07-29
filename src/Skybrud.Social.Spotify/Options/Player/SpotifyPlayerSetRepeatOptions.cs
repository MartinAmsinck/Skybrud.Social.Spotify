using System;
using Skybrud.Essentials.Strings;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.Spotify.Options.Player {
    
    /// <summary>
    /// Class with options for changing the repeat state of a Spotify player.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/set-repeat-mode-on-users-playback/</cref>
    /// </see>
    public class SpotifyPlayerSetRepeatOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the repeat state of the player.
        /// </summary>
        public SpotifyPlayerRepeatState State { get; set; }

        /// <summary>
        /// Gets or sets the ID of the device this command is targeting. If not supplied, the user’s currently active device is the target.
        /// </summary>
        public string DeviceId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public SpotifyPlayerSetRepeatOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="state"/>.
        /// </summary>
        /// <param name="state">The repeat state of the player.</param>
        public SpotifyPlayerSetRepeatOptions(SpotifyPlayerRepeatState state) {
            State = state;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="state"/>.
        /// </summary>
        /// <param name="state">The repeat state of the player.</param>
        /// <param name="deviceId">The ID of the device this command is targeting. If not supplied, the user’s currently active device is the target.</param>
        public SpotifyPlayerSetRepeatOptions(SpotifyPlayerRepeatState state, string deviceId) {
            State = state;
            DeviceId = deviceId;
        }

        #endregion

        #region Member methods

        public IHttpQueryString GetQueryString() {
            IHttpQueryString query = new SocialHttpQueryString();
            query.Add("state", StringUtils.ToLower(State));
            if (!String.IsNullOrWhiteSpace(DeviceId)) query.Add("device_id", DeviceId);
            return query;
        }

        #endregion

    }

}