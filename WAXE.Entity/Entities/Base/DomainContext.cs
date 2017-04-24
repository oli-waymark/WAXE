using Microsoft.EntityFrameworkCore;

namespace WAXE.Entity.Entities.Base
{
    public class DomainContext : DbContext
    {
        public DbSet<ArtistEntity> Artists { get; set; }

        public DbSet<AlbumEntity> Albums { get; set; }

        public DbSet<TrackEntity> Tracks { get; set; }

        public DbSet<RecordLabelEntity> RecordLabels { get; set; }

        public DbSet<GenreEntity> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlbumGenreEntity>().HasKey(x => new {x.AlbumEntityId, x.GenreEntityId});
            modelBuilder.Entity<TrackGenreEntity>().HasKey(x => new {x.TracksId, x.GenreId});
            modelBuilder.Entity<ArtistAlbumEntity>().HasKey(x => new {x.AlbumId, x.ArtistId});
            modelBuilder.Entity<ArtistRecordLabelEntity>().HasKey(x => new {x.ArtistId, x.RecordLabelId});
            modelBuilder.Entity<ArtistTrackEntity>().HasKey(x => new {x.ArtistId, x.TrackId});
        }
    }
}
