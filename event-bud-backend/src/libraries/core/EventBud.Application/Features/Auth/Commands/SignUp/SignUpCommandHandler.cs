﻿using EventBud.Application.Abstractions.Requests;
using EventBud.Application.IAM.Contracts;
using EventBud.Domain._Shared.IAM.Models;
using EventBud.Domain._Shared.Results;

namespace EventBud.Application.Features.Auth.Commands.SignUp;

public sealed class SignUpCommandHandler : ICommandHandler<SignUpCommand>
{
    private readonly IUserManagerAdapter<ApplicationUser> _userManager;

    public SignUpCommandHandler(IUserManagerAdapter<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IResult> Handle(SignUpCommand request, CancellationToken cancellationToken)
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
            return Result.Failure(response.Errors.Select(s => new Error(s.Code, s.Description)).ToList());
        }

        return Result.Success();
    }
}
