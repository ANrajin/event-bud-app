using EventBud.Application.Abstractions.Requests;
using EventBud.Application.Features.Categories.Dtos;

namespace EventBud.Application.Features.Categories.Queries.GetCategories;

public sealed record GetCategoriesQuery : IQuery<IReadOnlyList<CategoryDto>>;
