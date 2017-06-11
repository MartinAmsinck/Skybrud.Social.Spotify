﻿using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Spotify.Models.Artists {

    public class SpotifyArtistCollection : SpotifyObject {

        #region Properties

        /// <summary>
        /// Gets an array of artists.
        /// </summary>
        public SpotifyArtist[] Artists { get; private set; }

        #endregion

        #region Constructors

        private SpotifyArtistCollection(JObject obj) : base(obj) {
            Artists = obj.GetArray("artists", SpotifyArtist.Parse);
        }

        #endregion

        #region Static methods

        public static SpotifyArtistCollection Parse(JObject obj) {
            return obj == null ? null : new SpotifyArtistCollection(obj); 
        }

        #endregion

    }

}