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
        public async Task<UserInfo[]> FindUsers(string? game, string? vrset)
        {
            UserInfo[] users = await _usersRepository.FindUsers(game, vrset);
            return users;
        }

        public async Task<UserInfo[]> GetRandomUsers()
        {
            UserInfo[] users = await _usersRepository.GetRandomUsers();
            return users;
        }
    }
}
