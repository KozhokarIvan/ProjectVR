using ProjectVR.DataAccess.Models;

namespace ProjectVR.DataAccess.Mapping.Extensions
{
    internal static class UserGameMappingExtension
    {
        public static Domain.Entities.Usergame MapToDomainEntity(this UserGame game)
        {
            Domain.Entities.Usergame gameEntity = new Domain.Entities.Usergame
            {
                Game = game.Game.MapToDomainEntity(),
                IsFavorite = game.IsFavorite,
                Rating = game.Rating
            };
            return gameEntity;
        }
    }
}
