using EventBud.Domain._Shared.IAM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventBud.Persistence.DBContexts.Configurations.IAM;

public class RefreshTokenConfigurations : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("RefreshTokens");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.Token).IsRequired();
        builder.Property(x => x.JwtId).IsRequired();
        builder.Property(x => x.ExpiredAt).IsRequired();
        builder.Property(x => x.IsUsed).HasDefaultValue(false);
        builder.Property(x => x.IsRevoked).HasDefaultValue(false);

        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}