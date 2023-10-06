using EventBud.Application.Abstractions.Requests;
using EventBud.Application.Features.Categories.Dtos;

namespace EventBud.Application.Features.Categories.Queries.GetCategory;

public sealed record GetCategoryQuery(Guid Id) : IQuery<CategoryDto>;
