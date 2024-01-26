using ProjectVR.Domain.Interfaces.Repositories;
using ProjectVR.Domain.Interfaces.Services;
using ProjectVR.Domain.Models;
using ProjectVR.Domain.Models.User;

namespace ProjectVR.BusinessLogic.Services;

public class AuthService : IAuthService
{
    private readonly IUsersRepository _usersRepository;

    public AuthService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public Task<UserSummary?> Login(string username)
        => _usersRepository.GetUserByUsername(username);
}