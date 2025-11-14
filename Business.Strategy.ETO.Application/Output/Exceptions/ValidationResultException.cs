using System.Runtime.Serialization;

namespace Business.Strategy.ETO.Application.Output.Exceptions
{
    public class ValidationResultException : Exception
    {
        public ValidationResultException(string message) : base(message) 
        { 
        }

        public ValidationResultException(string message, Exception exception) : base(message, exception)
        {
        }

        protected ValidationResultException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
