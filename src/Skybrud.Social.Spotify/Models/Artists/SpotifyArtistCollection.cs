using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Spotify.Models.Artists {

    public class SpotifyArtistCollection : SpotifyObject {

        #region Properties

        /// <summary>
        /// Gets an array of artists.
        /// </summary>
        public SpotifyArtist[] Artists { get; private set; }

        #endregion

        #region Constructors

        private SpotifyArtistCollection(JObject obj) : base(obj) {
            Artists = obj.GetArrayItems("artists", SpotifyArtist.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SpotifyArtistCollection"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyArtistCollection"/>.</returns>
        public static SpotifyArtistCollection Parse(JObject obj) {
            return obj == null ? null : new SpotifyArtistCollection(obj); 
        }

        #endregion

    }

}