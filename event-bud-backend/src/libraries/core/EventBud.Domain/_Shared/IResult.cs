namespace EventBud.Domain._Shared;

public interface IResult
{
    bool IsSuccess { get; }
    string Type { get; }
    IReadOnlyCollection<Error> Errors { get; }
}

public interface IResult<out T> : IResult
{
    T? Data { get; }
}
