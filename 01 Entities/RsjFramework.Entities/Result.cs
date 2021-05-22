namespace RsjFramework.Entities
{
    public class Result
    {
        public bool IsSuccess { get; }
        public string Error { get; }
        public bool IsFailure => !IsSuccess;

        protected Result(string error, bool isSuccess)
        {
            //if (isSuccess && !string.IsNullOrWhiteSpace(error))
            //{
            //    throw new InvalidOperationException();

            //}
            //if (!isSuccess && string.IsNullOrWhiteSpace(error))
            //{
            //    throw new InvalidOperationException();
            //}
            Error = error;
            IsSuccess = isSuccess;
        }
        public static Result Fail(string message) => new Result(message, false);
        public static Result<T> Fail<T>(string message)
        {
            return
                new Result<T>(default, false, message);
        }
        public static Result Ok()
        {
            return new Result(string.Empty, true);
        }

        public static Result<T> Fail<T>(T value)
        {
            return new Result<T>(value, false, string.Empty);
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value, true, string.Empty);
        }
        public static Result Combine(params Result[] results)
        {
            foreach (var result in results)
            {
                if (result.IsFailure)
                    return result;
            }
            return Ok();
        }
    }

    public class Result<T> : Result
    {
        public T Value { get; }
        protected internal Result(T value, bool isSuccess, string error) : base(error, isSuccess)
        {
            Value = value;
        }
    }
}
