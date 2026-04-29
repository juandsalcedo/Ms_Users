using Microsoft.EntityFrameworkCore;
using Ms_Users.Infraestructure.Entity;

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

        // 1. Configuración de Roles (Semilla inicial para que el Rol 2 sea Vendedor)
        modelBuilder.Entity<RoleEntity>().HasData(
            new RoleEntity { RoleId = 1, RoleName = "Admin" },
            new RoleEntity { RoleId = 2, RoleName = "Seller" },
            new RoleEntity { RoleId = 3, RoleName = "Customer" }
        );

        // 2. Relación User - Role (Muchos a Uno)
        modelBuilder.Entity<UserEntity>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);

        // 3. Relación User - SellerProfile (Uno a Uno)
        // El SellerId es la PK y también la FK que apunta a User.UserId
        modelBuilder.Entity<SellerProfileEntity>()
            .HasKey(s => s.SellerId);

        modelBuilder.Entity<SellerProfileEntity>()
            .HasOne(s => s.User)
            .WithOne(u => u.SellerProfile)
            .HasForeignKey<SellerProfileEntity>(s => s.SellerId);
    }
}