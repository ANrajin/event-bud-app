using EventBud.Application.Contracts.Services.IdentityAccessManagement;
using EventBud.Application.Services.IdentityAccessManagement;
using EventBud.Domain._Shared.IAM.Models;

namespace EventBud.Application.Adapters.IdentityAccessManagement;

public class RoleManagerAdapter : IRoleManagerAdapter<ApplicationUser>
{
    private readonly RoleManagerService _roleManager;

    public RoleManagerAdapter(RoleManagerService roleManager)
    {
        _roleManager = roleManager;
    }
}
