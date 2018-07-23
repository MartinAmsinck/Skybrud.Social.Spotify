using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Spotify.Models.Artists;
using Skybrud.Social.Spotify.Models.Common;
using Skybrud.Social.Spotify.Models.Track;

namespace Skybrud.Social.Spotify.Models.Player
{

    /// <summary>
    /// Class representing a Spotify artist.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.spotify.com/web-api/object-model/#user-object-private</cref>
    /// </see>
    public class SpotifyPlayer : SpotifyObject
    {

        #region Properties

        /// <summary>
        /// The device that is currently active
        /// </summary>
        public SpotifyDevice Device { get; private set; }

        /// <summary>
        /// off, track, context
        /// </summary>
        public string RepeatState { get; private set; }

        /// <summary>
        /// If shuffle is on or off
        /// </summary>
        public string ShuffleState { get; private set; }

        /// <summary>
        /// A Context Object. Can be null.
        /// </summary>
        public SpotifyContext Context { get; private set; }

        /// <summary>
        /// Unix Millisecond Timestamp when data was fetched
        /// </summary>
        public Int64 TimeStamp { get; private set; }

        /// <summary>
        /// Progress into the currently playing track. Can be null.
        /// </summary>
        public int? ProgressMs { get; private set; }

        /// <summary>
        /// If something is currently playing.
        /// </summary>
        public bool IsPlaying { get; private set; }

        /// <summary>
        /// The currently playing track. Can be null.
        /// </summary>
        public SpotifyTrack Item { get; private set; }
        #endregion

        #region Constructors

        private SpotifyPlayer(JObject obj) : base(obj)
        {
            //Device = obj.GetObject("device", SpotifyDevice.Parse);
            //RepeatState = obj.GetString("repeat_state");
            //ShuffleState = obj.GetString("shuffle_state");
            Context = obj.GetObject("context", SpotifyContext.Parse);
            TimeStamp = obj.GetInt64("timestamp");
            ProgressMs = int.Parse(obj.GetString("progress_ms"));
            IsPlaying = bool.Parse(obj.GetString("is_playing"));
            Item = obj.GetObject("item",SpotifyTrack.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SpotifyPlayer"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyPlayer"/>.</returns>
        public static SpotifyPlayer Parse(JObject obj)
        {
            return obj == null ? null : new SpotifyPlayer(obj);
        }

        #endregion

    }

}