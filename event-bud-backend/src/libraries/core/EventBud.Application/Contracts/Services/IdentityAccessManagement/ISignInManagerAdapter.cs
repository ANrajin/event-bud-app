using EventBud.Domain._Shared.IAM.Models;
using Microsoft.AspNetCore.Identity;

namespace EventBud.Application.Contracts.Services.IdentityAccessManagement;

public interface ISignInManagerAdapter<TUser> where TUser : class
{
    Task<SignInResult> CheckPasswordAsync(ApplicationUser user, string password, bool lockoutOnFailure);
    Task SignOutAsync();
}
