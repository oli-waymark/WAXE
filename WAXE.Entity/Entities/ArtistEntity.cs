using System;
using System.Collections.Generic;
using WAXE.Entity.Entities.Base;

namespace WAXE.Entity.Entities
{
    public class ArtistEntity : Entity<Guid>
    {
        public ArtistEntity()
        {
            Tracks = new HashSet<ArtistTrackEntity>();
            Albums = new HashSet<ArtistAlbumEntity>();
            RecordLabels = new HashSet<ArtistRecordLabelEntity>();
        }

        public string Name { get; set; }
        public virtual ICollection<ArtistAlbumEntity> Albums { get; set; }
        public virtual ICollection<ArtistRecordLabelEntity> RecordLabels { get; set; }
        public virtual ICollection<ArtistTrackEntity> Tracks { get; set; }

    }
}
