using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Spotify.Models.Common {
    
    /// <summary>
    /// Class representing copyright information of an album.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.spotify.com/web-api/object-model/#copyright-object</cref>
    /// </see>
    public class SpotifyCopyright : SpotifyObject {

        #region Properties
        
        /// <summary>
        /// Gets the copyright text for an album.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Gets the type of copyright: <c>C</c> = the copyright, <c>P</c> = the sound recording (performance) copyright.
        /// </summary>
        public string Type { get; private set; }

        #endregion

        #region Constructors

        private SpotifyCopyright(JObject obj) : base(obj) {
            Text = obj.GetString("text");
            Type = obj.GetString("type");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SpotifyCopyright"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyCopyright"/>.</returns>
        public static SpotifyCopyright Parse(JObject obj) {
            return obj == null ? null : new SpotifyCopyright(obj); 
        }

        #endregion

    }

}