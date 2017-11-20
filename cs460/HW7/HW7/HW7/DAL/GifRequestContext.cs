namespace HW7.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GifRequestContext : DbContext
    {
        public GifRequestContext()
            : base("name=GifRequestContext")
        {
        }

        public virtual DbSet<GiphyRequest> GiphyRequests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
