using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;
using Skybrud.Social.Spotify.Models.Albums;

namespace Skybrud.Social.Spotify.Options.Artists {

    /// <summary>
    /// Class representing the options for a reqyest to get a list of albums of an artist.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.spotify.com/web-api/get-artists-albums/</cref>
    /// </see>
    public class SpotifyGetAlbumsOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Required: Gets or sets the Spotify ID for the artist.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Optional: Gets or sets a list of keywords that will be used to filter the response. If not supplied, all
        /// album types will be returned.
        /// </summary>
        public SpotifyAlbumTypesCollection AlbumType { get; set; }

        /// <summary>
        /// Optional: Gets or sets an ISO 3166-1 alpha-2 country code. Supply this parameter to limit the response to
        /// one particular geographical market.
        /// 
        /// If not specified, results will be returned for all markets and you are likely to get duplicate results per
        /// album, one for each market in which the album is available!
        /// </summary>
        public string Market { get; set; }

        /// <summary>
        /// Optional: Gets or sets the number of album objects to return. Default: <code>20</code>. Minimum:
        /// <code>1</code>. Maximum: <code>50</code>.
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Optional: Gets or sets the index of the first album to return.
        /// </summary>
        public int Offset { get; set; }

        #endregion

        #region Member methods

        public IHttpQueryString GetQueryString() {
            
            SocialHttpQueryString query = new SocialHttpQueryString();

            if (AlbumType != null && AlbumType.Count > 0) query.Add("album_type", AlbumType);
            if (!String.IsNullOrWhiteSpace(Market)) query.Add("market", Market);
            if (Limit > 0) query.Add("limit", Limit);
            if (Offset > 0) query.Add("offset", Offset);

            return query;

        }

        #endregion

    }

}