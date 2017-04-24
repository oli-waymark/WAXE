using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAXE.Entity.Entities
{
    public class TrackGenreEntity 
    {
        public Guid TracksId { get; set; }
        public TrackEntity Track { get; set; }

        public Guid GenreId { get; set; }
        public GenreEntity Genre { get; set; }
    }
}
