//using Microsoft.EntityFrameworkCore;
//using RsjFramework.Contracts;
//using System.Threading.Tasks;

//namespace RsjFramework.ApplicationService
//{
//    public class UnitOfWork<T> : IUnitOfWork where T : DbContext
//    {
//        private readonly T _dbContext;

//        public UnitOfWork(T dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public async Task SaveAsync()
//        {
//            await _dbContext.SaveChangesAsync();
//        }
//        public void Save()
//        {
//            _dbContext.SaveChanges();
//        }

//        //public void Dispose()
//        //{
//        //    Dispose(true);
//        //    GC.SuppressFinalize(this);
//        //}

//        //private void Dispose(bool disposing)
//        //{
//        //    if (!disposing) return;
//        //    if (_dbContext == null) return;
//        //    _dbContext.Dispose();
//        //    _dbContext = null;
//        //}
//    }
//}
