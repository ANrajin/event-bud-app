namespace EventBud.Domain._Shared;

public interface ISoftDeletableEntity
{
    DateTime? DeletedAt { get; set; }
}
