namespace EventBud.Domain._Shared;

public class Result : IResult
{
    internal Result(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }

    public bool IsSuccess { get; }

    public static IResult Success() => new Result(true);
    public static IResult<T> Success<T>(T data) => Result<T>.Success(data);
    
    public static IResult Failure(Error error) => new ErrorResult(false, error);
    public static IResult<T> Failure<T>(Error error) => ErrorResult<T>.Failure(error);
    
    public static IResult ValidationFailure(IReadOnlyCollection<Error> errors) => new ValidationResult(false, errors);
    public static IResult<T> ValidationFailure<T>(IReadOnlyCollection<Error> errors) => ValidationResult<T>.Failure(errors);
}

public class Result<T> : Result, IResult<T>
{
    public T? Data { get; }

    private Result(bool isSuccess, T? data) 
        : base(isSuccess)
    {
        Data = data;
    }

    internal static Result<T> Success(T data) => new(true, data);
}
