using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Spotify.Models.Common;

namespace Skybrud.Social.Spotify.Models.Artists {
    
    /// <summary>
    /// Class representing a Spotify artist.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.spotify.com/web-api/object-model/#artist-object-full</cref>
    /// </see>
    public class SpotifyArtist : SpotifyObject {

        #region Properties

        /// <summary>
        /// Gets a collection of external URLs of the artist.
        /// </summary>
        public SpotifyArtistUrlCollection ExternalUrls { get; }

        /// <summary>
        /// Gets information about the followers of the artist.
        /// </summary>
        public SpotifyFollowers Followers { get; }

        /// <summary>
        /// Gets a list of the genres the artist is associated with.
        /// </summary>
        public string[] Genres { get; }

        /// <summary>
        /// Gets a link to the Web API endpoint providing full details of the artist.
        /// </summary>
        public string Href { get; }

        /// <summary>
        /// Gets the Spotify ID of the artist.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets a collection of images of the artist in various sizes, widest first.
        /// </summary>
        public SpotifyImage[] Images { get; }

        /// <summary>
        /// Gets the name of the artist.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the popularity of the artist. The value will be between <c>0</c> and <c>100</c>, with
        /// <c>100</c> being the most popular. The artist's popularity is calculated from the popularity of all
        /// the artist's tracks.
        /// </summary>
        public int Popularity { get; }

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
        protected SpotifyArtist(JObject obj) : base(obj) {
            ExternalUrls = obj.GetObject("external_urls", SpotifyArtistUrlCollection.Parse);
            Followers = obj.GetObject("followers", SpotifyFollowers.Parse);
            Genres = obj.GetStringArray("genres");
            Href = obj.GetString("href");
            Id = obj.GetString("id");
            Images = obj.GetArrayItems("images", SpotifyImage.Parse);
            Name = obj.GetString("name");
            Popularity = obj.GetInt32("popularity");
            Type = obj.GetString("type");
            Uri = obj.GetString("uri");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SpotifyArtist"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyArtist"/>.</returns>
        public static SpotifyArtist Parse(JObject obj) {
            return obj == null ? null : new SpotifyArtist(obj); 
        }

        #endregion

    }

}