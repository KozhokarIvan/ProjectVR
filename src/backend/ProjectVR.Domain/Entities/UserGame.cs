namespace ProjectVR.Domain.Entities
{
    public class UserGame
    {
        public Game Game { get; set; }
        public int? Rating { get; set; }
        public bool IsFavorite { get; set; }
    }
}
