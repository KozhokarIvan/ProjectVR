using ProjectVR.Domain.Interfaces.Repositories;
using ProjectVR.Domain.Interfaces.Services;
using ProjectVR.Domain.Models;

namespace ProjectVR.BusinessLogic.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository userRepository)
    {
        _usersRepository = userRepository;
    }

    public async Task<UserSummary[]> FindUsersByGameOrVrSet(string query, int offset, int limit,
        Guid? signedUserGuid = null)
    {
        var users = await _usersRepository.FindUsersByGameOrVrSet(query, offset, limit, signedUserGuid);
        return users;
    }

    public async Task<UserSummary[]> FindUsersByGameAndVrset(string? game, string? vrset, int offset, int limit,
        Guid? signedUserGuid = null)
    {
        var users = await _usersRepository.FindUsersByGameAndVrset(game, vrset, offset, limit, signedUserGuid);
        return users;
    }

    public async Task<UserSummary[]> GetRandomUsers(int numberOfUsers, Guid? signedUserGuid = null)
    {
        var users = await _usersRepository.GetRandomUsers(numberOfUsers, signedUserGuid);
        return users;
    }
}