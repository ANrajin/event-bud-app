using EventBud.Application.Features.Auth.Commands.SignUp;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventBud.Api.Controllers.v1;

public class AuthsController : ApiBaseController
{
    public AuthsController(ISender sender) 
        : base(sender)
    {
    }

    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp(
        [FromBody] SignUpCommand command, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : BadRequest(result.Errors);
    }
}
