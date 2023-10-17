using EventBud.Application.IAM.Contracts;
using EventBud.Application.IAM.Services;
using EventBud.Domain._Shared.IAM.Models;
using Microsoft.AspNetCore.Identity;

namespace EventBud.Application.IAM.Adapters;

public sealed class SignInManagerAdapter : ISignInManagerAdapter<ApplicationUser>
{
    private readonly SignInManager _signInManager;

    public SignInManagerAdapter(SignInManager signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task<SignInResult> PasswordSignInAsync(string userName, string password)
    {
        return await _signInManager.PasswordSignInAsync(userName, password, false, false);
    }

    public async Task SignOutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}
