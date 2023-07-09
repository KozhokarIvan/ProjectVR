namespace ProjectVR.WebAPI.Contracts
{
    public class UserGame
    {
        public int GameId { get; set; }
        public string Name { get; set; } = null!;
        public int? Rating { get; set; }
        public bool IsFavorite { get; set; }
        public string Icon { get; set; } = null!;
    }
}
