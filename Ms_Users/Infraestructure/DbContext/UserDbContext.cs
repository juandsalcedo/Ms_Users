using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion; 
using Ms_Users.Infraestructure.Entity;
using Ms_Users.Domain.Entity; 
using System; 

namespace Ms_Users.Infraestructure.DbContext;

public class UserDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

    // Definición de las tablas
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<SellerProfileEntity> SellerProfiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuracion de Roles 
        modelBuilder.Entity<RoleEntity>().HasData(
            new RoleEntity { RoleId = 1, RoleName = "Admin" },
            new RoleEntity { RoleId = 2, RoleName = "Seller" },
            new RoleEntity { RoleId = 3, RoleName = "Customer" }
        );

        //  Relacion User - Role (Muchos a Uno)
        modelBuilder.Entity<UserEntity>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);

        // Relacion User - SellerProfile (Uno a Uno)
        // El SellerId es la PK y también la FK que apunta a User.UserId
        modelBuilder.Entity<SellerProfileEntity>()
            .HasKey(s => s.SellerId);

        modelBuilder.Entity<SellerProfileEntity>()
            .HasOne(s => s.User)
            .WithOne(u => u.SellerProfile)
            .HasForeignKey<SellerProfileEntity>(s => s.SellerId);
        
        // Traductor de Eneum para el status, ignora mayusculas y minusculas
        var statusConverter = new ValueConverter<UserStatus, string>(
            v => v.ToString().ToUpper(), // Guarda en mayúsculas en la BD
            v => (UserStatus)Enum.Parse(typeof(UserStatus), v, true) // <--- Lee ignorando mayúsculas
        );

        modelBuilder.Entity<UserEntity>()
            .Property(u => u.Status)
            .HasConversion(statusConverter);
    }
}