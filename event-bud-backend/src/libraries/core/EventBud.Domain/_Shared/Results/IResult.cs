namespace EventBud.Domain._Shared.Results;

public interface IResult
{
    bool Succeeded { get; }
    string Type { get; }
    IReadOnlyCollection<Error> Errors { get; }
}

public interface IResult<out T> : IResult
{
    T? Data { get; }
}
