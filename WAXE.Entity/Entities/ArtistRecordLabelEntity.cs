using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAXE.Entity.Entities
{
    public class ArtistRecordLabelEntity
    {
        public Guid ArtistId { get; set; }
        public ArtistEntity Artist { get; set; }
        public Guid RecordLabelId { get; set; }
        public RecordLabelEntity RecordLabel { get; set; }
    }
}
