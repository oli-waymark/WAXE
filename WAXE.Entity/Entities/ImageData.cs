using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WAXE.Entity.Entities.Base;

namespace WAXE.Entity.Entities
{
    public class ImageData : Entity<Guid>
    {
            public string Extension { get; set; }
            public byte[] ImageBytes { get; set; }
            public byte[] SmallImageBytes { get; set; }
    }
}
