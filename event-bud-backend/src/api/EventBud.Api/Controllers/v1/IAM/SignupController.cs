﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using EventBud.Application.Features.IAM.Commands.SignUp;
using Microsoft.AspNetCore.Authorization;

namespace EventBud.Api.Controllers.v1.IAM;

[AllowAnonymous]
public class SignupController : ApiBaseController
{
    public SignupController(ISender sender) 
        : base(sender)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Post(
        [FromBody] SignUpCommand command, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(command, cancellationToken);
        
        return result.Succeeded ? Ok(result.Data) : BadRequest(result.Errors);
    }
}