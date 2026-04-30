using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;


namespace Ms_Users.Domain.Entity;

public enum UserStatus
{
    Pending,
    Active,
    Suspended,
    Banned
}

public class DomainEntityUser
{
    public Guid UserId { get; set; } = Guid.NewGuid(); // <-- Se le asigna una id unico cuando se crea un nuevo objeto
    public int RoleId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    
  
    public string PasswordHash { get; set; } = string.Empty;
    
    public string? Phone { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("userStatus")] 
    public UserStatus Status { get; set; } = UserStatus.Pending;
    
    [NotMapped] 
    public bool IsDeleted { get; set; }

    // Objetos anidados para representar las relaciones en el Dominio
    public DomainEntityRole? Role { get; set; }
    public DomainEntitySellerProfile? SellerProfile { get; set; }
}