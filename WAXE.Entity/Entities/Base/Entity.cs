using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WAXE.Entity.Entities.Base
{
    public abstract class Entity<T> : IEntity<T>
    {
        private DateTime? _createdDate;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }

        object IDomain.Id => Id;

        [DataType(DataType.DateTime)]
        public DateTime Created
        {
            get { return _createdDate ?? DateTime.UtcNow; }
            set { _createdDate = value; }
        }

        [DataType(DataType.DateTime)]
        public DateTime? Modified { get; set; }

        public bool IsDeleted { get; set; }
    }
}
