using System;
using Skybrud.Essentials.Common;
using Skybrud.Social.Http;
using Skybrud.Social.Spotify.OAuth;
using Skybrud.Social.Spotify.Options.Albums;

namespace Skybrud.Social.Spotify.Endpoints.Raw {
    
    /// <summary>
    /// Class representing the raw implementation of the albums endpoint.
    /// </summary>
    public class SpotifyAlbumsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public SpotifyOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal SpotifyAlbumsRawEndpoint(SpotifyOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets Spotify catalog information for the album with the specified <paramref name="albumId"/>.
        /// </summary>
        /// <param name="albumId">The Spotify ID of the album.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/web-api/get-album/</cref>
        /// </see>
        public SocialHttpResponse GetAlbum(string albumId) {
            if (String.IsNullOrWhiteSpace(albumId)) throw new ArgumentNullException(nameof(albumId));
            return Client.DoHttpGetRequest($"/v1/albums/{albumId}");
        }

        /// <summary>
        /// Gets Spotify catalog information for multiple albums identified by the specified Spotify <paramref name="ids"/>.
        /// </summary>
        /// <param name="ids">A array of the Spotify IDs of the albums. Maximum: 20 IDs.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/web-api/get-several-albums/</cref>
        /// </see>
        public SocialHttpResponse GetAlbums(params string[] ids) {
            if (ids == null) throw new ArgumentNullException(nameof(ids));
            return Client.DoHttpGetRequest("/v1/albums", new SocialHttpQueryString {
                {"ids", String.Join(",", ids)}
            });
        }

        /// <summary>
        /// Gets Spotify catalog information about the tracks of the album with the specified <paramref name="albumId"/>.
        /// </summary>
        /// <param name="albumId">The Spotify ID of the album.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/web-api/get-albums-tracks/</cref>
        /// </see>
        public SocialHttpResponse GetAlbumTracks(string albumId) {
            if (String.IsNullOrWhiteSpace(albumId)) throw new ArgumentNullException(nameof(albumId));
            return GetAlbumTracks(new SpotifyGetAlbumTracksOptions(albumId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="albumId">The Spotify ID of the album.</param>
        /// <param name="limit">The maximum number of tracks to return. Default: <c>20</c>. Maximum: <c>50</c>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/web-api/get-albums-tracks/</cref>
        /// </see>
        public SocialHttpResponse GetAlbumTracks(string albumId, int limit) {
            if (String.IsNullOrWhiteSpace(albumId)) throw new ArgumentNullException(nameof(albumId));
            return GetAlbumTracks(new SpotifyGetAlbumTracksOptions(albumId, limit));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="albumId">The Spotify ID of the album.</param>
        /// <param name="limit">The maximum number of tracks to return. Default: <c>20</c>. Maximum: <c>50</c>.</param>
        /// <param name="offset">The index of the first track to return. Default: <c>0</c> (the first object).</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/web-api/get-albums-tracks/</cref>
        /// </see>
        public SocialHttpResponse GetAlbumTracks(string albumId, int limit, int offset) {
            if (String.IsNullOrWhiteSpace(albumId)) throw new ArgumentNullException(nameof(albumId));
            return GetAlbumTracks(new SpotifyGetAlbumTracksOptions(albumId, limit, offset));
        }

        /// <summary>
        /// Gets Spotify catalog information about the tracks of the album matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/web-api/get-albums-tracks/</cref>
        /// </see>
        public SocialHttpResponse GetAlbumTracks(SpotifyGetAlbumTracksOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            if (String.IsNullOrWhiteSpace(options.AlbumId)) throw new PropertyNotSetException(nameof(options.AlbumId));
            return Client.DoHttpGetRequest($"/v1/albums/{options.AlbumId}/tracks", options);
        }
        
        #endregion

    }

}