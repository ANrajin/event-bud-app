using EventBud.Application.Abstractions.Requests;
using EventBud.Application.Contracts.UnitOfWorks;
using EventBud.Application.Features.Categories.Dtos;
using EventBud.Domain._Shared.Results;

namespace EventBud.Application.Features.Categories.Queries.GetCategory;

public sealed class GetCategoryQueryHandler : IQueryHandler<GetCategoryQuery, CategoryDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCategoryQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<CategoryDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id, cancellationToken);

        return result is not null
            ? Result.Success(result)
            : Result.Failure<CategoryDto>(new Error("Not Found", "The requested resource not found!"));
    }
}
