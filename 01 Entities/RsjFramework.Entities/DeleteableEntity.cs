using System;

namespace RsjFramework.Entities
{
    public class DeleteableEntity<T> : Entity<T>, IDeleteableEntity
    {
        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public bool IsDeleted { get; set; }
    }
}
