using EventBud.Domain._Shared.IAM.Models;
using Microsoft.AspNetCore.Identity;

namespace EventBud.Application.IAM.Contracts;

public interface ISignInManagerAdapter<TUser> where TUser : class
{
    Task SignInAsync(TUser applicationUser);
    Task<SignInResult> PasswordSignInAsync(ApplicationUser user);
    Task SignOutAsync();
}
