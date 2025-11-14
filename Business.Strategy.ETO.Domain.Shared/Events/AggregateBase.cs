namespace Business.Strategy.ETO.Domain.Shared.Events
{
    public class AggregateBase<TKey> : EntityBase<TKey>, IAggregate<TKey> where TKey : struct
    {
        private readonly Lazy<List<IEvent>> _domainEvents = new Lazy<List<IEvent>>();

        public IEnumerable<IEvent> Events => _domainEvents.IsValueCreated ? _domainEvents.Value.ToArray() : Array.Empty<IEvent>();

        public void ClearEvents()
        {
            if (_domainEvents.IsValueCreated)
                _domainEvents.Value.Clear();

        }

        protected void Emit(IEvent domainEvent)
        {
            if (domainEvent is null) return;
            _domainEvents.Value.Add(domainEvent);
        }
    }
}
