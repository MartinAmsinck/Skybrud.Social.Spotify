using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Spotify.Models.Artists {

    /// <summary>
    /// Class with simplified information about a Spotify artist.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.spotify.com/web-api/object-model/#artist-object-simplified</cref>
    /// </see>
    public class SpotifyArtistItem : SpotifyObject {

        #region Properties

        /// <summary>
        /// Gets a collection of external URLs of the artist.
        /// </summary>
        public SpotifyArtistUrlCollection ExternalUrls { get; }

        /// <summary>
        /// Gets a link to the Web API endpoint providing full details of the artist.
        /// </summary>
        public string Href { get; }

        /// <summary>
        /// Gets the Spotify ID of the artist.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the name of the artist.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the type of the Spotify object. Always <c>artist</c>.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets the URI of the artist.
        /// </summary>
        public string Uri { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        protected SpotifyArtistItem(JObject obj) : base(obj) {
            ExternalUrls = obj.GetObject("external_urls", SpotifyArtistUrlCollection.Parse);
            Href = obj.GetString("href");
            Id = obj.GetString("id");
            Name = obj.GetString("name");
            Type = obj.GetString("type");
            Uri = obj.GetString("uri");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SpotifyArtistItem"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyArtistItem"/>.</returns>
        public static SpotifyArtistItem Parse(JObject obj) {
            return obj == null ? null : new SpotifyArtistItem(obj); 
        }

        #endregion

    }

}