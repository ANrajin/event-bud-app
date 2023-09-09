using Microsoft.AspNetCore.Mvc;

namespace EventBud.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public class ApiBaseController : Controller
{
}