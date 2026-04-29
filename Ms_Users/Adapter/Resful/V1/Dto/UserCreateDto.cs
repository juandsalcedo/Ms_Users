namespace Ms_Users.Adapter.Restful.v1.Dtos
{
    public class UserCreateDto
    {
        public Guid UserId { get; set; }
        public int RoleId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Phone { get; set; }
    }
}