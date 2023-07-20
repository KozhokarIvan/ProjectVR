namespace ProjectVR.WebAPI.Contracts.Mapping
{
    internal static class UserGameMappingExtension
    {
        internal static UserGame MapToApi(this Domain.Models.UserGame domainUserGame)
        {
            UserGame userGame = new UserGame
            {
                GameId = domainUserGame.Game.Id,
                Name = domainUserGame.Game.Name,
                Rating = domainUserGame.Rating,
                IsFavorite = domainUserGame.IsFavorite,
                Icon = domainUserGame.Game.Icon
            };
            return userGame;
        }
    }
}
