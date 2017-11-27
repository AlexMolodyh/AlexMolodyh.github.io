using HW8.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW8.Models
{
    public class ArtWorkList
    {
        public List<string> artList;

        public ArtWorkList()
        {
            artList = new List<string>();
        }

        public List<string> ArtList { get; set; }

        public string GenreName { get; set; }

        public int Size { get; set; }
    }
}