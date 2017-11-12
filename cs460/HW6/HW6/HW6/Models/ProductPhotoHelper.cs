using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW6.Models
{
    public static class ProductPhotoHelper
    {
        public static int GetRandomInt(this ProductPhoto ph, int maxSize)
        {
            Random rand = new Random();
            return rand.Next(0, maxSize);
        }
    }
}