using Ms_Users.Domain.Entity;
using Ms_Users.Infraestructure.Entity; // ¡AQUÍ ESTÁ LA 'e' MÁGICA!

namespace Ms_Users.Infraestructure.Mapper;

public static class UserMapper
{
    public static DomainEntityUser? ToDomain(this UserEntity? entity)
    {
        if (entity == null) return null;

        return new DomainEntityUser
        {
            UserId = entity.UserId,
            FullName = entity.FullName,
            Email = entity.Email,
            RoleId = entity.RoleId,
            Status = entity.Status, 
            PasswordHash = entity.PasswordHash, // <-- CORREGIDO: Ahora ambos se llaman PasswordHash
            CreatedAt = entity.CreatedAt,
            IsDeleted = entity.IsDeleted,
            
            SellerProfile = entity.SellerProfile != null ? new DomainEntitySellerProfile
            {
                SellerId = entity.SellerProfile.SellerId,
                StoreName = entity.SellerProfile.StoreName,
                VerificationStatus = entity.SellerProfile.VerificationStatus,
                TotalReviews = entity.SellerProfile.TotalReviews,
                SumRatings = entity.SellerProfile.SumRatings
            } : null
        };
    }

    public static UserEntity ToEntity(this DomainEntityUser domain)
    {
        return new UserEntity
        {
            UserId = domain.UserId,
            FullName = domain.FullName,
            Email = domain.Email,
            RoleId = domain.RoleId,
            Status = domain.Status, 
            PasswordHash = domain.PasswordHash, // <-- CORREGIDO: Ahora ambos se llaman PasswordHash
            CreatedAt = domain.CreatedAt,
            IsDeleted = domain.IsDeleted
        };
    }
}