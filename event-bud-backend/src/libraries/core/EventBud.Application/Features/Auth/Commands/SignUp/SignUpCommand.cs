using EventBud.Application.Abstractions.Requests;

namespace EventBud.Application.Features.Auth.Commands.SignUp;

public sealed record SignUpCommand(
    string UserName,
    string Email,
    string Password,
    string ConfirmPassword,
    string Image) : ICommand;
