using EventBud.Domain.Dtos.Category;
using MediatR;

namespace EventBud.Application.Features.Categories.Queries.GetCategories;

public sealed record GetCategoriesQuery(CancellationToken CancellationToken) : IRequest<IReadOnlyList<CategoryDto>>;