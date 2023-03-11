using AwesomeShop.Domain.Events;

namespace AwesomeShop.Domain.Entities
{
    public class AggregateRoot : IEntityBase
    {
        private List<IDomainEvent> _events = new List<IDomainEvent>();
        public Guid Id {get; protected set; }

        public IEnumerable<IDomainEvent> Events => _events;

        protected void AddEvent(IDomainEvent @event)
        {
            if(@event is null)
                _events = new List<IDomainEvent>();

            _events.Add(@event);
        }
    }
}
