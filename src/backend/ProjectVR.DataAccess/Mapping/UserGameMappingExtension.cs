using ProjectVR.DataAccess.Entities;

namespace ProjectVR.DataAccess.Mapping
{
    internal static class UserGameMappingExtension
    {
        public static Domain.Models.UserGame MapToDomainModel(this UserGame userGame)
        {
            Domain.Models.UserGame gameEntity = new Domain.Models.UserGame
            {
                GameId = userGame.Game.Id,
                GameIcon = userGame.Game.Icon,
                GameName = userGame.Game.Name,
                IsFavorite = userGame.IsFavorite,
                Rating = userGame.Rating
            };
            return gameEntity;
        }
    }
}
