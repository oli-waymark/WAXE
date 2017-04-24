using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WAXE.Entity.Entities
{
    public class AlbumGenreEntity
    {
        public Guid AlbumEntityId { get; set; }
        public AlbumEntity Album { get; set; }

        public Guid GenreEntityId { get; set; }
        public GenreEntity Genre { get; set; }

    }
}
