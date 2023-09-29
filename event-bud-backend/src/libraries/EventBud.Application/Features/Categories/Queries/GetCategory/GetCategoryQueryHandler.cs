using EventBud.Application.Contracts;
using EventBud.Application.Features.Categories.Dtos;
using MediatR;

namespace EventBud.Application.Features.Categories.Queries.GetCategory;

public sealed class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCategoryQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CategoryDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id, cancellationToken);
        return result ?? new CategoryDto();
    }
}
