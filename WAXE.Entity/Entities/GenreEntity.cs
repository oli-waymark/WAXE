using System;
using System.Collections.Generic;
using WAXE.Entity.Entities.Base;

namespace WAXE.Entity.Entities
{
    public class GenreEntity : Entity<Guid>
    {
        public GenreEntity()
        {
            AlbumGenre = new HashSet<AlbumGenreEntity>();
            TrackGenre = new HashSet<TrackGenreEntity>();
        }

        public string Name { get; set; }
        public virtual ICollection<AlbumGenreEntity> AlbumGenre { get; set; }
        public virtual ICollection<TrackGenreEntity> TrackGenre { get; set; }

    }
}
