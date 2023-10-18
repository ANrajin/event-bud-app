using EventBud.Domain._Shared.IAM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace EventBud.Application.IAM.Services;

public class RoleManager : RoleManager<ApplicationUser>
{
    public RoleManager(
        IRoleStore<ApplicationUser> store, 
        IEnumerable<IRoleValidator<ApplicationUser>> roleValidators, 
        ILookupNormalizer keyNormalizer, 
        IdentityErrorDescriber errors, 
        ILogger<RoleManager<ApplicationUser>> logger) 
        : base(
            store, 
            roleValidators, 
            keyNormalizer, 
            errors, 
            logger)
    {
    }
}
