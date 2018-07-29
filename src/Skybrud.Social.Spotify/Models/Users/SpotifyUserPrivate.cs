using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.Spotify.Scopes;

namespace Skybrud.Social.Spotify.Models.Users {

    /// <summary>
    /// Class representing the private profile of a Spotify user.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.spotify.com/documentation/web-api/reference/object-model/#user-object-private</cref>
    /// </see>
    public class SpotifyUserPrivate : SpotifyUser {

        #region Properties

        /// <summary>
        /// Gets the birthdate of the user. Requires the <see cref="SpotifyScopes.UserReadBirthdate"/> scope.
        /// </summary>
        public EssentialsDateTime Birthdate { get; }

        /// <summary>
        /// Gets whether the <see cref="Birthdate"/> property has a value.
        /// </summary>
        public bool HasBirthdate => Birthdate != null;

        /// <summary>
        /// Gets the ISO 3166-1 alpha-2 country code representing the country of the user. Requires the <see cref="SpotifyScopes.UserReadPrivate"/> scope.
        /// </summary>
        public string Country { get; }

        /// <summary>
        /// Gets whether the <see cref="Country"/> property has a value.
        /// </summary>
        public bool HasCountry => !String.IsNullOrWhiteSpace(Country);

        /// <summary>
        /// Gets the email address of the user. Requires the <see cref="SpotifyScopes.UserReadEmail"/> scope.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Gets whether the <see cref="Email"/> property has a value.
        /// </summary>
        public bool HasEmail => !String.IsNullOrWhiteSpace(Email);

        // TODO: Add support for the "product" property

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        protected SpotifyUserPrivate(JObject obj) : base(obj) {
            Birthdate = obj.GetString("birthdate", EssentialsDateTime.Parse);
            Country = obj.GetString("country");
            Email = obj.GetString("email");
            // TODO: Add support for the "product" property
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SpotifyUserPrivate"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyUserPrivate"/>.</returns>
        public new static SpotifyUserPrivate Parse(JObject obj) {
            return obj == null ? null : new SpotifyUserPrivate(obj); 
        }

        #endregion

    }

}