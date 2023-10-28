namespace EventBud.Domain._Shared.IAM.Models;

public sealed class RefreshToken : Entity, IAuditableEntity
{
    public Guid UserId { get; set; }
    
    public string Token { get; set; } = string.Empty;
    
    public string JwtId { get; set; } = string.Empty;
    
    public DateTime ExpiredAt { get; set; }
    
    public bool IsUsed { get; set; } = false;
    
    public bool IsRevoked { get; set; } = false;
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? ModifiedAt { get; set; }
}