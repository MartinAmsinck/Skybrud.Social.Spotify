using System;
using Skybrud.Essentials.Common;
using Skybrud.Social.Http;
using Skybrud.Social.Spotify.OAuth;
using Skybrud.Social.Spotify.Options.Artists;

namespace Skybrud.Social.Spotify.Endpoints.Raw {
    
    /// <summary>
    /// Class representing the raw implementation of the artists endpoint.
    /// </summary>
    public class SpotifyArtistsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public SpotifyOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal SpotifyArtistsRawEndpoint(SpotifyOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets Spotify catalog information for a single artist identified by their unique Spotify ID.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <returns>Returns an instance of <code>SocialHttpRequest</code> representing the response.</returns>
        public SocialHttpResponse GetArtist(string id) {
            if (String.IsNullOrWhiteSpace(id)) throw new ArgumentNullException("id");
            return Client.DoHttpGetRequest("https://api.spotify.com/v1/artists/" + id);
        }

        /// <summary>
        /// Gets Spotify catalog information for several artists based on their Spotify IDs.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs for the artists. Maximum: 50 IDs.</param>
        /// <returns>Returns an instance of <code>SocialHttpRequest</code> representing the response.</returns>
        public SocialHttpResponse GetArtists(params string[] ids) {
            if (ids == null || ids.Length == 0) throw new ArgumentNullException("ids");
            return Client.DoHttpGetRequest("https://api.spotify.com/v1/artists/?ids=" + String.Join(",", ids));
        }

        /// <summary>
        /// Gets Spotify catalog information about an artist’s albums.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <returns>Returns an instance of <code>SocialHttpRequest</code> representing the response.</returns>
        public SocialHttpResponse GetAlbums(string id) {
            if (String.IsNullOrWhiteSpace(id)) throw new ArgumentNullException("id");
            return Client.DoHttpGetRequest("https://api.spotify.com/v1/artists/" + id + "/albums");
        }

        /// <summary>
        /// Gets Spotify catalog information about an artist’s albums.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>Returns an instance of <code>SocialHttpRequest</code> representing the response.</returns>
        public SocialHttpResponse GetAlbums(SpotifyGetAlbumsOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            if (String.IsNullOrWhiteSpace(options.Id)) throw new PropertyNotSetException("options.Id");
            return Client.DoHttpGetRequest("https://api.spotify.com/v1/artists/" + options.Id + "/albums");
        }
        
        /// <summary>
        /// Gets Spotify catalog information about an artist’s top tracks by country.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <param name="country">The country: an ISO 3166-1 alpha-2 country code. </param>
        /// <returns>Returns an instance of <code>SocialHttpRequest</code> representing the response.</returns>
        public SocialHttpResponse GetTopTracks(string id, string country) {
            if (String.IsNullOrWhiteSpace(id)) throw new ArgumentNullException("id");
            if (String.IsNullOrWhiteSpace(country)) throw new ArgumentNullException("country");
            return Client.DoHttpGetRequest("https://api.spotify.com/v1/artists/" + id + "/top-tracks?country=" + country);
        }

        /// <summary>
        /// Gets Spotify catalog information about artists similar to a given artist. Similarity is based on analysis
        /// of the Spotify community’s listening history.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <returns>Returns an instance of <code>SocialHttpRequest</code> representing the response.</returns>
        public SocialHttpResponse GetRelatedArtists(string id) {
            if (String.IsNullOrWhiteSpace(id)) throw new ArgumentNullException("id");
            return Client.DoHttpGetRequest("https://api.spotify.com/v1/artists/" + id + "/related-artists");
        }

        #endregion

    }

}