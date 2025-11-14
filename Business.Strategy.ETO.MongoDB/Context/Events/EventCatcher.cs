using Business.Strategy.ETO.MongoDB.Context.Events.Contracts;
using System.Collections.Concurrent;

namespace Business.Strategy.ETO.MongoDB.Context.Events
{
    public class EventCatcher : IEventCatcher
    {
        private readonly Lazy<ConcurrentQueue<IEvent>> _events;


        public EventCatcher()
        {
            _events = new Lazy<ConcurrentQueue<IEvent>>();    
        }

        public IEvent[] Pull(bool clear = false)
        {
            IEvent[] result = (_events.IsValueCreated ? _events.Value.ToArray() : Array.Empty<IEvent>());
            if (clear && _events.IsValueCreated)
            {
                _events.Value.Clear();
            }

            return result;  
        }

        public void Push(IEvent @event)
        {
            _events.Value.Enqueue(@event);
        }

        public void Push(IEnumerable<IEvent> events)
        {
            foreach (var @event in events)
            { 
                _events.Value.Enqueue(@event);
            }
        }
    }
}
