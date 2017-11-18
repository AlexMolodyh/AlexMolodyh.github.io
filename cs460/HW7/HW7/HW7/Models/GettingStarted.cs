using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW7.Models
{
    using System;
    using System.Net;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public partial class GettingStarted
    {
        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }

    public partial class Pagination
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }
    }

    public partial class Meta
    {
        [JsonProperty("msg")]
        public string Msg { get; set; }

        [JsonProperty("response_id")]
        public string ResponseId { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }
    }

    public partial class Datum
    {
        [JsonProperty("bitly_gif_url")]
        public string BitlyGifUrl { get; set; }

        [JsonProperty("bitly_url")]
        public string BitlyUrl { get; set; }

        [JsonProperty("content_url")]
        public string ContentUrl { get; set; }

        [JsonProperty("embed_url")]
        public string EmbedUrl { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }

        [JsonProperty("import_datetime")]
        public string ImportDatetime { get; set; }

        [JsonProperty("is_indexable")]
        public long IsIndexable { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("source_post_url")]
        public string SourcePostUrl { get; set; }

        [JsonProperty("source_tld")]
        public string SourceTld { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("trending_datetime")]
        public string TrendingDatetime { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public partial class User
    {
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("banner_url")]
        public string BannerUrl { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("is_verified")]
        public bool IsVerified { get; set; }

        [JsonProperty("profile_url")]
        public string ProfileUrl { get; set; }

        [JsonProperty("twitter")]
        public string Twitter { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public partial class Images
    {
        [JsonProperty("downsized")]
        public The480wStill Downsized { get; set; }

        [JsonProperty("downsized_large")]
        public The480wStill DownsizedLarge { get; set; }

        [JsonProperty("downsized_medium")]
        public The480wStill DownsizedMedium { get; set; }

        [JsonProperty("downsized_small")]
        public DownsizedSmall DownsizedSmall { get; set; }

        [JsonProperty("downsized_still")]
        public The480wStill DownsizedStill { get; set; }

        [JsonProperty("fixed_height")]
        public FixedHeight FixedHeight { get; set; }

        [JsonProperty("fixed_height_downsampled")]
        public FixedHeight FixedHeightDownsampled { get; set; }

        [JsonProperty("fixed_height_small")]
        public FixedHeight FixedHeightSmall { get; set; }

        [JsonProperty("fixed_height_small_still")]
        public The480wStill FixedHeightSmallStill { get; set; }

        [JsonProperty("fixed_height_still")]
        public The480wStill FixedHeightStill { get; set; }

        [JsonProperty("fixed_width")]
        public FixedHeight FixedWidth { get; set; }

        [JsonProperty("fixed_width_downsampled")]
        public FixedHeight FixedWidthDownsampled { get; set; }

        [JsonProperty("fixed_width_small")]
        public FixedHeight FixedWidthSmall { get; set; }

        [JsonProperty("fixed_width_small_still")]
        public The480wStill FixedWidthSmallStill { get; set; }

        [JsonProperty("fixed_width_still")]
        public The480wStill FixedWidthStill { get; set; }

        [JsonProperty("hd")]
        public DownsizedSmall Hd { get; set; }

        [JsonProperty("looping")]
        public Looping Looping { get; set; }

        [JsonProperty("original")]
        public FixedHeight Original { get; set; }

        [JsonProperty("original_mp4")]
        public DownsizedSmall OriginalMp4 { get; set; }

        [JsonProperty("original_still")]
        public The480wStill OriginalStill { get; set; }

        [JsonProperty("preview")]
        public DownsizedSmall Preview { get; set; }

        [JsonProperty("preview_gif")]
        public The480wStill PreviewGif { get; set; }

        [JsonProperty("preview_webp")]
        public The480wStill PreviewWebp { get; set; }

        [JsonProperty("480w_still")]
        public The480wStill The480wStill { get; set; }
    }

    public partial class Looping
    {
        [JsonProperty("mp4")]
        public string Mp4 { get; set; }

        [JsonProperty("mp4_size")]
        public string Mp4Size { get; set; }
    }

    public partial class FixedHeight
    {
        [JsonProperty("frames")]
        public string Frames { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("mp4")]
        public string Mp4 { get; set; }

        [JsonProperty("mp4_size")]
        public string Mp4Size { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("webp")]
        public string Webp { get; set; }

        [JsonProperty("webp_size")]
        public string WebpSize { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }
    }

    public partial class DownsizedSmall
    {
        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("mp4")]
        public string Mp4 { get; set; }

        [JsonProperty("mp4_size")]
        public string Mp4Size { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }
    }

    public partial class The480wStill
    {
        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }
    }
}