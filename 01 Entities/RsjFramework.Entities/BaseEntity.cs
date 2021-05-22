using System.Collections.Generic;

namespace RsjFramework.Entities
{
    public interface IEntity
    {
        //T Id { get; set; }
        IEnumerable<IDomainEvent> Events { get; }
        void AddEvent(IDomainEvent @event);
        void ClearEvents();
    }
    public abstract class BaseEntity
    {
        public IEnumerable<IDomainEvent> Events => _events;

        private readonly List<IDomainEvent> _events = new List<IDomainEvent>();
        public void AddEvent(IDomainEvent @event)
        {
            _events.Add(@event);
        }
        public void ClearEvents()
        {
            _events.Clear();
        }
    }

    public abstract class Entity<T> : BaseEntity, IEntity
    {
        public T Id { get; set; }
    }
}
