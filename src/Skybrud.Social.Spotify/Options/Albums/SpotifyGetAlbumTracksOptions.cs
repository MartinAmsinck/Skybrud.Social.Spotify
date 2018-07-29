using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.Spotify.Options.Albums {
    
    /// <summary>
    /// Class representing the options for getting the tracks of a Spotify album.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.spotify.com/web-api/get-albums-tracks/</cref>
    /// </see>
    public class SpotifyGetAlbumTracksOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the Spotify ID for the album.
        /// </summary>
        public string AlbumId { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of tracks to return. Default: <c>20</c>. Maximum: <c>50</c>.
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Gets or sets the index of the first track to return. Default: <c>0</c> (the first object). Use with
        /// <see cref="Limit"/> to get the next set of tracks. 
        /// </summary>
        public int Offset { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public SpotifyGetAlbumTracksOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="albumId"/>.
        /// </summary>
        /// <param name="albumId">The Spotify ID for the album.</param>
        public SpotifyGetAlbumTracksOptions(string albumId) {
            AlbumId = albumId;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="albumId"/> and <paramref name="limit"/>.
        /// </summary>
        /// <param name="albumId">The Spotify ID for the album.</param>
        /// <param name="limit">The maximum number of tracks to return. Default: <c>20</c>. Maximum: <c>50</c>.</param>
        public SpotifyGetAlbumTracksOptions(string albumId, int limit) {
            AlbumId = albumId;
            Limit = limit;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="albumId"/>, <paramref name="limit"/> and <paramref name="offset"/>.
        /// </summary>
        /// <param name="albumId">The Spotify ID for the album.</param>
        /// <param name="limit">The maximum number of tracks to return. Default: <c>20</c>. Maximum: <c>50</c>.</param>
        /// <param name="offset">The index of the first track to return. Default: <c>0</c> (the first object).</param>
        public SpotifyGetAlbumTracksOptions(string albumId, int limit, int offset) {
            AlbumId = albumId;
            Limit = limit;
            Offset = offset;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        public IHttpQueryString GetQueryString() {
            SocialHttpQueryString query = new SocialHttpQueryString();
            if (Limit > 0) query.Add("limit", Limit);
            if (Offset > 0) query.Add("offset", Offset);
            return query;
        }

        #endregion

    }

}