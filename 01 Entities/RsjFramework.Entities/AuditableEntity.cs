using System;

namespace RsjFramework.Entities
{
    public class AuditableEntity<T> : Entity<T>, IAuditableEntity
    {
        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }
    }
}
