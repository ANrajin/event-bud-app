using EventBud.Application.Features.Events.Commands.CreateEvents;
using EventBud.Application.Features.Events.Queries.GetEvents;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventBud.Api.Controllers.v1;

public class EventsController : ApiBaseController
{
    public EventsController(ISender sender) : base(sender)
    {
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var result = await Sender
            .Send(new GetEventsQuery(cancellationToken), cancellationToken);
        
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(
        [FromBody] CreateEventsCommand command, CancellationToken cancellationToken)
    {
        await Sender.Send(command, cancellationToken);
        return Ok();
    }
}
