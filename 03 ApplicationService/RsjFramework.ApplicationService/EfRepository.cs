using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RsjFramework.Contracts;
using RsjFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RsjFramework.ApplicationService
{
    public class EfRepository<T, Y> : IUseCaseRepository, IRepository<T>, IAsyncRepository<T> where T : BaseEntity where Y : DbContext
    {
        protected readonly Y DbContext;
        private DbSet<T> DbSet { get; }

        public EfRepository(Y dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<T>();
        }

        public T GetSingleBySpec(ISpecification<T> spec)
        {
            return List(spec).FirstOrDefault();
        }
        public T GetSingleBySpec(Expression<Func<T, bool>> criteria)
        {
            return DbSet.FirstOrDefault(criteria);
        }

        public IList<T> ListAll()
        {
            return DbSet.AsNoTracking().ToList();
        }

        public async Task<IList<T>> ListAllAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public IList<T> List(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(DbSet.AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return secondaryResult
                .Where(spec.Criteria)
                .AsNoTracking()
                .ToList();
        }
        public async Task<IList<T>> ListAsync(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(DbSet.AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return await secondaryResult
                .Where(spec.Criteria)
                .AsNoTracking()
                .ToListAsync();
        }

        public T Add(T entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public void Update(T entity, params Expression<Func<T, object>>[] updatedProperties)
        {
            //var dbEntityEntry = DbContext.Entry(entity);
            //if (updatedProperties.Any())
            //{
            //    foreach (var property in updatedProperties)
            //    {
            //        dbEntityEntry.Property(property).IsModified = true;
            //    }
            //}
            //else
            //{
            //    //no items mentioned, so find out the updated entries
            //    foreach (var property in dbEntityEntry.OriginalValues.Properties)
            //    {
            //        var original = dbEntityEntry.OriginalValues[property.Name];
            //        var current = dbEntityEntry.CurrentValues[property.Name];
            //        if (original != null && !original.Equals(current))
            //            dbEntityEntry.Property(property.Name).IsModified = true;
            //    }
            //}
            DbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public Task AddListAsync(IEnumerable<T> entity)
        {
            return DbSet.AddRangeAsync(entity);
        }
        public void AddList(IEnumerable<T> entity)
        {
            DbSet.AddRange(entity);
        }
        public IDbContextTransaction BeginTransaction()
        {
            return DbContext.Database.BeginTransaction();
        }
    }
}
