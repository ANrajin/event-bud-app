namespace EventBud.Domain._Shared.Results;

public sealed class Error
{
    public Error(string title, string message)
    {
        Title = title;
        Message = message;
    }

    public string Title { get; }
    public string Message { get; }
}
