using Skybrud.Social.Http;
using Skybrud.Social.Spotify.Models.Artists;
using Skybrud.Social.Spotify.Models.Tracks;

namespace Skybrud.Social.Spotify.Responses.Tracks
{

    public class SpotifyGetTrackResponse : SpotifyResponse<SpotifyTrack>
    {

        #region Constructors

        private SpotifyGetTrackResponse(SocialHttpResponse response) : base(response)
        {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, SpotifyTrack.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="SpotifyGetTrackResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyGetTrackResponse"/>.</returns>
        public static SpotifyGetTrackResponse ParseResponse(SocialHttpResponse response)
        {
            return response == null ? null : new SpotifyGetTrackResponse(response);
        }

        #endregion

    }

}