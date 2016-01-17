using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.Spotify.Objects.Common {
    
    /// <summary>
    /// Class representing an image of a Sptofy object (eg. an artist).
    /// </summary>
    /// <see>
    ///     <cref>https://developer.spotify.com/web-api/object-model/#image-object</cref>
    /// </see>
    public class SpotifyImage : SpotifyObject {

        #region Properties
        
        /// <summary>
        /// Gets the height of the image.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// The source URL of the image. 
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// Gets the width of the image.
        /// </summary>
        public int Width { get; private set; }

        #endregion

        #region Constructors

        private SpotifyImage(JObject obj) : base(obj) {
            Height = obj.GetInt32("height");
            Url = obj.GetString("url");
            Width = obj.GetInt32("width");
        }

        #endregion

        #region Static methods

        public static SpotifyImage Parse(JObject obj) {
            return obj == null ? null : new SpotifyImage(obj); 
        }

        #endregion

    }

}