using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;

namespace Skybrud.Social.Spotify.Models {
    
    public class SpotifyObject : JsonObjectBase {

        public SpotifyObject(JObject obj) : base(obj) { }

    }

}