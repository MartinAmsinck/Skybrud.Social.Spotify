using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.Spotify.Options.Player {

    /// <see>
    ///     <cref>https://developer.spotify.com/documentation/web-api/reference/player/seek-to-position-in-currently-playing-track/</cref>
    /// </see>
    public class SpotifyPlayerSeekOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the position to seek to. Must be a positive number. Passing in a position that is greater than the length of the track will cause the player to start playing the next song.
        /// </summary>
        public TimeSpan Position { get; set; }

        /// <summary>
        /// Gets or sets the ID of the device this command is targeting. If not supplied, the user’s currently active device is the target.
        /// </summary>
        public string DeviceId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public SpotifyPlayerSeekOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="position"/>.
        /// </summary>
        /// <param name="position">The position to seek to. Must be a positive number. Passing in a position that is greater than the length of the track will cause the player to start playing the next song.</param>
        public SpotifyPlayerSeekOptions(TimeSpan position) {
            Position = position;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="position"/>.
        /// </summary>
        /// <param name="position">The position to seek to. Must be a positive number. Passing in a position that is greater than the length of the track will cause the player to start playing the next song.</param>
        /// <param name="deviceId">The ID of the device this command is targeting. If not supplied, the user’s currently active device is the target.</param>
        public SpotifyPlayerSeekOptions(TimeSpan position, string deviceId) {
            Position = position;
            DeviceId = deviceId;
        }

        #endregion

        #region Member methods

        public IHttpQueryString GetQueryString() {
            IHttpQueryString query = new SocialHttpQueryString();
            query.Add("position", Position.TotalMilliseconds);
            if (!String.IsNullOrWhiteSpace(DeviceId)) query.Add("device_id", DeviceId);
            return query;
        }

        #endregion

    }

}