using Microsoft.EntityFrameworkCore;
using Ms_Users.Domain.Entity;
using Ms_Users.Domain.Repository; // Traemos la interfaz (el contrato)
using Ms_Users.Infraestructure.DbContext;
using Ms_Users.Infraestructure.Mapper;

namespace Ms_Users.Infraestructure.Repository;

//  IUserRepository, esta clase CUMPLE el contrato
public class UserRepository : IUserRepository 
{
    private readonly UserDbContext _context;

    public UserRepository(UserDbContext context)
    {
        _context = context;
    }

    public async Task<DomainEntityUser?> GetUserByIdAsync(Guid userId)
    {
     
        var userEntity = await _context.Users
            .Include(u => u.SellerProfile) 
            .FirstOrDefaultAsync(u => u.UserId == userId);

        
        if (userEntity == null) return null;
        
        return userEntity.ToDomain();
    }
    
    public async Task CreateUserAsync(DomainEntityUser user)
    {
        // 1. Convertimos el objeto de Dominio a objeto de Base de Datos
        // Probablemente tengas un método llamado ToEntity() o similar en tu mapper
        var userEntity = user.ToEntity(); 

        // 2. Ahora sí, añadimos el objeto que la DB sí entiende
        _context.Users.Add(userEntity);
    
        await _context.SaveChangesAsync();
    }
}