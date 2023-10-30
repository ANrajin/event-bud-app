using EventBud.Application.Contracts.Services.IdentityAccessManagement;
using EventBud.Application.Services.IdentityAccessManagement;
using EventBud.Domain._Shared.IAM.Models;
using Microsoft.AspNetCore.Identity;

namespace EventBud.Application.Adapters.IdentityAccessManagement;

public sealed class SignInManagerAdapter : ISignInManagerAdapter<ApplicationUser>
{
    private readonly SignInManagerService _signInManager;

    public SignInManagerAdapter(SignInManagerService signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task<SignInResult> CheckPasswordAsync(ApplicationUser user, string password, bool lockoutOnFailure)
    {
        return await _signInManager.CheckPasswordSignInAsync(user, password, lockoutOnFailure);
    }

    public async Task SignOutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}
