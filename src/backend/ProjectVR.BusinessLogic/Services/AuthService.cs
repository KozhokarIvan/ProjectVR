using ProjectVR.Domain.Interfaces.Repositories;
using ProjectVR.Domain.Interfaces.Services;
using ProjectVR.Domain.Models;

namespace ProjectVR.BusinessLogic.Services;

public class AuthService : IAuthService
{
    private readonly IUsersRepository _usersRepository;

    public AuthService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<UserSummary?> Login(string username)
    {
        var loggedUser = await _usersRepository.GetUserByUsername(username);
        return loggedUser;
    }
}