using Microsoft.AspNetCore.Identity;

namespace EventBud.Domain._Shared.IAM.Models;

public sealed class UserClaim : IdentityUserClaim<Guid>
{
}
