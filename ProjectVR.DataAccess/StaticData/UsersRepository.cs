using ProjectVR.Domain.Entities;
using ProjectVR.Domain.Interfaces.Repositories;
using ProjectVR.WebAPI.StaticData;

namespace ProjectVR.DataAccess.StaticData
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
            List<Userinfo> foundUsers = _usersData.Users
                .Where(u =>
                (game is null || u.Games.Any(g => g.Name.Contains(game)))
                &&
                (vrset is null || u.VrSets.Any(vs => vs.Name.Contains(vrset))))
                .ToList();
            return foundUsers;
        }
    }
}
