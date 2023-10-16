using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EventBud.Domain._Shared.ValueComparers;

public class DateOnlyComparer : ValueComparer<DateOnly>
{
    public DateOnlyComparer() : base(
        (x, y) => x.DayNumber == y.DayNumber,
        dateOnly => dateOnly.GetHashCode())
    { }
}
