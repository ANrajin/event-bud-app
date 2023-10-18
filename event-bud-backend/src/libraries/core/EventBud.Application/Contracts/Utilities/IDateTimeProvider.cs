namespace EventBud.Application.Contracts.Utilities;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
