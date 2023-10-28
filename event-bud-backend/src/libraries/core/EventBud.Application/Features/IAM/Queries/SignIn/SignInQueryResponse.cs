namespace EventBud.Application.Features.IAM.Queries.SignIn;

public sealed class SignInQueryResponse
{
    public string Token { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;
}
