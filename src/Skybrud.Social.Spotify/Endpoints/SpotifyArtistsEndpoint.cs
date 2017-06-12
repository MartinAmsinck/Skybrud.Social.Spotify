using System;
using Skybrud.Social.Http;
using Skybrud.Social.Spotify.Endpoints.Raw;
using Skybrud.Social.Spotify.Options.Artists;
using Skybrud.Social.Spotify.Responses.Artists;

namespace Skybrud.Social.Spotify.Endpoints {

    /// <summary>
    /// Class representing the implementation of the artists endpoint.
    /// </summary>
    public class SpotifyArtistsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Spotify service.
        /// </summary>
        public SpotifyService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public SpotifyArtistsRawEndpoint Raw {
            get { return Service.Client.Artists; }
        }

        #endregion

        #region Constructors

        internal SpotifyArtistsEndpoint(SpotifyService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets Spotify catalog information for a single artist identified by their unique Spotify ID.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <returns>An instance of <see cref="SpotifyGetArtistResponse"/> representing the response.</returns>
        public SpotifyGetArtistResponse GetArtist(string id) {
            return SpotifyGetArtistResponse.ParseResponse(Raw.GetArtist(id));
        }

        /// <summary>
        /// Gets Spotify catalog information for several artists based on their Spotify IDs.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs for the artists. Maximum: 50 IDs.</param>
        /// <returns>An instance of <see cref="SpotifyGetArtistsResponse"/> representing the response.</returns>
        public SpotifyGetArtistsResponse GetArtists(params string[] ids) {
            return SpotifyGetArtistsResponse.ParseResponse(Raw.GetArtists(ids));
        }

        /// <summary>
        /// Gets Spotify catalog information about an artist’s albums.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <returns>Returns an instance of <code>SocialHttpRequest</code> representing the response.</returns>
        public SocialHttpResponse GetAlbums(string id) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets Spotify catalog information about an artist’s albums.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>Returns an instance of <code>SocialHttpRequest</code> representing the response.</returns>
        public SocialHttpResponse GetAlbums(SpotifyGetAlbumsOptions options) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets Spotify catalog information about an artist’s top tracks by country.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <param name="country">The country: an ISO 3166-1 alpha-2 country code. </param>
        /// <returns>Returns an instance of <code>SocialHttpRequest</code> representing the response.</returns>
        public SocialHttpResponse GetTopTracks(string id, string country) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets Spotify catalog information about artists similar to a given artist. Similarity is based on analysis
        /// of the Spotify community’s listening history.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <returns>Returns an instance of <code>SocialHttpRequest</code> representing the response.</returns>
        public SocialHttpResponse GetRelatedArtists(string id) {
            throw new NotImplementedException();
        }

        #endregion

    }

}