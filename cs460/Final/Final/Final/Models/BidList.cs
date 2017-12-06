using Final.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW8.Models
{
    public class BidList
    {
        public List<string> bidsList;

        public BidList()
        {
            bidsList = new List<string>();
        }

        public List<string> BuyerNames { get; set; }

        public string BuyerName { get; set; }

        public int Price { get; set; }

        public int Size { get; set; }
    }
}