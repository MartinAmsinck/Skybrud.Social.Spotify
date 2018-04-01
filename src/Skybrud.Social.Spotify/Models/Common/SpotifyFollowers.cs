using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Spotify.Models.Common {
    
    /// <summary>
    /// Class representing follower information a Spotify artist. 
    /// </summary>
    /// <see>
    ///     <cref>https://developer.spotify.com/web-api/object-model/#followers-object</cref>
    /// </see>
    public class SpotifyFollowers : SpotifyObject {

        #region Properties

        /// <summary>
        /// Gets a link to the Web API endpoint providing full details of the followers; <code>null</code> if not
        /// available. Please note that this will always be set to <code>null</code>, as the Web API does not support
        /// it at the moment.
        /// </summary>
        public string Href { get; }
        
        /// <summary>
        /// Gets the total number of followers.
        /// </summary>
        public int Total { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        protected SpotifyFollowers(JObject obj) : base(obj) {
            Href = obj.GetString("href");
            Total = obj.GetInt32("total");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SpotifyFollowers"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyFollowers"/>.</returns>
        public static SpotifyFollowers Parse(JObject obj) {
            return obj == null ? null : new SpotifyFollowers(obj); 
        }

        #endregion

    }

}