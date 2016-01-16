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
        public string Name { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new scope based on the specified <code>name</code> a.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        public SpotifyScope(string name) {
            Name = name;
        }

        #endregion

        #region Member methods

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
        /// Attempts to get a scope with the specified <code>name</code>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <returns>Gets a scope matching the specified <code>name</code>, or <code>null</code> if not found-</returns>
        public static SpotifyScope GetScope(string name) {
            SpotifyScope scope;
            return Scopes.TryGetValue(name, out scope) ? scope : null;
        }

        /// <summary>
        /// Gets whether the scope is a known scope.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <returns>Returns <code>true</code> if the specified <code>name</code> matches a known
        /// scope, otherwise <code>false</code>.</returns>
        public static bool ScopeExists(string name) {
            return Scopes.ContainsKey(name);
        }

        #endregion

        #region Operators

        /// <summary>
        /// Adding two instances of <code>SpotifyScope</code> will result in a
        /// <code>SpotifyScopeCollection</code> containing both scopes.
        /// </summary>
        /// <param name="left">The left scope.</param>
        /// <param name="right">The right scope.</param>
        public static SpotifyScopeCollection operator +(SpotifyScope left, SpotifyScope right) {
            return new SpotifyScopeCollection(left, right);
        }

        #endregion

    }

}