using ProjectVR.DataAccess.Models;

namespace ProjectVR.DataAccess.Mapping
{
    internal static class GameMappingExtension
    {
        public static Domain.Entities.Game MapToDomain(this Game game)
        {
            Domain.Entities.Game gameEntity = new Domain.Entities.Game
            {
                Id = game.Id,
                Name = game.Name,
                Icon = game.Icon
            };
            return gameEntity;
        }
    }
}
