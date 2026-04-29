using Ms_Users.Domain.Dto;
using Ms_Users.Domain.Entity;

namespace Ms_Users.Application.Service;

public interface IUserService
{
    // En IUserService.cs
    Task<UserExternalDto?> GetUserByIdAsync(Guid userId);
    Task CreateUserAsync(DomainEntityUser user);
}