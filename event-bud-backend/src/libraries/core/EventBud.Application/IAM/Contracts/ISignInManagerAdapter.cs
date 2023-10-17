﻿using EventBud.Domain._Shared.IAM.Models;
using Microsoft.AspNetCore.Identity;

namespace EventBud.Application.IAM.Contracts;

public interface ISignInManagerAdapter<TUser> where TUser : class
{
    Task<SignInResult> PasswordSignInAsync(string userName, string password);
    Task SignOutAsync();
}
