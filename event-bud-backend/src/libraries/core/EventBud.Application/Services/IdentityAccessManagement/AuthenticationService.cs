using EventBud.Application.Contracts.Services.IdentityAccessManagement;

namespace EventBud.Application.Services.IdentityAccessManagement;

public class AuthenticationService : IAuthenticationService
{
    public Task Login(string userName, string password)
    {
        throw new NotImplementedException();
    }

    public Task Register(string firstName, string lastName, string email, string password)
    {
        //Check if user already exist

        //Create new user
        var userId = Guid.NewGuid();

        throw new NotImplementedException();
    }
}
