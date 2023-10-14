namespace EventBud.Domain._Commons;

public interface ISoftDeletableEntity
{
    DateTime? DeletedAt { get; set; }
}
