using EventBud.Application.Abstractions.Requests;
using EventBud.Application.Contracts.UnitOfWorks;
using EventBud.Application.Features.Categories.Dtos;
using EventBud.Domain._Shared;

namespace EventBud.Application.Features.Categories.Queries.GetCategories;

public sealed class GetCategoryQueryHandler : IQueryHandler<GetCategoriesQuery, IReadOnlyList<CategoryDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCategoryQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<IReadOnlyList<CategoryDto>>> Handle
        (GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.CategoryRepository.GetAllAsync(cancellationToken);
    
        return Result.Success(result);
    }
}
