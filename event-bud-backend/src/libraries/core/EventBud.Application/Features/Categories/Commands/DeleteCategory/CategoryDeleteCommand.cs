using MediatR;

namespace EventBud.Application.Features.Categories.Commands.DeleteCategory;

public sealed record CategoryDeleteCommand(Guid Id) : IRequest;
