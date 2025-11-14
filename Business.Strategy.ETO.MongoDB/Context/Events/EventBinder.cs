using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.Strategy.ETO.MongoDB.Context.Events
{
    public class EventBinder
    {
        public EventBinder(Type handlerType, MethodInfo handlerMethod)
        {
            HandlerType = handlerType;
            HandlerMethod = handlerMethod;
        }

        public Type HandlerType { get; }
        public MethodInfo HandlerMethod { get; }

      
    }
}
