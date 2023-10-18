using EventBud.Application.Abstractions.Requests;
using EventBud.Application.Contracts.Services.IdentityAccessManagement;
using EventBud.Domain._Shared.IAM.Models;
using EventBud.Domain._Shared.Results;

namespace EventBud.Application.Features.Auth.Queries.SignIn;

public sealed class SignInQueryHandler : ICommandHandler<SignInQuery, SignInQueryResponse>
{
    private readonly ISignInManagerAdapter<ApplicationUser> _signInManagerAdapter;

    public SignInQueryHandler(
        ISignInManagerAdapter<ApplicationUser> signInManagerAdapter)
    {
        _signInManagerAdapter = signInManagerAdapter;
    }

    public async Task<IResult<SignInQueryResponse>> Handle(SignInQuery request, CancellationToken cancellationToken)
    {

        var response = await _signInManagerAdapter.PasswordSignInAsync(request.UserName, request.Password);

        if (!response.Succeeded)
            return Result.Failure<SignInQueryResponse>(new Error("Authentication Failed", "Invalid username or password given!"));


        return Result.Success<SignInQueryResponse>(new SignInQueryResponse
        {
            Token = "Token"
        });
    }
}
