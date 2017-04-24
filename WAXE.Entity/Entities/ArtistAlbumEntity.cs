using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAXE.Entity.Entities
{
    public class ArtistAlbumEntity
    {
        public Guid ArtistId { get; set; }
        public ArtistEntity Artist { get; set; }

        public Guid AlbumId { get; set; }
        public AlbumEntity Album { get; set; }

    }
}
