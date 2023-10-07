namespace EventBud.Domain._Shared;

public class ErrorResult : Result
{
    internal ErrorResult(bool isSuccess, Error error) 
        : base(isSuccess)
    {
        Error = error;
    }

    public Error Error { get; }
}

public sealed class ErrorResult<T> : ErrorResult, IResult<T>
{
    public T? Data { get; }

    private ErrorResult(bool isSuccess, T? data, Error error) 
        : base(isSuccess, error)
    {
        Data = data;
    }
    
    internal new static ErrorResult<T> Failure(Error error) => new(false, default(T), error);
}
