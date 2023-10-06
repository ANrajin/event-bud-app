using EventBud.Application.Abstractions.Requests;

namespace EventBud.Application.Features.Categories.Commands.CreateCategory;

public sealed record CreateCategoryCommand(
    string Title, 
    string Description) : ICommand;
