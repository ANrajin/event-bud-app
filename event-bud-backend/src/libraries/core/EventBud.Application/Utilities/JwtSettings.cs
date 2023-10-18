namespace EventBud.Application.Utilities;

public sealed class JwtSettings
{
    public const string SectionName = "JwtSettings";

    public string SecretKey { get; init; } = null!;

    public int ExpiryMinute { get; init; } = default;

    public string Issuer { get; init; } = null!;

    public string Audience { get; init; } = null!;
}
