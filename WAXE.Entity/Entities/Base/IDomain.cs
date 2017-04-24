using System;

namespace WAXE.Entity.Entities.Base
{
    public interface IDomain
    {
        object Id { get; }
        DateTime Created { get; set; }
        DateTime? Modified { get; set; }
        bool IsDeleted { get; set; }
    }
}
