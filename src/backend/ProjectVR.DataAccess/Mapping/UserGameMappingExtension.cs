using ProjectVR.Domain.Models;

namespace ProjectVR.DataAccess.Mapping;

internal static class UserGameMappingExtension
{
    public static UserGame MapToDomainModel(this Entities.UserGame userGame)
    {
        var gameEntity = new UserGame
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