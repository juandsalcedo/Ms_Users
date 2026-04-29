using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ms_Users.Infraestructure.Entity;

[Table("Roles")]
public class RoleEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Para que el ID (1, 2, 3) se genere solo
    public int RoleId { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string RoleName { get; set; } = string.Empty;

    // Relación: Un rol tiene muchos usuarios
    public ICollection<UserEntity>? Users { get; set; }
}