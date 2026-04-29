using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ms_Users.Domain.Entity; // Para traer UserStatus

namespace Ms_Users.Infraestructure.Entity;

[Table("Users")]
public class UserEntity
{
    [Key]
    public Guid UserId { get; set; } // Tu CHAR(36)

    [Required]
    public int RoleId { get; set; } // La llave foránea hacia Roles

    [Required]
    [MaxLength(100)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Column("passwordHash")] // Enlazamos con el nombre exacto en MySQL
    public string PasswordHash { get; set; } = string.Empty; // Renombrado para que coincida con el Dominio y el Mapper

    [MaxLength(20)]
    public string? Phone { get; set; }

    public DateTime CreatedAt { get; set; }

    [Required]
    [Column("userStatus")] // Enlazamos con el nombre exacto en MySQL
    public UserStatus Status { get; set; }

    [NotMapped] // <-- LA MAGIA: Le decimos a la base de datos que ignore esto por completo
    public bool IsDeleted { get; set; }

    // Relaciones de navegación
    [ForeignKey("RoleId")]
    public RoleEntity? Role { get; set; }
    
    public SellerProfileEntity? SellerProfile { get; set; }
}