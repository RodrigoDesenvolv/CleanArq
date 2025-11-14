using Business.Strategy.ETO.Domain.Shared.Services.Entities;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Business.Strategy.ETO.Domain.Shared.Services
{
    public struct Result<T>
    {
        [JsonProperty("Error")]
        private Error _error;

        [JsonProperty("Value")]
        private T _value;

        public Error Error
        {
            get
            {
                if (IsSuccess)
                {
                    throw new InvalidOperationException(ResultMessages.ErrorMessageToSuccess);
                }
                return _error;
            }
            private set
            {
                _error = value;
            }
        }
        [JsonProperty]
        public bool IsSuccess { get; private set; }


        [JsonIgnore]
        public T Value
        {
            get
            {
                if (!IsSuccess)
                {
                    throw new InvalidOperationException(ResultMessages.ValueForFailure);
                }

                return _value;
            }
            private set
            {
                _value = value;
            }
        }
        internal Result(bool isSuccess, Error error, T value)
        {
            IsSuccess = isSuccess;
            _error = error;
            _value = value;
        }
    }

    public struct Result
    {

        [JsonProperty("Error")]
        private Error _error;


        [JsonIgnore]
        public Error Error
        {
            get
            {
                if (IsSuccess)
                {
                    throw new InvalidOperationException(ResultMessages.ErrorMessageToSuccess);
                }
                return _error;
            }
            private set
            {
                _error = value;
            }
        }

        [JsonProperty]
        public bool IsSuccess { get; private set; }

        public Result(bool isSuccess, Error error)
        {
            IsSuccess = isSuccess;
            _error = error;
        }

        public Result(string code, string message)
        {
            IsSuccess = false;
            _error = new Error(code, message);
        }

        public Result((string code, string message) error)
        {
            IsSuccess = false;
            _error = new Error(error.code, error.message);
        }


        [DebuggerStepThrough]
        public static Result Ok()
        {
            return new Result(isSuccess: true, default(Error));
        }

        [DebuggerStepThrough]
        public static Result Fail(string code, string message)
        {
            return new Result(code, message);
        }

        [DebuggerStepThrough]
        public static Result Fail((string, string) item)
        {
            return Fail(item.ToTuple());

        }

        [DebuggerStepThrough]
        public static Result Fail(Tuple<string, string> item)
        {
            return new Result(item.Item1, item.Item2);
        }

        [DebuggerStepThrough]
        public static Result Fail(Error error)
        {
            return new Result(isSuccess: false, error);
        }

        [DebuggerStepThrough]
        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(isSuccess: true, default(Error), value);
        }

        [DebuggerStepThrough]
        public static Result<T> Fail<T>(string code, string message)
        {
            return new Result<T>(isSuccess: false, new Error(code, message), default(T));
        }

        [DebuggerStepThrough]
        public static Result<T> Fail<T>((string, string) item)
        {
            return Fail<T>(item.ToTuple());
        }

        [DebuggerStepThrough]
        public static Result<T> Fail<T>(Tuple<string, string> item)
        {

            return new Result<T>(isSuccess: false, new Error(item.Item1, item.Item2), default(T));
        }

        [DebuggerStepThrough]
        public static Result<T> Fail<T>(Error error)
        {
            return new Result<T>(isSuccess: false, error, default(T));
        }

    }
}
