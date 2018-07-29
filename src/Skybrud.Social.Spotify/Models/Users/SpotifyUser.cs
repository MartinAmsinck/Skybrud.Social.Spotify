using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.Spotify.Models.Common;

namespace Skybrud.Social.Spotify.Models.Users {

    /// <summary>
    /// Class representing the public profile of a Spotify user.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.spotify.com/web-api/object-model/#user-object-public</cref>
    /// </see>
    public class SpotifyUser : SpotifyObject {

        #region Properties

        /// <summary>
        /// Gets the name displayed on the user's profile. <c>null</c> if not available.
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// Gets a collection of known public external URLs for this user.
        /// </summary>
        public SpotifyExternalUrls ExternalUrls { get; }

        /// <summary>
        /// Gets information about the followers of this user.
        /// </summary>
        public SpotifyFollowers Followers { get; }
        
        /// <summary>
        /// Gets a link to the Web API endpoint for this user.
        /// </summary>
        public string Href { get; }
        
        /// <summary>
        /// Gets the Spotify user ID for this user. 
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the user's profile image.
        /// </summary>
        public SpotifyImage[] Images { get; }

        /// <summary>
        /// Gets the object type: <c>user</c>.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets the Spotify URI for this user.
        /// </summary>
        public string Uri { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        protected SpotifyUser(JObject obj) : base(obj) {
            DisplayName = obj.GetString("display_name");
            ExternalUrls = obj.GetObject("external_urls", SpotifyExternalUrls.Parse);
            Followers = obj.GetObject("followers", SpotifyFollowers.Parse);
            Href = obj.GetString("href");
            Id = obj.GetString("id");
            Images = obj.GetArrayItems("images", SpotifyImage.Parse);
            Type = obj.GetString("type");
            Uri = obj.GetString("uri");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SpotifyUser"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyUser"/>.</returns>
        public static SpotifyUser Parse(JObject obj) {
            return obj == null ? null : new SpotifyUser(obj); 
        }

        #endregion

    }

}