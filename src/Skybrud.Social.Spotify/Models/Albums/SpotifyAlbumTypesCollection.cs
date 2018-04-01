using System;
using System.Collections.Generic;
using System.Linq;
using Skybrud.Essentials.Strings;

namespace Skybrud.Social.Spotify.Models.Albums {

    /// <summary>
    /// Class representing a collection of album types.
    /// </summary>
    public class SpotifyAlbumTypesCollection {

        #region Private fields

        private readonly List<SpotifyAlbumType> _list = new List<SpotifyAlbumType>(); 

        #endregion

        #region Properties

        /// <summary>
        /// Gets the amount of album types in the collection.
        /// </summary>
        public int Count => _list.Count;

        /// <summary>
        /// Gets an array of the album types contained in the collection.
        /// </summary>
        public SpotifyAlbumType[] Types => _list.ToArray();

        /// <summary>
        /// Gets whether the collection is empty.
        /// </summary>
        public bool IsEmpty => _list.Count == 0;

        #endregion

        #region Member methods

        /// <summary>
        /// Adds the specified <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The album type to be added.</param>
        public void Add(SpotifyAlbumType type) {
            _list.Add(type);
        }

        /// <summary>
        /// Removes the specified <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The album type to be removed.</param>
        public void Remove(SpotifyAlbumType type) {
            _list.Remove(type);
        }

        /// <summary>
        /// Gets whether the collection contains the specified <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The album type.</param>
        /// <returns><c>true</c> if the collection contains <paramref name="type"/>, otherwise <c>false</c>.</returns>
        public bool Contains(SpotifyAlbumType type) {
            return _list.Contains(type);
        }

        /// <summary>
        /// Returns a string representation of the collection.
        /// </summary>
        /// <returns>An instance of <see cref="System.String"/> representing the collection.</returns>
        public override string ToString() {
            return String.Join(",", from type in _list select StringUtils.ToUnderscore(type));
        }

        #endregion

    }

}