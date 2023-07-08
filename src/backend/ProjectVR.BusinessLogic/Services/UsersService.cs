using ProjectVR.Domain.Entities;
using ProjectVR.Domain.Interfaces.Repositories;
using ProjectVR.Domain.Interfaces.Services;

namespace ProjectVR.BusinessLogic.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        public UsersService(IUsersRepository userRepository)
        {
            _usersRepository = userRepository;
        }
        public async Task<List<UserInfo>> FindUsers(string? game, string? vrset)
        {
            List<UserInfo> users = await _usersRepository.FindUsers(game, vrset);
            return users;
        }

        public async Task<List<UserInfo>> GetRandomUsers()
        {
            List<UserInfo> users = await _usersRepository.GetRandomUsers();
            return users;
        }
    }
}
