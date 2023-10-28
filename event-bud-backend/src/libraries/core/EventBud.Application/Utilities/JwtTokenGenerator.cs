using EventBud.Application.Contracts.Services.IdentityAccessManagement;
using EventBud.Application.Contracts.Utilities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EventBud.Application.Utilities;

public sealed class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;
    private readonly IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, 
        IOptions<JwtSettings> jwtSettings)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtSettings.Value;
    }

    public string GenerateJwtToken(Guid id, string userName, string email)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var signInCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userName),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, id.ToString()),
        };

        var securityTokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinute),
            SigningCredentials = signInCredentials,
            Subject = new ClaimsIdentity(claims),
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience,
        };

        var token = tokenHandler.CreateToken(securityTokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public string GenerateJwtRefreshToken()
    {
        throw new NotImplementedException();
    }
}
