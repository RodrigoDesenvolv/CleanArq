using System.Runtime.Serialization;

namespace Business.Strategy.ETO.Application.Output.Exceptions
{
    public class ResultNullException : Exception
    {
        public ResultNullException(string message) : base(message) 
        { 
        }

        public ResultNullException(string message, Exception exception) : base(message, exception) 
        { 
        }

        protected ResultNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        { 
        }
    }
}
