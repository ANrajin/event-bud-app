namespace EventBud.Application.Contracts.Services.IdentityAccessManagement;

public interface IJwtTokenGenerator
{
    string GenerateJwtToken(Guid id, string userName, string email);

    string GenerateJwtRefreshToken();
}
