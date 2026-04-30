using Ms_Users.Adapter.Restful.v1.Dtos;
using Ms_Users.Domain.Entity;

namespace Ms_Users.Adapter.Restful.v1.Mappers
{
    public static class UserMapper
    {
        public static DomainEntityUser ToEntity(this UserCreateDto dto)
        {
            return new DomainEntityUser
            {
                RoleId = dto.RoleId,
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = dto.Password, 
                Phone = dto.Phone,
                CreatedAt = DateTime.UtcNow,
                Status = (UserStatus)1,
                IsDeleted = false
            };
        }
    }   
}