using EventBud.Domain._Shared.IAM.Models;
using Microsoft.AspNetCore.Identity;

namespace EventBud.Application.IAM.Contracts;

public interface IUserManagerAdapter<TUser> : IDisposable where TUser : class
{
    Task<IdentityResult> CreateAsync(TUser applicationUser, string password);

    Task<string> GetUserIdAsync(TUser applicationUser);

    Task<ApplicationUser> FindByEmailAsync(string email);

    Task<IdentityResult> AddToRoleAsync(ApplicationUser applicationUser, string role);
}
