﻿namespace ProjectVR.WebAPI.Contracts.Mapping;

internal static class UserGameMappingExtension
{
    internal static UserGame MapToApi(this Domain.Models.UserGame domainUserGame)
    {
        var userGame = new UserGame
        {
            GameId = domainUserGame.GameId,
            GameName = domainUserGame.GameName,
            Rating = domainUserGame.Rating,
            IsFavorite = domainUserGame.IsFavorite,
            GameIcon = domainUserGame.GameIcon
        };
        return userGame;
    }
}