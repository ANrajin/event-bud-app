using EventBud.Application.Features.Categories.Commands.CreateCategory;
using EventBud.Application.Features.Categories.Commands.DeleteCategory;
using EventBud.Application.Features.Categories.Commands.UpdateCategory;
using EventBud.Application.Features.Categories.Queries.GetCategories;
using EventBud.Application.Features.Categories.Queries.GetCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventBud.Api.Controllers.v1;

public class CategoriesController : ApiBaseController
{
    public CategoriesController(ISender sender) : base(sender)
    {
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var result = await Sender.Send
            (new GetCategoriesQuery(), cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : StatusCode(503);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new GetCategoryQuery(id), cancellationToken);
        
        return result.IsSuccess ? Ok(result.Data) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Post(
        [FromBody] CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : StatusCode(503);
    }

    [HttpPut]
    public async Task<IActionResult> Put(
        [FromBody] UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(command, cancellationToken);
        return result.IsSuccess ? Ok() : StatusCode(503);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new CategoryDeleteCommand(id), cancellationToken);

        return result.IsSuccess ?  Ok() : StatusCode(503);
    }
}
