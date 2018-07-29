using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Skybrud.Social.Spotify.Models.Common {

    public class SpotifyDictionary : SpotifyObject {

        private readonly Dictionary<string, string> _dictionary; 

        #region Properties

        public string this[string key] {
            get {
                string value;
                return _dictionary.TryGetValue(key, out value) ? value : null;
            }
        }

        public string[] Keys => _dictionary.Keys.ToArray();

        public string[] Values => _dictionary.Values.ToArray();

        #endregion

        #region Constructors

        protected SpotifyDictionary(JObject obj) : base(obj) {
            _dictionary = obj.Properties().ToDictionary(x => x.Name, x => x.Value + "");
        }

        #endregion

        #region Member methods

        public bool ContainsKey(string key) {
            return _dictionary.ContainsKey(key);
        }

        #endregion

    }

}