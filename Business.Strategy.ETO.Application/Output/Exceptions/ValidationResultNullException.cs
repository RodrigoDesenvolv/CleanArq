using System.Runtime.Serialization;

namespace Business.Strategy.ETO.Application.Output.Exceptions
{
    [Serializable]
    public class ValidationResultNullException : Exception
    {
        public ValidationResultNullException(string message) : base(message)
        {
        }

        public ValidationResultNullException(string message, Exception exception) : base(message, exception)
        {
        }

        protected ValidationResultNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}