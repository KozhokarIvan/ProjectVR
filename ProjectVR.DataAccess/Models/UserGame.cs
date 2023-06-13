using System;

namespace ProjectVR.DataAccess.Models
{
    public class UserGame
    {
        public int Id { get; set; }
        public UserInfo User { get; set; }
        public Guid UserGuid { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
        public bool IsFavorite { get; set; }
        public int Rating { get; set; }
    }
}
