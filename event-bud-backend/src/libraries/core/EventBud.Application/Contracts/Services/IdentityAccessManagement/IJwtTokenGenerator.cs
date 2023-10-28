namespace EventBud.Application.Contracts.Services.IdentityAccessManagement;

public interface IJwtTokenGenerator
{
    string GenerateJwtToken(Guid id, string firstName, string lastName);

    string GenerateJwtRefreshToken();
}
