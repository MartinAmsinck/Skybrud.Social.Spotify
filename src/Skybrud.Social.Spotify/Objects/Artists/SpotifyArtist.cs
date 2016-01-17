using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;
using Skybrud.Social.Spotify.Objects.Common;

namespace Skybrud.Social.Spotify.Objects.Artists {
    
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
        public SpotifyArtistUrlCollection ExternalUrls { get; private set; }

        /// <summary>
        /// Gets information about the followers of the artist.
        /// </summary>
        public SpotifyFollowers Followers { get; private set; }

        /// <summary>
        /// Gets a list of the genres the artist is associated with.
        /// </summary>
        public string[] Genres { get; private set; }

        /// <summary>
        /// Gets a link to the Web API endpoint providing full details of the artist.
        /// </summary>
        public string Href { get; private set; }

        /// <summary>
        /// Gets the Spotify ID of the artist.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets a collection of images of the artist in various sizes, widest first.
        /// </summary>
        public SpotifyImage[] Images { get; private set; }

        /// <summary>
        /// Gets the name of the artist.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the popularity of the artist. The value will be between <code>0</code> and <code>100</code>, with
        /// <code>100</code> being the most popular. The artist's popularity is calculated from the popularity of all
        /// the artist's tracks.
        /// </summary>
        public int Popularity { get; private set; }

        /// <summary>
        /// Gets the type of the Spotify object. Always <code>artist</code>.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Gets the URI of the artist.
        /// </summary>
        public string Uri { get; private set; }

        #endregion

        #region Constructors

        private SpotifyArtist(JObject obj) : base(obj) {
            ExternalUrls = obj.GetObject("external_urls", SpotifyArtistUrlCollection.Parse);
            Followers = obj.GetObject("followers", SpotifyFollowers.Parse);
            Genres = obj.GetStringArray("genres");
            Href = obj.GetString("href");
            Id = obj.GetString("id");
            Images = obj.GetArray("images", SpotifyImage.Parse);
            Name = obj.GetString("name");
            Popularity = obj.GetInt32("popularity");
            Type = obj.GetString("type");
            Uri = obj.GetString("uri");
        }

        #endregion

        #region Static methods

        public static SpotifyArtist Parse(JObject obj) {
            return obj == null ? null : new SpotifyArtist(obj); 
        }

        #endregion

    }

}