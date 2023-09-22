using EventBud.Application.Features.Categories.Commands.CreateCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventBud.Api.Controllers.v1;

[Route("api/v1/[controller]")]
public class CategoriesController : ApiBaseController
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Post(
        [FromBody] CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }
}