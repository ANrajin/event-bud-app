namespace EventBud.Domain._Shared.Results;

public class Result : IResult
{
    internal Result(
        bool isSuccess,
        ResultType type,
        IReadOnlyCollection<Error> errors
        )
    {
        Succeeded = isSuccess;
        Errors = errors;
        Type = type.ToString();
    }

    public bool Succeeded { get; }
    public string Type { get; }
    public IReadOnlyCollection<Error> Errors { get; }


    public static IResult Success() => new Result(true, ResultType.Success, new List<Error>());
    public static IResult<T> Success<T>(T data) => Result<T>.Success(data);

    public static IResult Failure(Error error) =>
        new Result(false, ResultType.ServerError, new List<Error> { error });
    public static IResult<T> Failure<T>(Error error) => Result<T>.Failure(error);

    public static IResult Failure(IReadOnlyCollection<Error> errors) =>
        new Result(false, ResultType.ValidationError, errors);
    public static IResult<T> Failure<T>(IReadOnlyCollection<Error> errors)
        => Result<T>.Failure(errors);
}

public class Result<T> : Result, IResult<T>
{
    public T? Data { get; }
    
    private Result(
        bool isSuccess, 
        ResultType type, 
        IReadOnlyCollection<Error> errors, 
        T? data)
        : base(isSuccess, type, errors)
    {
        Data = data;
    }

    internal static Result<T> Success(T data) => 
        new(true, ResultType.Success, new List<Error>(), data);
    
    internal new static Result<T> Failure(Error error) =>
        new(false, ResultType.ServerError, new List<Error> { error }, default);
    
    internal new static Result<T> Failure(IReadOnlyCollection<Error> errors)
        => new(false, ResultType.ValidationError, errors, default);
}
