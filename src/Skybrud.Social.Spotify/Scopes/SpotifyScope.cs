using System.Collections.Generic;

namespace Skybrud.Social.Spotify.Scopes {

    /// <summary>
    /// Class representing a scope of the Spotify Web API.
    /// </summary>
    public class SpotifyScope {

        #region Private fields

        private static readonly Dictionary<string, SpotifyScope> Scopes = new Dictionary<string, SpotifyScope>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the name of the scope.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the description of the scope.
        /// </summary>
        public string Description { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new scope based on the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        public SpotifyScope(string name) {
            Name = name;
        }

        /// <summary>
        /// Initializes a new scope based on the specified <paramref name="name"/> and <paramref name="description"/>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <param name="description">The description of the scope.</param>
        public SpotifyScope(string name, string description) {
            Name = name;
            Description = description;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a string representation of the scope.
        /// </summary>
        /// <returns>An instance of <see cref="System.String"/> representing the scope.</returns>
        public override string ToString() {
            return Name;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Registers a scope in the internal dictionary.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        internal static SpotifyScope RegisterScope(string name) {
            SpotifyScope scope = new SpotifyScope(name);
            Scopes.Add(scope.Name, scope);
            return scope;
        }

        /// <summary>
        /// Attempts to get a scope with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <returns>Gets a scope matching the specified <paramref name="name"/>, or <c>null</c> if not found.</returns>
        public static SpotifyScope GetScope(string name) {
            SpotifyScope scope;
            return Scopes.TryGetValue(name, out scope) ? scope : null;
        }

        /// <summary>
        /// Gets whether the scope is a known scope.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <returns><c>true</c> if the specified <paramref name="name"/> matches a known scope, otherwise <c>false</c>.</returns>
        public static bool ScopeExists(string name) {
            return Scopes.ContainsKey(name);
        }

        #endregion

        #region Operators

        /// <summary>
        /// Adding two instances of <see cref="SpotifyScope"/> will result in a <see cref="SpotifyScopeCollection"/> containing both scopes.
        /// </summary>
        /// <param name="left">The left scope.</param>
        /// <param name="right">The right scope.</param>
        /// <returns>An instance of <see cref="SpotifyScopeCollection"/>.</returns>
        public static SpotifyScopeCollection operator +(SpotifyScope left, SpotifyScope right) {
            return new SpotifyScopeCollection(left, right);
        }

        #endregion

    }

}