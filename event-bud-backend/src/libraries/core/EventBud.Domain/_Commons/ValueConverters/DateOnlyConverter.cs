using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EventBud.Domain._Commons.ValueConverters;

public sealed class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    public DateOnlyConverter() : base(
        dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
        dateTime => DateOnly.FromDateTime(dateTime))
    {
        
    }
}
