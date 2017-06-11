using System;
using System.Collections.Generic;
using System.Linq;
using Skybrud.Essentials.Strings;

namespace Skybrud.Social.Spotify.Models.Albums {

    public class SpotifyAlbumTypesCollection {

        #region Private fields

        private readonly List<SpotifyAlbumType> _list = new List<SpotifyAlbumType>(); 

        #endregion

        #region Properties

        public int Count {
            get { return _list.Count; }
        }

        public SpotifyAlbumType[] Types {
            get { return _list.ToArray(); }
        }

        public bool IsEmpty {
            get { return _list.Count == 0; }
        }

        #endregion

        #region Member methods

        public void AddType(SpotifyAlbumType type) {
            _list.Add(type);
        }

        public void RemoveType(SpotifyAlbumType type) {
            _list.Remove(type);
        }

        public bool HasType(SpotifyAlbumType type) {
            return _list.Contains(type);
        }

        public override string ToString() {
            return String.Join(",", from type in _list select StringUtils.ToUnderscore(type));
        }

        #endregion

    }

}