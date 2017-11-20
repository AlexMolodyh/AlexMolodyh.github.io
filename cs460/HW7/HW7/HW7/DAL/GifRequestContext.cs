namespace HW7.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using HW7.Models;

    public partial class GifRequestContext : DbContext
    {
        public GifRequestContext()
            : base("name=GifRequestContext")
        {
        }

        public virtual DbSet<GifRequest> GifRequests { get; set; }
    }
}
