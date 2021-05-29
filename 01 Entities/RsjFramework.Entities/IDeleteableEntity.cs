using System;

namespace RsjFramework.Entities
{
    public interface IDeleteableEntity
    {
        string CreatedBy { get; set; }
        DateTime Created { get; set; }
        string LastModifiedBy { get; set; }
        DateTime? LastModified { get; set; }
        bool IsDeleted { get; set; }
    }
}