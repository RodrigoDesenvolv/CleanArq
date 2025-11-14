using Business.Strategy.ETO.Application.Output.Constants;
using Business.Strategy.ETO.Application.Output.Exceptions;
using FluentValidation.Results;

namespace Business.Strategy.ETO.Application.Output
{
    public class Response<T> where T : notnull
    {
        private readonly List<string> _messages;
        private readonly List<string> _errorsMessages;
        private readonly Dictionary<int, string> _errorCodeMessages;

        public Response(T result, bool isSuccess = true)
        {
            IsSuccess = isSuccess;
            _messages = new List<string>();
            _errorsMessages = new List<string>();
            _errorCodeMessages = new Dictionary<int, string>();

            AddResult(result);
        }

        public Response(ValidationResult validationResult)
        {
            _messages = new List<string>();
            _errorsMessages = new List<string>();
            _errorCodeMessages = new Dictionary<int, string>();

            ProccessValidationResults(validationResult);
        }

        public Response(IEnumerable<ValidationResult> validationResults)

        {
            _messages = new List<string>();
            _errorsMessages = new List<string>();
            _errorCodeMessages = new Dictionary<int, string>();

            ProccessValidationResults(validationResults.ToArray());

        }

        public Response(IEnumerable<string> messages, bool isSuccess)
        {
            _messages = new List<string>();
            _errorsMessages = new List<string>();
            _errorCodeMessages = new Dictionary<int, string>();

            ProcessMessageResults(messages);
        }

        public Response(IReadOnlyDictionary<int, string> errorCodeMessages)
        {
            _messages = new List<string>();
            _errorsMessages = new List<string>();
            _errorCodeMessages = new Dictionary<int, string>();

            AddErrorCodeMessages(errorCodeMessages);
        }

        public void AddErrorCodeMessages(IReadOnlyDictionary<int, string> errorCodeMessages)
        {
            foreach (var kvp in errorCodeMessages)
            {
                AddErrorCodeMessage(kvp.Key, kvp.Value);

            }

        }

        public void AddMessages(params string[] messages)
        {
            foreach(var message in messages)
            {
                VerifyMessage(message);
            }
        }

        public void AddErrorMessages(params string[] messages)
        {
            foreach (var message in messages)
            {
                VerifyErrorMessage(message);
                _errorsMessages.Add(message);
            }
            VerifyValidity();
        }

        private void VerifyMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ErrorMessageNullOrEmptyException(ResponseConstants.ErrorMessageIsNullOrEmptyMessage);
            }
        }

        private void AddErrorCodeMessage(int errorCode, string errorMessage)
        {
            VerifyErrorMessage(errorMessage);
            _errorCodeMessages.Add(errorCode, errorMessage);
            VerifyValidity();
        }

        private static void VerifyErrorMessage(string errorMessage)
        {
            if (string.IsNullOrEmpty(errorMessage))
            {
                throw new ErrorMessageNullOrEmptyException(ResponseConstants.ErrorMessageIsNullOrEmptyMessage); 
            }
        }

        private void ProcessMessageResults(IEnumerable<string> messages)
        {
            if (IsSuccess)
            {
                _messages.AddRange(messages);
                return;
            }

            _errorsMessages.AddRange(messages);
        }

        public bool IsSuccess { get; private set; }
        public T Result { get; private set; }
        public void AddResult(T result) => Result = result ?? throw new ResultNullException(ResponseConstants.ResultNullMessage);
        public virtual IReadOnlyCollection<string>? ErrorMessages => _errorsMessages?.AsReadOnly();

        public virtual IReadOnlyCollection<string>? Messages => _messages?.AsReadOnly();
        public virtual IReadOnlyDictionary<int, string>? ErrorCodeMessages => _errorCodeMessages;

        private void ProccessValidationResults(params ValidationResult[] validationResults)
        {
            foreach (var validationResult in validationResults)
            {
                CheckValidationResult(validationResult);
                AddValidationResult(validationResult);
            }

            VerifyValidity();
        }

        private void VerifyValidity() => IsSuccess = (ErrorMessages?.Count == 0 && ErrorCodeMessages?.Count == 0);

        public void AddValidationResult(ValidationResult validationResult)
        {
            IsSuccess = validationResult.IsValid;
            VerifyErrorMessages(validationResult);
        }

        private void VerifyErrorMessages(ValidationResult validationResult)
        {
            _errorsMessages.AddRange(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
        }

        private static void CheckValidationResult(ValidationResult validationResult)
        {
            if (validationResult == null)
            {
                throw new ValidationResultException(ResponseConstants.ValidationResultNullMessage);
            }
        }
    }

    public class Response : Response<object>
    {
        public Response(ValidationResult validationResult) : base(validationResult)
        {
        }

        public Response(IEnumerable<ValidationResult> validationResults) : base(validationResults)
        {
        }

        public Response(IReadOnlyDictionary<int, string> errorCodeMessages) : base(errorCodeMessages)
        {
        }

        public Response(object result, bool isSuccess = true) : base(result, isSuccess)
        {
        }

        public Response(IEnumerable<string> messages, bool isSuccess) : base(messages, isSuccess)
        {
        }

        public T GetResult<T>() => (T)Result;
    }
}
