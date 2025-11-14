using System.Runtime.Serialization;

namespace Business.Strategy.ETO.Application.Output.Exceptions
{
    public class ErrorMessageNullOrEmptyException : Exception
    {
        public ErrorMessageNullOrEmptyException(string message) : base(message)
        {
        }

        public ErrorMessageNullOrEmptyException(string message, Exception exception) : base(message, exception)
        {
        }

        protected ErrorMessageNullOrEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
