using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAXE.Entity.Entities
{
    public class ArtistTrackEntity
    {
        public Guid ArtistId { get; set; }
        public ArtistEntity Artist { get; set; }

        public Guid TrackId { get; set; }
        public TrackEntity Track { get; set; }
    }
}
