using EventBud.Application.Contracts;
using EventBud.Application.Features.Events.Dtos;
using MediatR;

namespace EventBud.Application.Features.Events.Queries.GetEvents;

public class GetEventsQueryHandler : IRequestHandler<GetEventsQuery, IReadOnlyList<EventDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    
    public GetEventsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IReadOnlyList<EventDto>> Handle(GetEventsQuery request, 
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.EventRepository.GetAllAsync(cancellationToken);

        return result;
    }
}
