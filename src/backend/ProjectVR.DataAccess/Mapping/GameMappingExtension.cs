using ProjectVR.DataAccess.Entities;

namespace ProjectVR.DataAccess.Mapping
{
    internal static class GameMappingExtension
    {
        public static Domain.Models.Game MapToDomainModel(this Game game)
        {
            Domain.Models.Game gameEntity = new Domain.Models.Game
            {
                Id = game.Id,
                Name = game.Name,
                Icon = game.Icon
            };
            return gameEntity;
        }
    }
}
