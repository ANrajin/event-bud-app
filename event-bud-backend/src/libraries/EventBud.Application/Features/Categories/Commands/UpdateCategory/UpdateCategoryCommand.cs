using MediatR;

namespace EventBud.Application.Features.Categories.Commands.UpdateCategory;

public sealed class UpdateCategoryCommand : IRequest
{
    public required Guid Id { get; set; }
    
    public required string Title { get; set; }
    
    public required string Description { get; set; }
}
