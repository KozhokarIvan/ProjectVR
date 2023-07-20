namespace ProjectVR.Domain.Models
{
    public class UserGame
    {
        public const byte MinRatingValue = 0;
        public const byte MaxRatingValue = 100;

        public Game Game { get; set; }
        public byte? Rating { get; set; }
        public bool IsFavorite { get; set; }
    }
}
