namespace Business.Strategy.ETO.MongoDB.Context.Events.Contracts
{
    public interface IEventCatcher
    {
        void Push(IEvent @event);
        void Push(IEnumerable<IEvent> events);
        IEvent[] Pull(bool clear = false);
    }
}
