using System;
using System.Collections.Generic;
using WAXE.Entity.Entities.Base;

namespace WAXE.Entity.Entities
{
    public class RecordLabelEntity : Entity<Guid>
    {
        public RecordLabelEntity()
        {
            Albums = new HashSet<AlbumEntity>();
            Artists = new HashSet<ArtistRecordLabelEntity>();
        }

        public string Name { get; set; }
        public string Country { get; set; }
        public ICollection<AlbumEntity> Albums { get; set; }
        public ICollection<ArtistRecordLabelEntity> Artists { get; set; }
    }
}
