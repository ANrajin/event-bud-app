using EventBud.Application.Contracts.Utilities;

namespace EventBud.Application.Utilities;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
