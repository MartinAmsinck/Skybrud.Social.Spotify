using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Spotify.Models.Albums {

    /// <summary>
    /// Class representing a collection of <see cref="SpotifyAlbum"/>.
    /// </summary>
    public class SpotifyAlbumsCollection : SpotifyObject, IEnumerable<SpotifyAlbum> {

        #region Properties

        /// <summary>
        /// Gets an array of the albums in the collection.
        /// </summary>
        public SpotifyAlbum[] Albums { get; }

        /// <summary>
        /// Gets the length of the collection.
        /// </summary>
        public int Length => Albums.Length;

        /// <summary>
        /// Gets the album at the specified <paramref name="index"/>.
        /// </summary>
        /// <param name="index">The index of the track.</param>
        /// <returns>An instance of <see cref="SpotifyAlbum"/>.</returns>
        public SpotifyAlbum this[int index] => Albums[index];

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        protected SpotifyAlbumsCollection(JObject obj) : base(obj) {
            Albums = obj.GetArrayItems("albums", SpotifyAlbum.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SpotifyAlbumsCollection"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyAlbumsCollection"/>.</returns>
        public static SpotifyAlbumsCollection Parse(JObject obj) {
            return obj == null ? null : new SpotifyAlbumsCollection(obj); 
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<SpotifyAlbum> GetEnumerator() {
            return ((IEnumerable<SpotifyAlbum>)Albums).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

    }

}