using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EventBud.Domain._Shared.ValueComparers;

public class TimeOnlyComparer : ValueComparer<TimeOnly>
{
    public TimeOnlyComparer() : base(
        (x, y) => x.Ticks == y.Ticks,
        timeOnly => timeOnly.GetHashCode())
    { }
}
