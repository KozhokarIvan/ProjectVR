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

        public async Task<UserSummary[]> FindUsers(string? game, string? vrset, Guid? userToExcludeGuid = null)
        {
            UserSummary[] users = await _usersRepository.FindUsers(game, vrset, userToExcludeGuid);
            return users;
        }

        public async Task<UserSummary[]> GetRandomUsers(Guid? userToExcludeGuid = null)
        {
            UserSummary[] users = await _usersRepository.GetRandomUsers(userToExcludeGuid);
            return users;
        }
    }
}
