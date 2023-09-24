using EventBud.Application.Features.Categories.Commands.CreateCategory;
using EventBud.Application.Features.Categories.Queries.GetCategories;
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

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send
            (new GetCategoriesQuery(cancellationToken), cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(
        [FromBody] CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }
}