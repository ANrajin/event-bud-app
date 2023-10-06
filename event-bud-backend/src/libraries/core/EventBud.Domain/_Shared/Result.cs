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

    
    public static IResult Failure() => new Result(false);
    public static IResult<T> Failure<T>(T data) => Result<T>.Failure(data);
}

public class Result<T> : Result, IResult<T>
{
    public T Data { get; }

    private Result(bool isSuccess, T data) 
        : base(isSuccess)
    {
        Data = data;
    }

    internal static Result<T> Success(T data) => new Result<T>(true, data);

    internal static Result<T> Failure(T data) => new Result<T>(false, data);
}
