using System;
namespace CodeRadio.Model;

using System;
using System.Collections.Generic;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;

public partial class RadioResponse
{
    [JsonPropertyName("station")]
    public Station Station { get; set; }

    [JsonPropertyName("listeners")]
    public Listeners Listeners { get; set; }

    [JsonPropertyName("live")]
    public Live Live { get; set; }

    [JsonPropertyName("now_playing")]
    public NowPlaying NowPlaying { get; set; }

    [JsonPropertyName("playing_next")]
    public PlayingNext PlayingNext { get; set; }

    [JsonPropertyName("song_history")]
    public NowPlaying[] SongHistory { get; set; }

    [JsonPropertyName("is_online")]
    public bool IsOnline { get; set; }

    [JsonPropertyName("cache")]
    public string Cache { get; set; }
}

public partial class Listeners
{
    [JsonPropertyName("total")]
    public long Total { get; set; }

    [JsonPropertyName("unique")]
    public long Unique { get; set; }

    [JsonPropertyName("current")]
    public long Current { get; set; }
}

public partial class Live
{
    [JsonPropertyName("is_live")]
    public bool IsLive { get; set; }

    [JsonPropertyName("streamer_name")]
    public string StreamerName { get; set; }

    [JsonPropertyName("broadcast_start")]
    public object BroadcastStart { get; set; }
}

public partial class NowPlaying
{
    [JsonPropertyName("elapsed")]
    public double Elapsed { get; set; }

    [JsonPropertyName("remaining")]
    public double Remaining { get; set; }

    [JsonPropertyName("sh_id")]
    public double ShId { get; set; }

    [JsonPropertyName("played_at")]
    public double PlayedAt { get; set; }

    [JsonPropertyName("duration")]
    public double Duration { get; set; }

    [JsonPropertyName("playlist")]
    public string Playlist { get; set; }

    [JsonPropertyName("streamer")]
    public string Streamer { get; set; }

    [JsonPropertyName("is_request")]
    public bool IsRequest { get; set; }

    [JsonPropertyName("song")]
    public Song Song { get; set; }
}

public partial class Song
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("artist")]
    public string Artist { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("album")]
    public string Album { get; set; }

    [JsonPropertyName("genre")]
    public string Genre { get; set; }

    [JsonPropertyName("lyrics")]
    public string Lyrics { get; set; }

    [JsonPropertyName("art")]
    public Uri Art { get; set; }

    [JsonPropertyName("custom_fields")]
    public object[] CustomFields { get; set; }
}

public partial class PlayingNext
{
    [JsonPropertyName("cued_at")]
    public long CuedAt { get; set; }

    [JsonPropertyName("duration")]
    public long Duration { get; set; }

    [JsonPropertyName("playlist")]
    public string Playlist { get; set; }

    [JsonPropertyName("is_request")]
    public bool IsRequest { get; set; }

    [JsonPropertyName("song")]
    public Song Song { get; set; }
}

public partial class Station
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("shortcode")]
    public string Shortcode { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("frontend")]
    public string Frontend { get; set; }

    [JsonPropertyName("backend")]
    public string Backend { get; set; }

    [JsonPropertyName("listen_url")]
    public Uri ListenUrl { get; set; }

    [JsonPropertyName("url")]
    public Uri Url { get; set; }

    [JsonPropertyName("public_player_url")]
    public Uri PublicPlayerUrl { get; set; }

    [JsonPropertyName("playlist_pls_url")]
    public Uri PlaylistPlsUrl { get; set; }

    [JsonPropertyName("playlist_m3u_url")]
    public Uri PlaylistM3UUrl { get; set; }

    [JsonPropertyName("is_public")]
    public bool IsPublic { get; set; }

    [JsonPropertyName("mounts")]
    public Mount[] Mounts { get; set; }

    [JsonPropertyName("remotes")]
    public Mount[] Remotes { get; set; }
}

public partial class Mount
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("path")]
    public string Path { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("is_default")]
    public bool? IsDefault { get; set; }

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public Uri Url { get; set; }

    [JsonPropertyName("bitrate")]
    public long Bitrate { get; set; }

    [JsonPropertyName("format")]
    public string Format { get; set; }

    [JsonPropertyName("listeners")]
    public Listeners Listeners { get; set; }
}
