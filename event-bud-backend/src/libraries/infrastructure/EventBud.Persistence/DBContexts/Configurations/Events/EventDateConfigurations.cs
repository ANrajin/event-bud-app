using EventBud.Domain._Commons.ValueComparers;
using EventBud.Domain._Commons.ValueConverters;
using EventBud.Domain.Event.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventBud.Persistence.DBContexts.Configurations.Events;

public sealed class EventDateConfigurations 
    //: IEntityTypeConfiguration<EventDate>
{
    //public void Configure(EntityTypeBuilder<EventDate> builder)
    //{
    //    builder.HasKey(x => x.Id);

    //    builder.Property(x => x.Date)
    //        .HasConversion<DateOnlyConverter, DateOnlyComparer>()
    //        .HasColumnType("date");

    //    builder.Property(x => x.Time)
    //        .HasConversion<TimeOnlyConverter, TimeOnlyComparer>();
    //}
}
