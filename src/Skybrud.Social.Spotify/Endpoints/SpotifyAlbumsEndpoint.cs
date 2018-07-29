using Skybrud.Social.Spotify.Endpoints.Raw;
using Skybrud.Social.Spotify.Options.Albums;
using Skybrud.Social.Spotify.Responses.Albums;

namespace Skybrud.Social.Spotify.Endpoints {
    
    /// <summary>
    /// Class representing the implementation of the albums endpoint.
    /// </summary>
    public class SpotifyAlbumsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Spotify service.
        /// </summary>
        public SpotifyService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public SpotifyAlbumsRawEndpoint Raw {
            get { return Service.Client.Albums; }
        }

        #endregion

        #region Constructors

        internal SpotifyAlbumsEndpoint(SpotifyService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets Spotify catalog information for the album with the specified <paramref name="albumId"/>.
        /// </summary>
        /// <param name="albumId">The Spotify ID of the album.</param>
        /// <returns>An instance of <see cref="SpotifyGetAlbumResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/web-api/get-album/</cref>
        /// </see>
        public SpotifyGetAlbumResponse GetAlbum(string albumId) {
            return SpotifyGetAlbumResponse.ParseResponse(Raw.GetAlbum(albumId));
        }

        /// <summary>
        /// Gets Spotify catalog information for multiple albums identified by the specified Spotify <paramref name="ids"/>.
        /// </summary>
        /// <param name="ids">A array of the Spotify IDs of the albums. Maximum: 20 IDs.</param>
        /// <returns>An instance of <see cref="SpotifyGetAlbumsResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/web-api/get-several-albums/</cref>
        /// </see>
        public SpotifyGetAlbumsResponse GetAlbums(params string[] ids) {
            return SpotifyGetAlbumsResponse.ParseResponse(Raw.GetAlbums(ids));
        }

        /// <summary>
        /// Gets Spotify catalog information about the tracks of the album with the specified <paramref name="albumId"/>.
        /// </summary>
        /// <param name="albumId">The Spotify ID of the album.</param>
        /// <returns>An instance of <see cref="SpotifyGetAlbumTracksResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/web-api/get-albums-tracks/</cref>
        /// </see>
        public SpotifyGetAlbumTracksResponse GetAlbumTracks(string albumId) {
            return SpotifyGetAlbumTracksResponse.ParseResponse(Raw.GetAlbumTracks(albumId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="albumId">The Spotify ID of the album.</param>
        /// <param name="limit">The maximum number of tracks to return. Default: <c>20</c>. Maximum: <c>50</c>.</param>
        /// <returns>An instance of <see cref="SpotifyGetAlbumTracksResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/web-api/get-albums-tracks/</cref>
        /// </see>
        public SpotifyGetAlbumTracksResponse GetAlbumTracks(string albumId, int limit) {
            return SpotifyGetAlbumTracksResponse.ParseResponse(Raw.GetAlbumTracks(albumId, limit));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="albumId">The Spotify ID of the album.</param>
        /// <param name="limit">The maximum number of tracks to return. Default: <c>20</c>. Maximum: <c>50</c>.</param>
        /// <param name="offset">The index of the first track to return. Default: <c>0</c> (the first object).</param>
        /// <returns>An instance of <see cref="SpotifyGetAlbumTracksResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/web-api/get-albums-tracks/</cref>
        /// </see>
        public SpotifyGetAlbumTracksResponse GetAlbumTracks(string albumId, int limit, int offset) {
            return SpotifyGetAlbumTracksResponse.ParseResponse(Raw.GetAlbumTracks(albumId, limit, offset));
        }

        /// <summary>
        /// Gets Spotify catalog information about the tracks of the album matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="SpotifyGetAlbumTracksResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/web-api/get-albums-tracks/</cref>
        /// </see>
        public SpotifyGetAlbumTracksResponse GetAlbumTracks(SpotifyGetAlbumTracksOptions options) {
            return SpotifyGetAlbumTracksResponse.ParseResponse(Raw.GetAlbumTracks(options));
        }
        
        #endregion

    }

}