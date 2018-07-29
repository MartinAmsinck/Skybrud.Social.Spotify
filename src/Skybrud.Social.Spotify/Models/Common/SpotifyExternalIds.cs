using Newtonsoft.Json.Linq;

namespace Skybrud.Social.Spotify.Models.Common {

    /// <see>
    ///     <cref>https://developer.spotify.com/web-api/object-model/#external-id-object</cref>
    /// </see>
    public class SpotifyExternalIds : SpotifyDictionary {

        #region Properties
        

        #endregion

        #region Constructors

        private SpotifyExternalIds(JObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SpotifyExternalIds"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyExternalIds"/>.</returns>
        public static SpotifyExternalIds Parse(JObject obj) {
            return obj == null ? null : new SpotifyExternalIds(obj);
        }

        #endregion

    }

}