using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW7.Models
{
    public class GiphyResponse
    {
        public string Type { get; set; }
        public string ID { get; set; }
        public string Slug { get; set; }
        public string Url { get; set; }
        public string BitlyGifUrl { get; set; }
        public string BitlyUrl { get; set; }
        public string EmbedUrl { get; set; }
        public string Username { get; set; }
        public string Source { get; set; }
        public string Rating { get; set; }
        public string ContentUrl { get; set; }
        public string SourceTld { get; set; }
        public string SourcePostUrl { get; set; }
        public string IsIndexable { get; set; }
        public string ImportDataTime { get; set; }
        public string TrendingDateTime { get; set; }
        public IEnumerable<GiphyImage> Images { get; set; }
    }
}