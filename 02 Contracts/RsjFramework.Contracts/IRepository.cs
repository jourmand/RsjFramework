using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using RsjFramework.Entities;

namespace RsjFramework.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        //T GetById(int id);
        T GetSingleBySpec(ISpecification<T> spec);
        IList<T> ListAll();
        IList<T> List(ISpecification<T> spec);
        T Add(T entity);
        void Update(T entity, params Expression<Func<T, object>>[] updatedProperties);
        void Delete(T entity);
        void AddList(IEnumerable<T> entity);
        T GetSingleBySpec(Expression<Func<T, bool>> criteria);
    }
}