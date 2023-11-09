namespace ProjectVR.Domain.Models;

public class PersonalChat
{
    public int Id { get; set; }
    public UserSummary FirstUser { get; set; } = null!;
    public UserSummary SecondUser { get; set; } = null!;
}