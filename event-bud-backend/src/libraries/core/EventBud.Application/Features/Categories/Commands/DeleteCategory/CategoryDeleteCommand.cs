using EventBud.Application.Abstractions.Requests;

namespace EventBud.Application.Features.Categories.Commands.DeleteCategory;

public sealed record CategoryDeleteCommand(Guid Id) : ICommand;
