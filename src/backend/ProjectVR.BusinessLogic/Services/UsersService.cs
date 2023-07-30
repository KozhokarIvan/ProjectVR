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

        public async Task<UserInfo[]> FindUsers(string? game, string? vrset, Guid? userToExcludeGuid = null)
        {
            UserInfo[] users = await _usersRepository.FindUsers(game, vrset, userToExcludeGuid);
            return users;
        }

        public async Task<UserInfo[]> GetRandomUsers(Guid? userToExcludeGuid = null)
        {
            UserInfo[] users = await _usersRepository.GetRandomUsers(userToExcludeGuid);
            return users;
        }
    }
}
