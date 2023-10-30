using EventBud.Application.Abstractions.Requests;
using EventBud.Application.Contracts.Services.IdentityAccessManagement;
using EventBud.Application.Extensions;
using EventBud.Domain._Shared.IAM.Models;
using EventBud.Domain._Shared.Results;

namespace EventBud.Application.Features.IAM.Queries.SignIn;

public sealed class SignInQueryHandler : ICommandHandler<SignInQuery, SignInQueryResponse>
{
    private readonly IUserManagerAdapter<ApplicationUser> _userManagerAdapter;
    private readonly ISignInManagerAdapter<ApplicationUser> _signInManagerAdapter;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public SignInQueryHandler(
        ISignInManagerAdapter<ApplicationUser> signInManagerAdapter,
        IJwtTokenGenerator jwtTokenGenerator,
        IUserManagerAdapter<ApplicationUser> userManagerAdapter)
    {
        _signInManagerAdapter = signInManagerAdapter;
        _jwtTokenGenerator = jwtTokenGenerator;
        _userManagerAdapter = userManagerAdapter;
    }

    public async Task<IResult<SignInQueryResponse>> Handle(SignInQuery request, CancellationToken cancellationToken)
    {
        var user = request.UserName.IsValidEmail()
            ? await _userManagerAdapter.FindByEmailAsync(request.UserName)
            : await _userManagerAdapter.FindByUserNameAsync(request.UserName);
        
        if (user is null)
            return Result.Failure<SignInQueryResponse>(
                new Error("Authentication Failed", "Invalid username or password!"));
        
        var response = await _signInManagerAdapter.CheckPasswordAsync(user, request.Password, false);
        
        if (!response.Succeeded)
            return Result.Failure<SignInQueryResponse>(
                new Error("Authentication Failed", "Invalid username or password!"));
        
        return Result.Success(new SignInQueryResponse
        {
            Token = _jwtTokenGenerator.GenerateJwtToken(Guid.NewGuid(), user.UserName!, user.Email!)
        });
    }
}
