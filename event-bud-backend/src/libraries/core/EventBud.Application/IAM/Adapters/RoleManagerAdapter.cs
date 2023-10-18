using EventBud.Application.IAM.Contracts;
using EventBud.Application.IAM.Services;
using EventBud.Domain._Shared.IAM.Models;

namespace EventBud.Application.IAM.Adapters;

public class RoleManagerAdapter : IRoleManagerAdapter<ApplicationUser>
{
    private readonly RoleManager _roleManager;

    public RoleManagerAdapter(RoleManager roleManager)
    {
        _roleManager = roleManager;
    }
}
