using EventBud.Domain.Event.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventBud.Persistence.DBContexts.Configurations.Events;

public sealed class TicketConfigurations : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Inventory)
            .HasDefaultValue(10);
        
        builder.Property(x => x.Price)
            .HasDefaultValue(0);

        builder.Property(x => x.Description)
            .HasDefaultValue(null);
    }
}
