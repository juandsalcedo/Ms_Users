using Ms_Users.Domain.Entity;

namespace Ms_Users.Domain.Repository;

public interface IUserRepository
{
    // El método clave para que Ms_Products pueda buscar al vendedor
    Task<DomainEntityUser?> GetUserByIdAsync(Guid userId);
    
    Task CreateUserAsync(DomainEntityUser user);
}      

// 