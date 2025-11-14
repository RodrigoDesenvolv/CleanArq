using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Strategy.ETO.MongoDB.Context.Events.Contracts
{
    public interface IRaiser
    {
        Task RaiseAsync(IEvent @event);
        Task RaiseAsync(IEnumerable<IEvent> events);

    }
}
