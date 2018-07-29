using Skybrud.Social.Http;
using Skybrud.Social.Spotify.Models.Tracks;

namespace Skybrud.Social.Spotify.Responses.Tracks
{

    public class SpotifyGetAudioAnalysisResponse : SpotifyResponse<SpotifyAudioAnalysis>
    {

        #region Constructors

        private SpotifyGetAudioAnalysisResponse(SocialHttpResponse response) : base(response)
        {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, SpotifyAudioAnalysis.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="SpotifyGetAudioAnalysisResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyGetAudioAnalysisResponse"/>.</returns>
        public static SpotifyGetAudioAnalysisResponse ParseResponse(SocialHttpResponse response)
        {
            return response == null ? null : new SpotifyGetAudioAnalysisResponse(response);
        }

        #endregion

    }

}