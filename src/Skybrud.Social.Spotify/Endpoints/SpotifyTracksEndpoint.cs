using System;
using Skybrud.Social.Http;
using Skybrud.Social.Spotify.Endpoints.Raw;
using Skybrud.Social.Spotify.Options.Artists;
using Skybrud.Social.Spotify.Responses.Artists;
using Skybrud.Social.Spotify.Responses.Tracks;

namespace Skybrud.Social.Spotify.Endpoints {

    /// <summary>
    /// Class representing the implementation of the artists endpoint.
    /// </summary>
    public class SpotifyTracksEndpoint
    {

        #region Properties

        /// <summary>
        /// Gets a reference to the Spotify service.
        /// </summary>
        public SpotifyService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public SpotifyTracksRawEndpoint Raw => Service.Client.Tracks;

        #endregion

        #region Constructors

        internal SpotifyTracksEndpoint(SpotifyService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Get Spotify catalog information for a single track identified by its unique Spotify ID.
        /// </summary>
        /// <param name="id">The Spotify ID for the track.</param>
        /// <returns>An instance of <see cref="SpotifyGetTrackResponse"/> representing the response.</returns>
        public SpotifyGetTrackResponse GetTrack(string id)
        {
            return SpotifyGetTrackResponse.ParseResponse(Raw.GetTrack(id));
        }

        /// <summary>
        /// Get Spotify catalog information for a single track identified by its unique Spotify ID.
        /// </summary>
        /// <param name="id">The Spotify ID for the track.</param>
        /// <returns>An instance of <see cref="SpotifyGetTrackResponse"/> representing the response.</returns>
        public SpotifyGetAudioAnalysisResponse GetAudioAnalysis(string id)
        {
            return SpotifyGetAudioAnalysisResponse.ParseResponse(Raw.GetAudioAnalysis(id));
        }

        #endregion

    }

}