using EventBud.Domain._Shared.IAM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace EventBud.Application.Services.IdentityAccessManagement;

public class RoleManagerService : RoleManager<ApplicationUser>
{
    public RoleManagerService(
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
