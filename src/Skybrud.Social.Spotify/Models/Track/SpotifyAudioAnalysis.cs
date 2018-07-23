using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Spotify.Models.Artists;

namespace Skybrud.Social.Spotify.Models.Track
{
    public class SpotifyAudioAnalysis : SpotifyObject
    {
        public Meta Meta { get; set; }
        public Track Track { get; set; }
        public BaseStat[] Bars { get; set; }
        public BaseStat[] Beats { get; set; }
        public BaseStat[] Tatums { get; set; }
        public Section[] Sections { get; set; }
        public Segment[] Segments { get; set; }

        #region Constructors

        private SpotifyAudioAnalysis(JObject obj) : base(obj)
        {
            Meta = obj.GetObject("meta", Meta.Parse);
            Track = obj.GetObject("meta", Track.Parse);
            Bars = obj.GetArrayItems("bars", BaseStat.Parse);
            Beats = obj.GetArrayItems("beats", BaseStat.Parse);
            Tatums = obj.GetArrayItems("tatums", BaseStat.Parse);
            Sections = obj.GetArrayItems("sections", Section.Parse);
            Segments = obj.GetArrayItems("segments", Segment.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SpotifyAudioAnalysis"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyAudioAnalysis"/>.</returns>
        public static SpotifyAudioAnalysis Parse(JObject obj)
        {
            return obj == null ? null : new SpotifyAudioAnalysis(obj);
        }

        #endregion
    }

    public class BaseStat : SpotifyObject
    {
        public double Start { get; set; }
        public double Duration { get; set; }
        public double Confidence { get; set; }

        #region Constructors

        private BaseStat(JObject obj) : base(obj)
        {
            Start = obj.GetDouble("start");
            Duration = obj.GetDouble("duration");
            Confidence = obj.GetDouble("confidence");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="BaseStat"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="BaseStat"/>.</returns>
        public static BaseStat Parse(JObject obj)
        {
            return obj == null ? null : new BaseStat(obj);
        }

        #endregion
    }

    public class Meta : SpotifyObject
    {
        public string AnalyzerVersion { get; set; }
        public string Platform { get; set; }
        public string DetailedStatus { get; set; }
        public long StatusCode { get; set; }
        public long Timestamp { get; set; }
        public double AnalysisTime { get; set; }
        public string InputProcess { get; set; }

        #region Constructors

        private Meta(JObject obj) : base(obj)
        {
            AnalyzerVersion = obj.GetString("analyzer_version");
            Platform = obj.GetString("platform");
            DetailedStatus = obj.GetString("detailed_status");
            StatusCode = obj.GetInt64("status_code");
            Timestamp = obj.GetInt64("timestamp");
            AnalysisTime = obj.GetDouble("analysis_time");
            InputProcess = obj.GetString("input_process");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="Meta"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SpotifyAudioAnalysis"/>.</returns>
        public static Meta Parse(JObject obj)
        {
            return obj == null ? null : new Meta(obj);
        }

        #endregion
    }

    public class Section : SpotifyObject
    {
        public double Start { get; set; }
        public double Duration { get; set; }
        public double Confidence { get; set; }
        public double Loudness { get; set; }
        public double Tempo { get; set; }
        public double TempoConfidence { get; set; }
        public double Key { get; set; }
        public double KeyConfidence { get; set; }
        public double Mode { get; set; }
        public double ModeConfidence { get; set; }
        public double TimeSignature { get; set; }
        public double TimeSignatureConfidence { get; set; }

        #region Constructors

        private Section(JObject obj) : base(obj)
        {
            Start = obj.GetDouble("start");
            Duration = obj.GetDouble("duration");
            Confidence = obj.GetDouble("confidence");
            Loudness = obj.GetDouble("loudness");
            Tempo = obj.GetDouble("tempo");
            TempoConfidence = obj.GetDouble("tempo_confidence");
            Key = obj.GetDouble("key");
            KeyConfidence = obj.GetDouble("key_confidence");
            Mode = obj.GetDouble("mode");
            ModeConfidence = obj.GetDouble("mode_confidence");
            TimeSignature = obj.GetDouble("time_signature");
            TimeSignatureConfidence = obj.GetDouble("time_signature_confidence");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="Section"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="Section"/>.</returns>
        public static Section Parse(JObject obj)
        {
            return obj == null ? null : new Section(obj);
        }

        #endregion
    }

    public class Segment : SpotifyObject
    {
        public double Start { get; set; }
        public double Duration { get; set; }
        public double Confidence { get; set; }
        public double LoudnessStart { get; set; }
        public double LoudnessMaxTime { get; set; }
        public double LoudnessMax { get; set; }
        public double[] Pitches { get; set; }
        public double[] Timbre { get; set; }
        //public long? LoudnessEnd { get; set; }

        #region Constructors

        private Segment(JObject obj) : base(obj)
        {
            Start = obj.GetDouble("start");
            Duration = obj.GetDouble("duration");
            Confidence = obj.GetDouble("confidence");
            LoudnessStart = obj.GetDouble("loudness_start");
            LoudnessMax = obj.GetDouble("loudness_max");
            LoudnessMaxTime = obj.GetDouble("loudness_max_time");
            Pitches = obj.GetArrayItems<double>("pitches");
            Timbre = obj.GetArrayItems<double>("timbre");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="Segment"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="Segment"/>.</returns>
        public static Segment Parse(JObject obj)
        {
            return obj == null ? null : new Segment(obj);
        }

        #endregion
    }

    public class Track : SpotifyObject
    {
        public long NumSamples { get; set; }
        public double Duration { get; set; }
        public string SampleMd5 { get; set; }
        public long OffsetSeconds { get; set; }
        public long WindowSeconds { get; set; }
        public long AnalysisSampleRate { get; set; }
        public long AnalysisChannels { get; set; }
        public double EndOfFadeIn { get; set; }
        public double StartOfFadeOut { get; set; }
        public double Loudness { get; set; }
        public double Tempo { get; set; }
        public double TempoConfidence { get; set; }
        public long TimeSignature { get; set; }
        public long TimeSignatureConfidence { get; set; }
        public long Key { get; set; }
        public double KeyConfidence { get; set; }
        public long Mode { get; set; }
        public double ModeConfidence { get; set; }
        public string Codestring { get; set; }
        public double CodeVersion { get; set; }
        public string Echoprintstring { get; set; }
        public double EchoprintVersion { get; set; }
        public string Synchstring { get; set; }
        public long SynchVersion { get; set; }
        public string Rhythmstring { get; set; }
        public long RhythmVersion { get; set; }


        #region Constructors

        private Track(JObject obj) : base(obj)
        {
            NumSamples = obj.GetInt64("num_samples");
            Duration = obj.GetDouble("duration");
            SampleMd5 = obj.GetString("sample_md5");
            OffsetSeconds = obj.GetInt64("offset_seconds");
            WindowSeconds = obj.GetInt64("window_seconds");
            AnalysisSampleRate = obj.GetInt64("analysis_sample_rate");
            AnalysisChannels = obj.GetInt64("analysis_channels");
            EndOfFadeIn = obj.GetDouble("end_of_fade_in");
            StartOfFadeOut = obj.GetDouble("start_of_fade_out");
            Loudness = obj.GetDouble("num_samples");
            Tempo = obj.GetDouble("tempo");
            TempoConfidence = obj.GetInt64("tempo_confidence");

            TimeSignature = obj.GetInt64("time_signature");
            TimeSignatureConfidence = obj.GetInt64("time_signature_confidence");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="Track"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="Track"/>.</returns>
        public static Track Parse(JObject obj)
        {
            return obj == null ? null : new Track(obj);
        }

        #endregion
    }
}