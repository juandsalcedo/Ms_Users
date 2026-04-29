namespace Ms_Users.Domain.Entity;

public enum VerificationStatus
{
    Pending,
    Success,
    Failed
}
public class DomainEntitySellerProfile
{
    public Guid SellerId { get; set; }
    public string StoreName { get; set; } = string.Empty;
    public VerificationStatus VerificationStatus { get; set; } = VerificationStatus.Pending;
    public int TotalReviews { get; set; }
    public int SumRatings { get; set; }
    public DateTime? ApprovedAt { get; set; }
}