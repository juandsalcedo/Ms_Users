using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ms_Users.Domain.Entity; // Importamos para usar el enum VerificationStatus

namespace Ms_Users.Infraestructure.Entity;

[Table("SellerProfiles")]
public class SellerProfileEntity
{
    [Key]
    public Guid SellerId { get; set; } // PK y FK al mismo tiempo

    [Required]
    [MaxLength(100)]
    public string StoreName { get; set; } = string.Empty;
    
    [Required]
    public VerificationStatus VerificationStatus { get; set; }
    
    public int TotalReviews { get; set; }
    
    public int SumRatings { get; set; }
    
    public DateTime? ApprovedAt { get; set; }

    // Relación de navegación hacia el usuario
    [ForeignKey("SellerId")]
    public UserEntity? User { get; set; }
}