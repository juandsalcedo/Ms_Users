using System.ComponentModel.DataAnnotations.Schema;

namespace Ms_Users.Domain.Entity;

public enum UserStatus
{
    Active,
    Suspended,
    Banned
}

public class DomainEntityUser
{
    public Guid UserId { get; set; }
    public int RoleId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    
    // Cambiamos 'Password' por 'PasswordHash' para que el Mapper no marque error
    public string PasswordHash { get; set; } = string.Empty;
    
    public string? Phone { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("userStatus")] 
    public UserStatus Status { get; set; } = UserStatus.Active;
    
    [NotMapped] 
    public bool IsDeleted { get; set; }

    // Objetos anidados para representar las relaciones en el Dominio
    public DomainEntityRole? Role { get; set; }
    public DomainEntitySellerProfile? SellerProfile { get; set; }
}