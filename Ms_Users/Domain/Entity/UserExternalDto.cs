namespace Ms_Users.Domain.Dto;

public class UserExternalDto
{
    public Guid UserId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string StoreName { get; set; } = string.Empty;
    public double Rating { get; set; }
}