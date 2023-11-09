namespace ProjectVR.Domain.Models;

public class PersonalMessage
{
    public const int MinMessageLength = 1;
    public const int MaxMessageLength = 2048;
    public int Id { get; set; }
    public PersonalChat Chat { get; set; } = null!;
    public UserSummary From { get; set; } = null!;
    public string Content { get; set; } = null!;
}