using EventBud.Application.Features.Categories.Dtos;
using MediatR;

namespace EventBud.Application.Features.Categories.Queries.GetCategories;

public sealed record GetCategoriesQuery : IRequest<IReadOnlyList<CategoryDto>>;
