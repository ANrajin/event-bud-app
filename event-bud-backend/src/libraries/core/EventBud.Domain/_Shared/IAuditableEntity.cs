namespace EventBud.Domain._Shared;

public interface IAuditableEntity
{
    DateTime CreatedAt { get; set; }

    DateTime? ModifiedAt { get; set; }
}
