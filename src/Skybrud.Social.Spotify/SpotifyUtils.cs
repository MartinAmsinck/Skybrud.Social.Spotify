using System;
using System.Text;

namespace Skybrud.Social.Spotify {
    
    public static class SpotifyUtils {

        public static string Base64Encode(string str) {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(str ?? ""));
        }

        public static string Base64Decode(string str) {
            return Encoding.UTF8.GetString(Convert.FromBase64String(str ?? ""));
        }

    }

}