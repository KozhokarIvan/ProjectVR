using ProjectVR.DataAccess.Entities;

namespace ProjectVR.DataAccess.Mapping
{
    internal static class UserGameMappingExtension
    {
        public static Domain.Models.UserGame MapToDomainModel(this UserGame game)
        {
            Domain.Models.UserGame gameEntity = new Domain.Models.UserGame
            {
                Game = game.Game.MapToDomainModel(),
                IsFavorite = game.IsFavorite,
                Rating = game.Rating
            };
            return gameEntity;
        }
    }
}
