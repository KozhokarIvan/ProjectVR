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

    public Task<UserSummary[]> FindUsersByGameOrVrSet(string query, int offset, int limit,
        Guid? signedUserGuid = null)
        => _usersRepository.FindUsersByQuery(query, offset, limit, signedUserGuid);


    public Task<UserSummary[]> FindUsersByGameAndVrset(string? game, string? vrset, int offset, int limit,
        Guid? signedUserGuid = null)
        => _usersRepository.FindUsersByGameAndVrSet(game, vrset, offset, limit, signedUserGuid);

    public Task<UserSummary[]> GetRandomUsers(int numberOfUsers, Guid? signedUserGuid = null)
        => _usersRepository.GetRandomUsers(numberOfUsers, signedUserGuid);
}