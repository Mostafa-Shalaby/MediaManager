using MediaManager.Domains.Models;
using Microsoft.EntityFrameworkCore;

namespace MediaManager.EF.Database
{
    public class AppDbContext : DbContext
    {
        #region Database Table DataSets
        public DbSet<Demographic> Demographics { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        public DbSet<Media> Medias { get; set; }
        public DbSet<MediaDirectory> MediaDirectories { get; set; }
        #endregion

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MediaGenre>().HasKey(e => new { e.MediaID, e.GenreID});

            base.OnModelCreating(builder);
        }
    }
}
