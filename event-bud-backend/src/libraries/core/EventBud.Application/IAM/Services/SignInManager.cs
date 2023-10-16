﻿using EventBud.Domain._Shared.IAM.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EventBud.Application.IAM.Services;

public class SignInManager : SignInManager<ApplicationUser>
{
    public SignInManager(
        UserManager<ApplicationUser> userManager,
        IHttpContextAccessor contextAccessor,
        IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory,
        IOptions<IdentityOptions> optionsAccessor,
        ILogger<SignInManager<ApplicationUser>> logger,
        IAuthenticationSchemeProvider schemes)
        : base(
            userManager,
            contextAccessor,
            claimsFactory,
            optionsAccessor,
            logger,
            schemes)
    {
    }
}