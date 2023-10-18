namespace EventBud.Application.Contracts.Services.IdentityAccessManagement;

public interface IAuthenticationService
{
    Task Register(
        string firstName,
        string lastName,
        string email,
        string password);

    Task Login(string userName, string password);
}
