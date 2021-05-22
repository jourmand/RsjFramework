using System.Threading.Tasks;

namespace RsjFramework.Contracts
{
    public interface IUnitOfWork// : IDisposable
    {
        Task SaveAsync();
        void Save();
    }
}