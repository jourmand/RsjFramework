using RsjFramework.Contracts;
using RsjFramework.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RsjFramework.ApplicationService
{
    public class DomainEventHandlingExecutor : IDomainEventHandlingExecutor
    {
        private readonly IEventDispatcher _domainEventDispatcher;

        public DomainEventHandlingExecutor(IEventDispatcher domainEventDispatcher)
        {
            _domainEventDispatcher = domainEventDispatcher;
        }

        public void Execute(IEnumerable<IEntity> domainEventEntities)
        {
            foreach (var entity in domainEventEntities)
            {
                var events = entity.Events.ToArray();
                entity.ClearEvents();

                foreach (var @event in events)
                {
                    _domainEventDispatcher.Dispatch(@event);
                }
            }
        }
    }
}
