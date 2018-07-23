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
    public class SpotifyContext : SpotifyObject
    {

        #region Properties

        /// <summary>
        /// The uri of the context.
        /// </summary>
        public string Uri { get; private set; }

        /// <summary>
        /// The href of the context, or null if not available.
        /// </summary>
        public string Href { get; private set; }

        /// <summary>
        /// The external_urls of the context, or null if not available.
        /// </summary>
        public string ExternalUrls { get; private set; }

        /// <summary>
        ///The object type of the item’s context. Can be one of album , artist or playlist.
        /// </summary>
        public string Type { get; private set; }

        #endregion

        #region Constructors

        private SpotifyContext(JObject obj) : base(obj)
        {
            Uri = obj.GetString("uri");
            Href = obj.GetString("href");
            ExternalUrls = obj.GetString("external_urls");
            Type = obj.GetString("type");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SpotifyContext"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyContext"/>.</returns>
        public static SpotifyContext Parse(JObject obj)
        {
            return obj == null ? null : new SpotifyContext(obj);
        }

        #endregion

    }

}