using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Spotify.Models.Artists;
using Skybrud.Social.Spotify.Models.Common;

namespace Skybrud.Social.Spotify.Models.Player
{

    /// <summary>
    /// Class representing a Spotify artist.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.spotify.com/web-api/object-model/#user-object-private</cref>
    /// </see>
    public class SpotifyDevice : SpotifyObject
    {

        #region Properties

        /// <summary>
        /// The device ID. This may be null.

        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// If this device is the currently active device.
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// Whether controlling this device is restricted. 
        /// At present if this is “true” then no Web API
        /// commands will be accepted by this device.
        /// </summary>
        public bool IsRestricted { get; private set; }

        /// <summary>
        /// The name of the device.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        ///Device type, such as “Computer”, “Smartphone” or “Speaker”.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// The current volume in percent. This may be null.
        /// </summary>
        public int? VolumePercent { get; private set; }
        #endregion

        #region Constructors

        private SpotifyDevice(JObject obj) : base(obj)
        {
            Id = obj.GetString("id");
            IsActive = bool.Parse(obj.GetString("is_active"));
            IsRestricted = bool.Parse(obj.GetString("is_restricted"));
            Name = obj.GetString("name");
            Type = obj.GetString("type");
            VolumePercent = int.Parse(obj.GetString("volume_percent"));
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SpotifyDevice"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyDevice"/>.</returns>
        public static SpotifyDevice Parse(JObject obj)
        {
            return obj == null ? null : new SpotifyDevice(obj);
        }

        #endregion

    }

}