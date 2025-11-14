using Business.Strategy.ETO.Application.Output.Constants;
using Business.Strategy.ETO.Application.Output.Exceptions;
using FluentValidation.Results;

namespace Business.Strategy.ETO.Application.Output
{
    public class Output<T> where T : notnull
    {
        public bool IsValid { get; protected set; }

        protected T _result;
        private List<string > _errorMessages;
        private List<string> _messages;
        private List<string> _errorsMessages;

        public Output(bool isValid = true) => IsValid = isValid;

        public Output(T result)
        {
            IsValid = true;
            AddResult(result);
        }

        public IReadOnlyCollection<string> ErrorMessages => GetMessages(_errorMessages);
        public IReadOnlyCollection<string> Messages => GetMessages(_messages);

        private IReadOnlyCollection<string> GetMessages(List<string> errorMessages)
        {
            if (errorMessages == null)
            {
                return Array.Empty<string>();
            }

            return errorMessages.AsReadOnly();
        }

        public Output(ValidationResult validationResult)
        {
            ProccessValidationResults(validationResult);

        }

        public Output(IEnumerable<ValidationResult> validationResults)
        {
            ProccessValidationResults(validationResults.ToArray());

        }

        public void ProccessValidationResults(params ValidationResult[] validationResult)
        {
            foreach (ValidationResult validationResultItem in validationResult)
            {
                CheckValidationResult(validationResultItem);
                AddValidationResult(validationResultItem);

            }
            VerifyValidity();
        }

        private void VerifyValidity()
        {
            if (_errorsMessages == null)
            { IsValid = true; } else { IsValid = ErrorMessages.Count == 0; }
        }

        private void AddValidationResult(ValidationResult validationResultItem)
        {
            CheckValidationResult(validationResultItem);
            IsValid = validationResultItem.IsValid;
            VerifyErrorMessages(validationResultItem);
        }

        public void AddMessage(string message) => AddMessages(message);

        private void AddMessages(params string[] messages)
        {
            CreateMessagesWhenThereIsNone();

            foreach (var message in messages)
            {
                VerifyMessage(message);

            }
        }

        private void VerifyMessage(string message)
        {
            if (string.IsNullOrEmpty(message)) { throw new ErrorMessageNullOrEmptyException(ResponseConstants.MessagesIsNullOrEmptyMessage); }
        }

        private void CreateMessagesWhenThereIsNone()
        {
            _messages ??= new List<string>();
        }

        private void VerifyErrorMessages(ValidationResult validationResultItem)
        {
            CreateErrorMessagesWhenThereIsNone();
            _errorMessages.AddRange(validationResultItem.Errors.Select(x => x.ErrorMessage).ToList());
        }

        private void CreateErrorMessagesWhenThereIsNone()
        {
            _errorMessages ??= new List<string>();
        }

        private void CheckValidationResult(ValidationResult validationResultItem)
        {
            if (validationResultItem == null)
            { 
                throw new ValidationResultNullException(ResponseConstants.ValidationResultNullMessage);
            }
        }

        public void AddResult(T result) => _result = result ?? throw new ResultNullException(ResponseConstants.ResultNullMessage);

        public T GetResult() => _result;
    }

    public class Output : Output<object>
    {

        public Output() : base() { }

        public Output(bool isValid = true) : base(isValid) { }

        public Output(ValidationResult validationResult) : base(validationResult) { }

        public Output(IEnumerable<ValidationResult> validationResults) : base(validationResults) { }

        public Output(object result) : base(result) { }

        public new void AddResult(object result) => _result = result ?? throw new ResultNullException(ResponseConstants.ResultNullMessage);

        public T GetResult<T>() => (T)_result;

    }
}
