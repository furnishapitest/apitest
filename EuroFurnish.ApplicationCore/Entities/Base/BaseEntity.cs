using System;

namespace EuroFurnish.ApplicationCore.Entities.Base
{
    public abstract class BaseEntity : BaseIdEntity,IAuditEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
