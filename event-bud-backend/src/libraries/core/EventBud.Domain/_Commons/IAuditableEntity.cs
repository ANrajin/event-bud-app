namespace EventBud.Domain._Commons;

public interface IAuditableEntity
{
    DateTime CreatedAt { get; set; }

    DateTime? ModifiedAt { get; set; }
}
