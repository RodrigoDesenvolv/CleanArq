using Business.Strategy.ETO.MongoDB.Context.Events.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Concurrent;

namespace Business.Strategy.ETO.MongoDB.Context.Events
{
    public sealed class Raiser : IRaiser
    {
        private static readonly ConcurrentDictionary<string, EventBinder> s_handlersType = new ConcurrentDictionary<string, EventBinder>();
        private readonly IServiceProvider _serviceProvider;

        public Raiser(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        public async Task RaiseAsync(IEvent @event)
        {
            if (@event is null)
            {
                return;
            }

            Type eventType = @event.GetType();
            EventBinder eventBinder = s_handlersType.GetOrAdd(eventType.Name, delegate
            {
                Type type = typeof(IEventHandler<>).MakeGenericType(eventType);
                return new EventBinder(type,type.GetMethod("HandleAsync",[eventType]));
            });
            IEnumerable<object> services = _serviceProvider.GetServices(eventBinder.HandlerType);
            if (services != null && services.Any())
            {
                await Task.WhenAll(services.Select((object p) => eventBinder.HandlerMethod.Invoke(p, new object[1] {@event})).Cast<Task>());
            }

        }

        public async Task RaiseAsync(IEnumerable<IEvent> events)
        {
            foreach (IEvent @event in events)
            {
                await RaiseAsync(@event);
            }
        }
    }
}
