using RsjFramework.Entities;

namespace RsjFramework.Contracts
{
    public interface IEventDispatcher
    {
        void Dispatch<TEvent>(TEvent eventToDispatch) where TEvent : IDomainEvent;
    }
}
