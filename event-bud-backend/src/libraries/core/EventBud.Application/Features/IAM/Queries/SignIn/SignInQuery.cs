using EventBud.Application.Abstractions.Requests;

namespace EventBud.Application.Features.IAM.Queries.SignIn;

public sealed record SignInQuery(string UserName, string Password) 
    : ICommand<SignInQueryResponse>;
