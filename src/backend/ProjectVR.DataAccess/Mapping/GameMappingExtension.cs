using ProjectVR.Domain.Models;

namespace ProjectVR.DataAccess.Mapping;

internal static class GameMappingExtension
{
    public static Game MapToDomainModel(this Entities.Game game)
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