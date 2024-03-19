using ProjectVR.Domain;
using ProjectVR.Domain.Interfaces.Repositories;
using ProjectVR.Domain.Interfaces.Services;
using ProjectVR.Domain.Models;
using ProjectVR.Domain.Models.User;
using ProjectVR.Domain.Models.User.Enums;
using ProjectVR.Domain.Models.User.Validation;

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


    public Task<UserSummary[]> FindUsersByGameAndVrSet(string? game, string? vrset, int offset, int limit,
        Guid? signedUserGuid = null)
        => _usersRepository.FindUsersByGameAndVrSet(game, vrset, offset, limit, signedUserGuid);

    public Task<UserSummary[]> GetRandomUsers(int numberOfUsers, Guid? signedUserGuid = null)
        => _usersRepository.GetRandomUsers(numberOfUsers, signedUserGuid);

    public Task<UserDetails?> GetUserDetailsByUsername(string username, Guid? signedUserGuid = null)
        => _usersRepository.GetUserDetailsByUsername(username, signedUserGuid);

    public async Task<Result<UserDetails, RegisterUserError>> CreateUser(string username, string email, string? avatar,
        string password)
    {
        var result = RegisterUserModel.Create(username, email, avatar, password);
        if (result.IsSuccess)
        {
            var validatedUser = result.Value;
            var isUsernameTaken = await _usersRepository.DoesUsernameExist(username);
            if (isUsernameTaken)
                return new Result<UserDetails, RegisterUserError>(RegisterUserError.UsernameIsTaken);
            var user = await _usersRepository.CreateUser(validatedUser.Username, validatedUser.Avatar);
            return new Result<UserDetails, RegisterUserError>(user);
        }

        RegisterUserError error;
        switch (result.ErrorStatus)
        {
            case UserValidationError.TooShortUsername:
            case UserValidationError.TooLongUsername:
            case UserValidationError.InvalidUsername:
                error = RegisterUserError.InvalidUsername;
                break;
            case UserValidationError.InvalidEmail:
                error = RegisterUserError.InvalidEmail;
                break;
            case UserValidationError.TooLongAvatar:
            case UserValidationError.InvalidAvatar:
                error = RegisterUserError.InvalidAvatar;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return new Result<UserDetails, RegisterUserError>(error);
    }

    public Task<UserVrSet[]> GetUserVrSets(Guid userGuid, int limit, int offset)
        => _usersRepository.GetUserVrSets(userGuid, limit, offset);

    public async Task SetUserVrSets(Guid userGuid, UpdateUserVrSet[] vrSets)
    {
        var allVrSets = await _usersRepository.GetAllUserVrSets(userGuid);
        var newVrSets = vrSets
            .Where(vs => allVrSets
                .All(oldVs => vs.VrSetId != oldVs.VrSetId))
            .ToArray();
        var addNewVrSetsTask = _usersRepository.AddUserVrSets(userGuid, newVrSets);
        var detachedVrSetIds = allVrSets
            .Select(v => v.VrSetId)
            .Except(vrSets
                .Select(v => v.VrSetId))
            .ToArray();
        await addNewVrSetsTask;
        var detachVrSetsTask = _usersRepository.DetachUserVrSets(userGuid, detachedVrSetIds);
        var editedVrSets = vrSets
            .Where(vs =>
                allVrSets
                    .FirstOrDefault(oldVs => oldVs.VrSetId == vs.VrSetId)?.IsFavorite != vs.IsFavorite)
            .ToArray();
        await detachVrSetsTask;
        await _usersRepository.EditUserVrSets(userGuid, editedVrSets);
    }
}