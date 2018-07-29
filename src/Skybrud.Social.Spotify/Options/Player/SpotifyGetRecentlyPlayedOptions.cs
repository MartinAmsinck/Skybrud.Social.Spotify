using Skybrud.Essentials.Time;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.Spotify.Options.Player {

    public class SpotifyGetRecentlyPlayedOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the maximum number of items to return. Default: <c>20</c>. Minimum: <c>1</c>. Maximum: <c>50</c>.
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Returns all items after (but not including) this cursor position. If <see cref="After"/> is specified, <see cref="Before"/> must not be specified.
        /// </summary>
        public EssentialsDateTime After { get; set; }

        /// <summary>
        /// Returns all items before (but not including) this cursor position. If <see cref="Before"/>  is specified, <see cref="After"/> must not be specified.
        /// </summary>
        public EssentialsDateTime Before { get; set; }

        #endregion

        #region Constructors

        public SpotifyGetRecentlyPlayedOptions() { }

        public SpotifyGetRecentlyPlayedOptions(int limit) {
            Limit = limit;
        }

        #endregion

        #region Member methods

        public IHttpQueryString GetQueryString() {

            IHttpQueryString query = new SocialHttpQueryString();

            if (Limit > 0) query.Add("limit", Limit);
            if (After != null) query.Add("after", After.UnixTimestamp);
            if (Before != null) query.Add("before", Before.UnixTimestamp);

            return query;

        }

        #endregion

    }

}