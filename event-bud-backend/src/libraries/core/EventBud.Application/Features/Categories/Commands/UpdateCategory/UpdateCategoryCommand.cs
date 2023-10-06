using EventBud.Application.Abstractions.Requests;

namespace EventBud.Application.Features.Categories.Commands.UpdateCategory;

public sealed class UpdateCategoryCommand : ICommand
{
    public required Guid Id { get; set; }
    
    public required string Title { get; set; }
    
    public required string Description { get; set; }
}
