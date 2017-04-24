using System;
using System.Collections.Generic;
using WAXE.Entity.Entities.Base;

namespace WAXE.Entity.Entities
{
    public class TrackEntity : Entity<Guid>
    {
        public TrackEntity()
        {
            Genre = new HashSet<TrackGenreEntity>();
            Artist = new HashSet<ArtistTrackEntity>();
        }
        public string Name { get; set; }
        public string Number { get; set; }
        public AlbumEntity Album { get; set; }
        public decimal BPM { get; set; }
        public int Rating { get; set; }
        public virtual ICollection<TrackGenreEntity> Genre { get; set; }

        public virtual  ICollection<ArtistTrackEntity> Artist { get; set; }

    }
}
