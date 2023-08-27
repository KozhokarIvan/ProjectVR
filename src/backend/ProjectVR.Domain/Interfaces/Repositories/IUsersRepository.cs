using System;
using System.Threading.Tasks;
using ProjectVR.Domain.Models;

namespace ProjectVR.Domain.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        Task<UserSummary[]> FindUsersByGameOrVrset(string? gameName, string? vrsetName, int offset, int limit, Guid? ignoredUserGuid = null);
        Task<UserSummary[]> GetRandomUsers(int numberOfUsers, Guid? ignoredUserGuid = null);
        Task<UserSummary?> GetUserByUsername(string username);
    }
}
