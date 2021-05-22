using RsjFramework.Entities;
using System.Collections.Generic;

namespace RsjFramework.Contracts
{
    public interface IDomainEventHandlingExecutor
    {
        void Execute(IEnumerable<IEntity> domainEventEntities);
    }
}
