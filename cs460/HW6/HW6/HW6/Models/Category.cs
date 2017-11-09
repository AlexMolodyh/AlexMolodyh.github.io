using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW6.Models
{
    public class Category
    {
        public IEnumerable<string> BikeCategories = new List<string> {"Mountain Bikes", "Road Bikes", "Touring Bikes"};
        

        public SelectList Bikes
        {
            get { return new SelectList(BikeCategories.ToArray()); }
        }

        public Gender TheGender { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}