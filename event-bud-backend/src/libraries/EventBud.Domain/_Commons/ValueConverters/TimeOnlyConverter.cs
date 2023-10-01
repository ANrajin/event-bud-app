using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EventBud.Domain._Commons.ValueConverters;

public class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
{
    public TimeOnlyConverter() : base(
        timeOnly => timeOnly.ToTimeSpan(),
        timeSpan => TimeOnly.FromTimeSpan(timeSpan))
    {
        
    }
}
