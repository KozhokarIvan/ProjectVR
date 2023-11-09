namespace ProjectVR.WebAPI.Contracts;

public class UserGame
{
    public int GameId { get; set; }
    public string GameName { get; set; } = null!;
    public string GameIcon { get; set; } = null!;
    public int? Rating { get; set; }
    public bool IsFavorite { get; set; }
}