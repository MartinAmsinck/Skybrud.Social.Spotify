using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Spotify.Models.Common {

    /// <see>
    ///     <cref>https://developer.spotify.com/web-api/object-model/#external-url-object</cref>
    /// </see>
    public class SpotifyExternalUrls : SpotifyDictionary {

        #region Properties
        
        /// <summary>
        /// Gets the Spotify Web URL of the parent object. 
        /// </summary>
        public string Spotify { get; private set; }

        #endregion

        #region Constructors

        private SpotifyExternalUrls(JObject obj) : base(obj) {
            Spotify = obj.GetString("spotify");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SpotifyExternalUrls"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyExternalUrls"/>.</returns>
        public static SpotifyExternalUrls Parse(JObject obj) {
            return obj == null ? null : new SpotifyExternalUrls(obj);
        }

        #endregion

    }

}