using EventBud.Application.Features.Auth.Commands.SignUp;
using EventBud.Application.Features.Auth.Queries.SignIn;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventBud.Api.Controllers.v1;

public class AuthsController : ApiBaseController
{
    public AuthsController(ISender sender) 
        : base(sender)
    {
    }

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn(
        [FromBody] SignInQuery query, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(query, cancellationToken);

        return result.Succeeded ? Ok(result.Data) : BadRequest(result.Errors);
    }

    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp(
        [FromBody] SignUpCommand command, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(command, cancellationToken);

        return result.Succeeded ? Ok() : BadRequest(result.Errors);
    }
}
