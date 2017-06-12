using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;

namespace Skybrud.Social.Spotify.Models {

    /// <summary>
    /// Class representing a basic object from the Spotify Web API derived from an instance of <see cref="JObject"/>.
    /// </summary>
    public class SpotifyObject : JsonObjectBase {

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SpotifyObject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyObject"/>.</returns>
        protected SpotifyObject(JObject obj) : base(obj) { }

    }

}