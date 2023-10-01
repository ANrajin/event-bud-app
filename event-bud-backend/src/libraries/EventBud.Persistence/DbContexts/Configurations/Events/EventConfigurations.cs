using EventBud.Domain.Event.Aggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventBud.Persistence.DBContexts.Configurations.Events;

public sealed class EventConfigurations : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Capacity)
            .HasDefaultValue(10);

        builder.OwnsOne(x => x.EventLocation, x =>
        {
            x.Property(y => y.Location)
                .HasColumnName("Location")
                .HasMaxLength(500);

            x.Property(y => y.Street)
                .HasColumnName("Street")
                .HasMaxLength(255);

            x.Property(y => y.City)
                .HasColumnName("City")
                .HasMaxLength(255);

            x.Property(y => y.State)
                .HasColumnName("State")
                .HasMaxLength(255);

            x.Property(y => y.Zip)
                .HasColumnName("Zip")
                .HasMaxLength(10);

            x.Property(y => y.Country)
                .HasColumnName("Country")
                .HasMaxLength(255);
        });

        builder.HasMany(x => x.Tickets)
            .WithOne(x => x.Event)
            .HasForeignKey(x => x.EventId)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.EventDates)
            .WithOne(x => x.Event)
            .HasForeignKey(x => x.EventId)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
