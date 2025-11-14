using Business.Strategy.ETO.Domain.Shared.Services.Entities.Contracts;

namespace Business.Strategy.ETO.Domain.Shared.Services.Entities
{
    public class Error : IError
    {


        public string Code { get; set; }

        public string Message { get; set; }

        public string Layer { get; set; }

        public string ApplicationName { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Errors { get; set; }

        public Error(string code, string message, IEnumerable<KeyValuePair<string, string>> errors = null)
        {
            ValidateCtor(code, message);
            Code = code;
            Message = message;
            Layer = ResultContext.Layer;
            ApplicationName = ResultContext.ApplicationName;
            Errors = errors;
        }

        public Error((string code, string message) error, IEnumerable<KeyValuePair<string, string>> errors = null)
        {
            ValidateCtor(error.code, error.message);
            Code = error.code;
            Message =error.message;
            Layer = ResultContext.Layer;
            ApplicationName = ResultContext.ApplicationName;
            Errors = errors;
        }

        public Error() 
        {
            Code = null;
            Message = null;
            Errors = null;
            Layer = ResultContext.Layer;
            ApplicationName = ResultContext.ApplicationName;
        
        }

        public static void ValidateCtor(string code, string message)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException("code");
            }

            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException("message");
            }

        }

        public override string ToString()
        {
            return "[" + Layer + "]" + ApplicationName + " - " + Code + ": " + Message;
        }
    }
}