using Business.Strategy.ETO.MongoDB.Context.Events.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Strategy.ETO.MongoDB.Interceptor
{
    public class CaptureEventsInterceptor : SaveChangeInterceptor
    {
        private readonly IRaiser _raiser;

        public CaptureEventsInterceptor(IRaiser raiser)
        {
            _raiser = raiser;   
        }

        public override async Task<bool> BeforeCommitAsync(IEventCatcher eventCatcher)
        {
            await _raiser.RaiseAsync(eventCatcher.Pull());
            return true;

        }
    }
}
