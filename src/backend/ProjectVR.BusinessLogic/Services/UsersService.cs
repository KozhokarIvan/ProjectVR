using ProjectVR.Domain.Interfaces.Repositories;
using ProjectVR.Domain.Interfaces.Services;
using ProjectVR.Domain.Models;

namespace ProjectVR.BusinessLogic.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        public UsersService(IUsersRepository userRepository)
        {
            _usersRepository = userRepository;
        }

        public async Task<UserSummary[]> FindUsersByGameOrVrset(string? game, string? vrset, int offset, int limit, Guid? signedUser = null)
        {
            UserSummary[] users = await _usersRepository.FindUsersByGameOrVrset(game, vrset, offset, limit, signedUser);
            return users;
        }

        public async Task<UserSummary[]> GetRandomUsers(int numberOfUsers, Guid? signedUser = null)
        {
            UserSummary[] users = await _usersRepository.GetRandomUsers(numberOfUsers, signedUser);
            return users;
        }
    }
}
