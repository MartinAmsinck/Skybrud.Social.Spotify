using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Spotify.Models.Artists;
using Skybrud.Social.Spotify.Models.Common;

namespace Skybrud.Social.Spotify.Models.UserProfile
{

    /// <summary>
    /// Class representing a Spotify artist.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.spotify.com/web-api/object-model/#user-object-private</cref>
    /// </see>
    public class SpotifyUserProfile : SpotifyObject
    {

        #region Properties

        /// <summary>
        /// The user's date-of-birth. 
        /// This field is only available when the current user has granted access to the <code>user-read-birthdate</code> scope.
        /// </summary>
        public DateTime Birthdate { get; private set; }

        /// <summary>
        /// The country of the user, as set in the user's account profile. An ISO 3166-1 alpha-2 country code. 
        /// This field is only available when the current user has granted access to the <code>user-read-private</code> scope.
        /// </summary>
        public string Country { get; private set; }

        /// <summary>
        /// The name displayed on the user's profile. null if not available.
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        /// The user's email address, as entered by the user when creating their account.
        /// Important! This email address is unverified; there is no proof that it actually belongs to the user.
        /// This field is only available when the current user has granted access to the <code>user-read-email</code> scope.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Gets a collection of external URLs of the artist.
        /// </summary>
        public SpotifyArtistUrlCollection ExternalUrls { get; private set; }

        /// <summary>
        /// Gets information about the followers of the artist.
        /// </summary>
        public SpotifyFollowers Followers { get; private set; }

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
        /// The user's Spotify subscription level: "premium", "free", etc. (The subscription level "open" can be considered the same as "free".) 
        /// </summary>
        public string Product { get; private set; }

        /// <summary>
        /// Gets the popularity of the artist. The value will be between <code>0</code> and <code>100</code>, with
        /// <code>100</code> being the most popular. The artist's popularity is calculated from the popularity of all
        /// the artist's tracks.
        /// </summary>
        public int Popularity { get; private set; }

        /// <summary>
        /// Gets the type of the Spotify object. Always <code>user</code>.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Gets the URI of the artist.
        /// </summary>
        public string Uri { get; private set; }

        #endregion

        #region Constructors

        private SpotifyUserProfile(JObject obj) : base(obj)
        {
            Birthdate = obj.GetDateTime("birthdate");
            Country = obj.GetString("country");
            DisplayName = obj.GetString("display_name");
            Email = obj.GetString("email");
            ExternalUrls = obj.GetObject("external_urls", SpotifyArtistUrlCollection.Parse);
            Followers = obj.GetObject("followers", SpotifyFollowers.Parse);
            Href = obj.GetString("href");
            Id = obj.GetString("id");
            Images = obj.GetArrayItems("images", SpotifyImage.Parse);
            Product = obj.GetString("product");
            Type = obj.GetString("type");
            Uri = obj.GetString("uri");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SpotifyUserProfile"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyUserProfile"/>.</returns>
        public static SpotifyUserProfile Parse(JObject obj)
        {
            return obj == null ? null : new SpotifyUserProfile(obj);
        }

        #endregion

    }

}