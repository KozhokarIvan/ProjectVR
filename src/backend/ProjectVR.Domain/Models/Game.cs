namespace ProjectVR.Domain.Models;

public class Game
{
    public const int MinGameNameLength = 1;
    public const int MaxGameNameLength = 256;
    public const int MinGameIconLength = 8;
    public const int MaxGameIconLength = 256;
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Icon { get; set; } = null!;
}