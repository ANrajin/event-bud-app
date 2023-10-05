namespace EventBud.Application.Exceptions;

public sealed class ResourceNotFoundException : Exception
{
    public ResourceNotFoundException()
    {
    }

    public ResourceNotFoundException(string message)
        : base(message)
    {
    }
}
