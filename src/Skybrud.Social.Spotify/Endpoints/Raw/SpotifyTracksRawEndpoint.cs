using System;
using Skybrud.Essentials.Common;
using Skybrud.Social.Http;
using Skybrud.Social.Spotify.OAuth;
using Skybrud.Social.Spotify.Options.Artists;

namespace Skybrud.Social.Spotify.Endpoints.Raw
{

    /// <summary>
    /// Class representing the raw implementation of the tracks endpoint.
    /// </summary>
    public class SpotifyTracksRawEndpoint
    {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public SpotifyOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal SpotifyTracksRawEndpoint(SpotifyOAuthClient client)
        {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Get Spotify catalog information for a single track identified by its unique Spotify ID.
        /// </summary>
        /// <param name="id">	The Spotify ID for the track.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/web-api/get-track/</cref>
        /// </see>
        public SocialHttpResponse GetTrack(string id)
        {
            if (String.IsNullOrWhiteSpace(id)) throw new ArgumentNullException("id");
            return Client.DoHttpGetRequest("https://api.spotify.com/v1/tracks/" + id);
        }


        /// <summary>
        /// Get a detailed audio analysis for a single track identified by its unique Spotify ID.
        /// </summary>
        /// <param name="id">The Spotify ID for the track.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.spotify.com/web-api/get-audio-analysis/</cref>
        /// </see>
        public SocialHttpResponse GetAudioAnalysis(string id)
        {
            if (String.IsNullOrWhiteSpace(id)) throw new ArgumentNullException("id");
            return Client.DoHttpGetRequest("https://api.spotify.com/v1/audio-analysis/" + id);
        }


        #endregion

    }

}