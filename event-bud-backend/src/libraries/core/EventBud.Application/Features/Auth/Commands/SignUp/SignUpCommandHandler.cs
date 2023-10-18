using EventBud.Application.Abstractions.Requests;
using EventBud.Application.Contracts.Services.IdentityAccessManagement;
using EventBud.Domain._Shared.IAM.Models;
using EventBud.Domain._Shared.Results;

namespace EventBud.Application.Features.Auth.Commands.SignUp;

public sealed class SignUpCommandHandler : ICommandHandler<SignUpCommand, SignUpCommandResponse>
{
    private readonly IUserManagerAdapter<ApplicationUser> _userManager;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public SignUpCommandHandler(
        IUserManagerAdapter<ApplicationUser> userManager, 
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _userManager = userManager;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<IResult<SignUpCommandResponse>> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        var applicationUser = new ApplicationUser
        {
            UserName = request.UserName,
            Email = request.Email,
            NormalizedEmail = request.Email.ToUpperInvariant(),
            NormalizedUserName = request.UserName.ToUpperInvariant(),
        };

        var response = await _userManager.CreateAsync(applicationUser, request.Password);

        if(response.Errors.Any())
        {
            return Result.Failure<SignUpCommandResponse>
                (response.Errors.Select(s => new Error(s.Code, s.Description))
                .ToList());
        }

        var result = new SignUpCommandResponse
        {
            Token = _jwtTokenGenerator.GenerateJwtToken(Guid.NewGuid(), request.UserName, request.Email)
        };

        return Result.Success<SignUpCommandResponse>(result);
    }
}
