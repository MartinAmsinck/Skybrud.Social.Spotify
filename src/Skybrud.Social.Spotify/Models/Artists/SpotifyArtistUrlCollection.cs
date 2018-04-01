using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Spotify.Models.Artists {
    
    /// <summary>
    /// Class representing a URL collection of an artist.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.spotify.com/web-api/object-model/#external-url-object</cref>
    /// </see>
    public class SpotifyArtistUrlCollection : SpotifyObject {

        #region Properties

        /// <summary>
        /// Gets a Spotify URL of the artist.
        /// </summary>
        public string Spotify { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        protected SpotifyArtistUrlCollection(JObject obj) : base(obj) {
            Spotify = obj.GetString("spotify");
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SpotifyArtistUrlCollection"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyArtistUrlCollection"/>.</returns>
        public static SpotifyArtistUrlCollection Parse(JObject obj) {
            return obj == null ? null : new SpotifyArtistUrlCollection(obj); 
        }

        #endregion

    }

}