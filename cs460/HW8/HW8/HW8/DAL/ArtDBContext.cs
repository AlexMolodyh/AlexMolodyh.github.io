namespace HW8.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using HW8.Model;

    public partial class ArtDBContext : DbContext
    {
        public ArtDBContext()
            : base("name=ArtDBContext")
        {
        }

        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<ArtWork> ArtWorks { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .Property(e => e.BirthCity)
                .IsFixedLength();

            modelBuilder.Entity<Artist>()
                .HasMany(e => e.ArtWorks)
                .WithRequired(e => e.Artist1)
                .HasForeignKey(e => e.Artist)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ArtWork>()
                .HasMany(e => e.Genres)
                .WithMany(e => e.ArtWorks)
                .Map(m => m.ToTable("Classification").MapLeftKey("ArtWork").MapRightKey("Genre"));
        }
    }
}
