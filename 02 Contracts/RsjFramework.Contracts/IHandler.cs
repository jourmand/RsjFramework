using RsjFramework.Entities;

namespace RsjFramework.Contracts
{
    public interface IHandler<in T> where T : IDomainEvent
    {
        void Handle(T @event);
    }
}
