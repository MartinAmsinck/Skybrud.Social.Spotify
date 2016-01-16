using Newtonsoft.Json.Linq;

namespace Skybrud.Social.Spotify.Objects {
    
    public class SpotifyObject {

        public JObject JObject { get; private set; }

        public SpotifyObject(JObject obj) {
            JObject = obj;
        }

    }

}