using EventBud.Domain.Dtos.Category;
using MediatR;

namespace EventBud.Application.Features.Categories.Queries.GetCategory;

public sealed record GetCategoryQuery(Guid Id) : IRequest<CategoryDto>;