﻿using EventBud.Domain._Commons;

namespace EventBud.Domain.Category;

public sealed class Category : Entity
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

    public void Update(string title, string description)
    {
        Title = title;
        Description = description;
    }
}