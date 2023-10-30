using EventBud.Domain._Shared.IAM.Models;
using Microsoft.AspNetCore.Identity;

namespace EventBud.Application.Contracts.Services.IdentityAccessManagement;

public interface IUserManagerAdapter<in TUser> : IDisposable where TUser : class
{
    Task<IdentityResult> CreateAsync(TUser applicationUser, string password);

    Task<ApplicationUser?> FindByEmailAsync(string email);

    Task<ApplicationUser?> FindByUserNameAsync(string userName);
}
