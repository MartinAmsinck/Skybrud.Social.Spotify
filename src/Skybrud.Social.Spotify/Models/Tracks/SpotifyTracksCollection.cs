using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Spotify.Models.Tracks {
    
    /// <summary>
    /// Class representing a collection of Spotify tracks.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.spotify.com/web-api/object-model/#track-object-simplified</cref>
    /// </see>
    public class SpotifyTracksCollection : SpotifyObject, IEnumerable<SpotifyTrackItem> {

        #region Properties

        /// <summary>
        /// Gets the link to the Web API endpoint returning the full result of the request.
        /// </summary>
        public string Href { get; }

        /// <summary>
        /// Gets an array of the tracks in the collection.
        /// </summary>
        public SpotifyTrackItem[] Items { get; }

        /// <summary>
        /// Gets the length of the collection.
        /// </summary>
        public int Length => Items.Length;

        /// <summary>
        /// Gets the track at the specified <paramref name="index"/>.
        /// </summary>
        /// <param name="index">The index of the track.</param>
        /// <returns>An instance of <see cref="SpotifyTrackItem"/>.</returns>
        public SpotifyTrackItem this[int index] => Items[index];

        /// <summary>
        /// Gets the maximum number of items in the response (as set in the query or by default).
        /// </summary>
        public int Limit { get; }

        /// <summary>
        /// Gets the URL to the next page of items (<c>null</c> if none).
        /// </summary>
        public string Next { get; }

        /// <summary>
        /// Gets the offset of the items returned (as set in the query or by default).
        /// </summary>
        public int Offset { get; }

        /// <summary>
        /// Gets the URL to the previous page of items (<c>null</c> if none).
        /// </summary>
        public string Previous { get; }

        /// <summary>
        /// Gets the total number of items available to return. 
        /// </summary>
        public int Total { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        protected SpotifyTracksCollection(JObject obj) : base(obj) {
            Href = obj.GetString("href");
            Items = obj.GetArrayItems("items", SpotifyTrackItem.Parse);
            Limit = obj.GetInt32("limit");
            Next = obj.GetString("next");
            Offset = obj.GetInt32("offset");
            Previous = obj.GetString("previous");
            Total = obj.GetInt32("total");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SpotifyTracksCollection"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyTracksCollection"/>.</returns>
        public static SpotifyTracksCollection Parse(JObject obj) {
            return obj == null ? null : new SpotifyTracksCollection(obj); 
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<SpotifyTrackItem> GetEnumerator() {
            return ((IEnumerable<SpotifyTrackItem>)Items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

    }

}