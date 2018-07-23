using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Spotify.Models.Artists;

namespace Skybrud.Social.Spotify.Models.Track
{

    /// <summary>
    /// Class representing a Spotify artist.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.spotify.com/web-api/object-model/#user-object-private</cref>
    /// </see>
    public class SpotifyTrack : SpotifyObject
    {

        #region Properties

        /// <summary>
        /// The uri of the context.
        /// </summary>
        public SpotifyArtist[] Artists { get; private set; }

        /// <summary>
        /// The href of the context, or null if not available.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The external_urls of the context, or null if not available.
        /// </summary>
        public SpotifyArtistUrlCollection ExternalUrls { get; private set; }

        /// <summary>
        ///The object type of the item’s context. Can be one of album , artist or playlist.
        /// </summary>
        public string Uri { get; private set; }

        #endregion

        #region Constructors

        private SpotifyTrack(JObject obj) : base(obj)
        {
            Artists = obj.GetArrayItems("artists", SpotifyArtist.Parse);
            Name = obj.GetString("name");
            ExternalUrls = obj.GetObject("external_urls", SpotifyArtistUrlCollection.Parse);
            Uri = obj.GetString("uri");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SpotifyTrack"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyTrack"/>.</returns>
        public static SpotifyTrack Parse(JObject obj)
        {
            return obj == null ? null : new SpotifyTrack(obj);
        }

        #endregion

    }

}