using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Spotify.Models.Artists;
using Skybrud.Social.Spotify.Models.Common;

namespace Skybrud.Social.Spotify.Models.Tracks {

    /// <see>
    ///     <cref>https://developer.spotify.com/web-api/object-model/#track-object-simplified</cref>
    /// </see>
    public class SpotifyTrackItem : SpotifyObject {

        #region Properties

        /// <summary>
        /// Gets an array with the artists of the track.
        /// </summary>
        public SpotifyArtistItem[] Artists { get; }

        /// <summary>
        /// Gets a list of the countries in which the track can be played, identified by their ISO 3166-1 alpha-2 code.
        /// </summary>
        public string[] AvailableMarkets { get; }

        /// <summary>
        /// Gets the disc number (usually <c>1</c> unless the album consists of more than one disc).
        /// </summary>
        public int DiscNumber { get; }

        /// <summary>
        /// Gets the length of the track.
        /// </summary>
        public TimeSpan Duration { get; }

        /// <summary>
        /// Gets whether or not the track has explicit lyrics (<c>true</c> = yes it does; <c>false</c> = no it does not OR unknown).
        /// </summary>
        public bool IsExplicit { get; }

        /// <summary>
        /// Gets a collection of external URLs for this track.
        /// </summary>
        public SpotifyExternalUrls ExternalUrls { get; }

        /// <summary>
        /// Gets a link to the Web API endpoint providing full details of the track.
        /// </summary>
        public string Href { get; }

        /// <summary>
        /// Gets the Spotify ID for the track.
        /// </summary>
        public string Id { get; }

        // TODO: Add support for the "is_playable" property

        // TODO: Add support for the "linked_from" property

        /// <summary>
        /// Gets the name of the track.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets a URL to a 30 second preview (MP3 format) of the track, <c>null</c> if not available.
        /// </summary>
        public string PreviewUrl { get; }

        /// <summary>
        /// Gets the number of the track. If an album has several discs, the track number is the number on the specified disc.
        /// </summary>
        public int TrackNumber { get; }

        /// <summary>
        /// Gets the object type: <c>track</c>.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets the Spotify URI for the track.
        /// </summary>
        public string Uri { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        protected SpotifyTrackItem(JObject obj) : base(obj) {
            Artists = obj.GetArrayItems("artists", SpotifyArtistItem.Parse);
            AvailableMarkets = obj.GetStringArray("available_markets");
            DiscNumber = obj.GetInt32("disc_number");
            Duration = obj.GetDouble("duration_ms", TimeSpan.FromMilliseconds);
            IsExplicit = obj.GetBoolean("explicit");
            ExternalUrls = obj.GetObject("external_urls", SpotifyExternalUrls.Parse);
            Href = obj.GetString("href");
            Id = obj.GetString("id");
            Name = obj.GetString("name");
            PreviewUrl = obj.GetString("preview_url");
            TrackNumber = obj.GetInt32("track_number");
            Type = obj.GetString("type");
            Uri = obj.GetString("uri");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SpotifyTrackItem"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyTrack"/>.</returns>
        public static SpotifyTrackItem Parse(JObject obj) {
            return obj == null ? null : new SpotifyTrackItem(obj); 
        }

        #endregion

    }

}