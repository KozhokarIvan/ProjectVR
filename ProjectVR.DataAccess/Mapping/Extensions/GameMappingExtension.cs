using ProjectVR.DataAccess.Models;

namespace ProjectVR.DataAccess.Mapping.Extensions
{
    internal static class GameMappingExtension
    {
        public static Domain.Entities.Game MapToDomainEntity(this Game game)
        {
            Domain.Entities.Game gameEntity = new Domain.Entities.Game
            {
                Id = game.Id,
                Name = game.Name
            };
            return gameEntity;
        }
    }
}
