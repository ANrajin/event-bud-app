using EventBud.Domain.Common;

namespace EventBud.Domain.Entities;

public sealed class Category : BaseEntity
{
    public string Title { get; private set; } = string.Empty;
    
    public string Description { get; private set; } = string.Empty;

    public static Category Create(string title, string description)
    {
        return new Category
        {
            Title = title,
            Description = description,
        };
    }
}