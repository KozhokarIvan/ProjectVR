using ProjectVR.DataAccess.Models;

namespace ProjectVR.DataAccess.Mapping
{
    internal static class UserGameMappingExtension
    {
        public static Domain.Entities.UserGame MapToDomain(this UserGame game)
        {
            Domain.Entities.UserGame gameEntity = new Domain.Entities.UserGame
            {
                Game = game.Game.MapToDomain(),
                IsFavorite = game.IsFavorite,
                Rating = game.Rating
            };
            return gameEntity;
        }
    }
}
