using Microsoft.AspNetCore.Identity;

namespace EventBud.Domain._Shared.IAM.Models;

public sealed class ApplicationUser : IdentityUser<Guid>
{
    public bool RememberMe { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
}
