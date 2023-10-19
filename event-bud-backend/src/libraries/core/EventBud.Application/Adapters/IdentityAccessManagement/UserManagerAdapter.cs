using EventBud.Application.Contracts.Services.IdentityAccessManagement;
using EventBud.Application.Services.IdentityAccessManagement;
using EventBud.Domain._Shared.IAM.Models;
using Microsoft.AspNetCore.Identity;

namespace EventBud.Application.Adapters.IdentityAccessManagement;

public class UserManagerAdapter : IUserManagerAdapter<ApplicationUser>
{
    private readonly UserManagerService _userManager;

    public UserManagerAdapter(UserManagerService userManager)
    {
        _userManager = userManager;
    }

    public void Dispose() => _userManager.Dispose();

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

    public async Task<ApplicationUser> FindByEmailAsync(string email) => await _userManager.FindByEmailAsync(email);


    public async Task<ApplicationUser> FindByUserNameAsync(string userName) => await _userManager.FindByNameAsync(userName);
}
