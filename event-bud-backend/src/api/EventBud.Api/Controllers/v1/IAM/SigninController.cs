﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EventBud.Application.Features.IAM.Queries.SignIn;

namespace EventBud.Api.Controllers.v1.IAM;

[AllowAnonymous]
public class SigninController : ApiBaseController
{
    public SigninController(ISender sender) 
        : base(sender)
    {
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(
        [FromBody] SignInQuery query, 
        CancellationToken cancellationToken)
    {
        var result = await Sender.Send(query, cancellationToken);

        return result.Succeeded ? Ok(result.Data) : BadRequest(result.Errors);
    }
}