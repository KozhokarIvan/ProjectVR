using System;
using System.Collections.Generic;
using System.Linq;
using ProjectVR.DataAccess.Mapping.Extensions;
using ProjectVR.DataAccess.Models;
using ProjectVR.Domain.Entities;
using ProjectVR.Domain.Interfaces.Repositories;
using ProjectVR.WebAPI.StaticData;

namespace ProjectVR.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UsersData _usersData;
        public UsersRepository(UsersData usersData)
        {
            _usersData = usersData;
        }
        public List<Userinfo> FindUsers(string? game, string? vrset)
        {
            List<UserInfo> users = _usersData.Users
                .Where(u =>
                (game is null || u.Games.Any(g => g.Game.Name.Contains(game, StringComparison.OrdinalIgnoreCase)))
                &&
                (vrset is null || u.Vrsets.Any(vs => vs.Name.Contains(vrset, StringComparison.OrdinalIgnoreCase))))
                .ToList();
            List<Userinfo> userEntities = users.Select(u => u.MapToDomainEntity()).ToList();
            return userEntities;
        }
    }
}
