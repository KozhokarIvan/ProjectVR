using ProjectVR.DataAccess.Models;

namespace ProjectVR.DataAccess.Mapping.Extensions
{
    internal static class UserGameMappingExtension
    {
        public static Domain.Entities.UserGame MapToDomainEntity(this UserGame game)
        {
            Domain.Entities.UserGame gameEntity = new Domain.Entities.UserGame
            {
                Game = game.Game.MapToDomainEntity(),
                IsFavorite = game.IsFavorite,
                Rating = game.Rating
            };
            return gameEntity;
        }
    }
}
