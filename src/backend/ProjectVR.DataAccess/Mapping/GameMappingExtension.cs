using ProjectVR.Domain.Models;
using ProjectVR.Domain.Models.Game;

namespace ProjectVR.DataAccess.Mapping;

internal static class GameMappingExtension
{
    public static Game MapToDomain(this Entities.Game game)
    {
        var gameEntity = new Game
        {
            Id = game.Id,
            Name = game.Name,
            Icon = game.Icon
        };
        return gameEntity;
    }
}