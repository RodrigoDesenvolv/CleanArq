using Business.Strategy.ETO.MongoDB.Context.Events.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Strategy.ETO.MongoDB.Interceptor
{
    public abstract class SaveChangeInterceptor : IDataInterceptor
    {
        public virtual Task<bool> BeforeCommitAsync(IEventCatcher eventCatcher)
        {
            return Task.FromResult(result: true);
        }
    }
}
