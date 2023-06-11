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
        public List<Userinfo> FindUsers(string? game, string? vrset)
        {
            List<Userinfo> users = _usersRepository.FindUsers(game, vrset);
            return users;
        }
    }
}
