using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW7.Models
{
    public class GiphyImage
    {
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Size { get; set; }
        public string Mp4 { get; set; }
        public int Mp4Size { get; set; }
        public string Webp { get; set; }
        public int WebpSize { get; set; }
    }
}