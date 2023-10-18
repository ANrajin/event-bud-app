using EventBud.Domain._Shared.IAM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EventBud.Application.Services.IdentityAccessManagement;

public class UserManagerService : UserManager<ApplicationUser>
{
    public UserManagerService(IUserStore<ApplicationUser> store,
       IOptions<IdentityOptions> optionsAccessor,
       IPasswordHasher<ApplicationUser> passwordHasher,
       IEnumerable<IUserValidator<ApplicationUser>> userValidators,
       IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators,
       ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors,
       IServiceProvider services, ILogger<UserManager<ApplicationUser>> logger)
       : base(
           store,
           optionsAccessor,
           passwordHasher,
           userValidators,
           passwordValidators,
           keyNormalizer,
           errors,
           services,
           logger)
    {
    }
}
