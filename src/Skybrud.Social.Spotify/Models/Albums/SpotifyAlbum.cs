using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.Spotify.Models.Artists;
using Skybrud.Social.Spotify.Models.Common;
using Skybrud.Social.Spotify.Models.Tracks;

namespace Skybrud.Social.Spotify.Models.Albums {
    
    /// <summary>
    /// Class representing an image of a Spotify album.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.spotify.com/web-api/object-model/#album-object-full</cref>
    /// </see>
    public class SpotifyAlbum : SpotifyObject {

        #region Properties

        /// <summary>
        /// Gets the type of the album. Can be either <see cref="SpotifyAlbumType.Album"/>,
        /// <see cref="SpotifyAlbumType.Single"/> or <see cref="SpotifyAlbumType.Compilation"/>.
        /// </summary>
        public SpotifyAlbumType AlbumType { get; }

        /// <summary>
        /// Gets an array with the artists of the album.
        /// </summary>
        public SpotifyArtistItem[] Artists { get; }

        /// <summary>
        /// Gets the markets in which the album is available: ISO 3166-1 alpha-2 country codes. Note that an album is
        /// considered available in a market when at least 1 of its tracks is available in that market.
        /// </summary>
        public string[] AvailableMarkets { get; }

        /// <summary>
        /// Gets the copyright statements of the album.
        /// </summary>
        public SpotifyCopyright[] Copyrights { get; }

        /// <summary>
        /// Gets a collection of known external IDs for the album. 
        /// </summary>
        public SpotifyExternalIds ExternalIds { get; }

        /// <summary>
        /// Gets a collection of known external URLs for this album.
        /// </summary>
        public SpotifyExternalUrls ExternalUrls { get; }

        /// <summary>
        /// Gets a list of the genres used to classify the album. For example: <c>Prog Rock</c> or
        /// <c>Post-Grunge</c>. If not yet classified, the array is empty.
        /// </summary>
        public string[] Genres { get; }

        /// <summary>
        /// Gets a link to the Web API endpoint providing full details of the album.
        /// </summary>
        public string Href { get; }

        /// <summary>
        /// Gets the Spotify ID for the album.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the cover art for the album in various sizes, widest first.
        /// </summary>
        public SpotifyImage[] Images { get; }

        /// <summary>
        /// Gets the label for the album.
        /// </summary>
        public string Label { get; }

        /// <summary>
        /// Gets the name of the album. In case of an album takedown, the value may be an empty string.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the popularity of the album. The value will be between <c>0</c> and <c>100</c>, with
        /// <c>100</c> being the most popular. The popularity is calculated from the popularity of the album's
        /// individual tracks.
        /// </summary>
        public int Popularity  { get; }

        /// <summary>
        /// Gets the date the album was first released, for example <c>1981-12-15</c>. Depending on the
        /// precision, it might be shown as <c>1981</c> or <c>1981-12</c>.
        /// </summary>
        public EssentialsPartialDate ReleaseDate { get; }

        /// <summary>
        /// Gets the precision with which release_date value is known: <c>year</c>, <c>month</c>, or <c>day</c>.
        /// </summary>
        public string ReleaseDatePrecision { get; }

        /// <summary>
        /// Gets the tracks of the album.
        /// </summary>
        public SpotifyTracksCollection Tracks { get; }

        /// <summary>
        /// Gets the object type: <c>album</c>.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets the Spotify URI for the album.
        /// </summary>
        public string Uri { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        protected SpotifyAlbum(JObject obj) : base(obj) {
            AlbumType = obj.GetEnum<SpotifyAlbumType>("album_type");
            Artists = obj.GetArrayItems("artists", SpotifyArtistItem.Parse);
            AvailableMarkets = obj.GetStringArray("available_markets");
            Copyrights = obj.GetArrayItems("copyrights", SpotifyCopyright.Parse);
            ExternalIds = obj.GetObject("external_ids", SpotifyExternalIds.Parse);
            ExternalUrls = obj.GetObject("external_urls", SpotifyExternalUrls.Parse);
            Genres = obj.GetStringArray("genres");
            Href = obj.GetString("href");
            Id = obj.GetString("id");
            Images = obj.GetArrayItems("images", SpotifyImage.Parse);
            Label = obj.GetString("label");
            Name = obj.GetString("name");
            Popularity = obj.GetInt32("popularity");
            ReleaseDate = obj.GetString("release_date", EssentialsPartialDate.Parse);
            ReleaseDatePrecision = obj.GetString("release_date_precision");
            Tracks = obj.GetObject("tracks", SpotifyTracksCollection.Parse);
            Type = obj.GetString("type");
            Uri = obj.GetString("uri");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SpotifyAlbum"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyAlbum"/>.</returns>
        public static SpotifyAlbum Parse(JObject obj) {
            return obj == null ? null : new SpotifyAlbum(obj); 
        }

        #endregion

    }

}