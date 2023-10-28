namespace EventBud.Application.Features.Auth.Queries.SignIn;

public sealed class SignInQueryResponse
{
    public string Token { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;
}
