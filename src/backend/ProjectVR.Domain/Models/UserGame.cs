namespace ProjectVR.Domain.Models
{
    public class UserGame
    {
        public const byte MinRatingValue = 0;
        public const byte MaxRatingValue = 100;
        public int GameId { get; set; }
        public string GameName { get; set; } = null!;
        public string GameIcon { get; set; } = null!;
        public byte? Rating { get; set; }
        public bool IsFavorite { get; set; }
    }
}
