using System;

namespace RsjFramework.Entities
{
    public interface IAuditableEntity
    {
        string CreatedBy { get; set; }
        DateTime Created { get; set; }
        string LastModifiedBy { get; set; }
        DateTime? LastModified { get; set; }
    }
}