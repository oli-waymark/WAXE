using System;
using System.Collections.Generic;
using WAXE.Entity.Entities.Base;

namespace WAXE.Entity.Entities
{
    public class AlbumEntity : Entity<Guid>
    {
        public AlbumEntity()
        {
            Tracks = new HashSet<TrackEntity>();
            Artists = new HashSet<ArtistAlbumEntity>();
            AlbumGenre = new HashSet<AlbumGenreEntity>();
        } 

        public string Name { get; set; }
        public int ReleaseDate { get; set; }
        public Guid RecordLabelId { get; set; }
        public RecordLabelEntity RecordLabel { get; set; }
        public virtual ImageData ImageData { get; set; }
        public ICollection<AlbumGenreEntity> AlbumGenre { get; set; }
        public virtual ICollection<ArtistAlbumEntity> Artists { get; set; }
        public virtual ICollection<TrackEntity> Tracks { get; set; }

    }
}
