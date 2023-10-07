namespace EventBud.Domain._Shared;


public class ValidationResult : Result
{
    internal ValidationResult(bool isSuccess, IReadOnlyCollection<Error> errors) 
        : base(isSuccess)
    {
        Errors = errors;
    }
    
    public IReadOnlyCollection<Error> Errors { get; }
}

public sealed class ValidationResult<T> : ValidationResult, IResult<T>
{
    public T? Data { get; }

    private ValidationResult(bool isSuccess, T? data, IReadOnlyCollection<Error> errors) 
        : base(isSuccess, errors)
    {
        Data = data;
    }
    
    internal new static ValidationResult<T> Failure(IReadOnlyCollection<Error> errors) 
        => new(false, default(T), errors);
}
