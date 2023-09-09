using MediatR;

namespace EventBud.Application.Features.Categories.Commands.CreateCategory;

public sealed record CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>;