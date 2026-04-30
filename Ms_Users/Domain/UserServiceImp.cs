using Ms_Users.Application.Service;
using Ms_Users.Domain.Dto;
using Ms_Users.Domain.Entity;
using Ms_Users.Domain.Repository;

namespace Ms_Users.Application.Service;

public class UserServiceImp : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserServiceImp(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserExternalDto?> GetUserByIdAsync(Guid userId)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);

        if (user == null) return null;
        
        return new UserExternalDto
        {
            UserId = user.UserId,
            FullName = user.FullName,
            Email = user.Email,
            StoreName = user.SellerProfile?.StoreName ?? "No tiene tienda",
            Rating = user.SellerProfile != null && user.SellerProfile.TotalReviews > 0 
                ? (double)user.SellerProfile.SumRatings / user.SellerProfile.TotalReviews 
                : 0
        };
    }

    public async Task CreateUserAsync(DomainEntityUser user)
    {
        await _userRepository.CreateUserAsync(user);
    }
}

// MODIFICACIONES 