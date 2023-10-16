using EventBud.Application.IAM.Contracts;
using EventBud.Application.IAM.Services;
using EventBud.Domain._Shared.IAM.Models;
using Microsoft.AspNetCore.Identity;

namespace EventBud.Application.IAM.Adapters;

public class UserManagerAdapter : IUserManagerAdapter<ApplicationUser>
{
    private readonly UserManager _userManager;

    public UserManagerAdapter(UserManager userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
    {
        if (user is null)
            throw new InvalidOperationException("You must provide a user");

        if (string.IsNullOrWhiteSpace(password))
            throw new InvalidOperationException("You must provide a password");

        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
            return result;

        return result;
    }

    public async Task<string> GetUserIdAsync(ApplicationUser user)
    {
        var result = await _userManager.GetUserIdAsync(user);

        return result;
    }

    public async Task<ApplicationUser> FindByEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email) ?? new();
    }

    public async Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role)
    {
        return await _userManager.AddToRoleAsync(user, role);
    }

    public void Dispose() => _userManager.Dispose();
}
