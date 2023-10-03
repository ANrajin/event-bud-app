using EventBud.Application.Contracts;
using EventBud.Application.Features.Events.Dtos;
using MediatR;

namespace EventBud.Application.Features.Events.Queries.GetEvents;

public class GetEventsQueryHandler : IRequestHandler<GetEventsQuery, IReadOnlyList<MyEventDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    
    public GetEventsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IReadOnlyList<MyEventDto>> Handle(GetEventsQuery request, 
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.MyEventRepository.GetAllAsync(cancellationToken);

        return result;
    }
}
