using EventBud.Application.Features.Categories.Commands.CreateCategory;
using EventBud.Application.Features.Categories.Commands.DeleteCategory;
using EventBud.Application.Features.Categories.Commands.UpdateCategory;
using EventBud.Application.Features.Categories.Queries.GetCategories;
using EventBud.Application.Features.Categories.Queries.GetCategory;
using EventBud.Domain.Dtos.Category;
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
            (new GetCategoriesQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetCategoryQuery(id), cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(
        [FromBody] CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put(
        [FromBody] UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new CategoryDeleteCommand(id), cancellationToken);

        return Ok();
    }
}
