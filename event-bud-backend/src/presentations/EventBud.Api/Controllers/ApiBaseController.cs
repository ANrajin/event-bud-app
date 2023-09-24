using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventBud.Api.Controllers;

[ApiController]
[Produces("application/json")]
[Consumes("application/json")]
public class ApiBaseController : Controller
{
    protected readonly ISender Sender;

    public ApiBaseController(ISender sender)
    {
        Sender = sender;
    }
}
