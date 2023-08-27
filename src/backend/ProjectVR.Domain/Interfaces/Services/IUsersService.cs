using System;
using System.Threading.Tasks;
using ProjectVR.Domain.Models;

namespace ProjectVR.Domain.Interfaces.Services
{
    public interface IUsersService
    {
        Task<UserSummary[]> FindUsersByGameOrVrSet(string query, int offset, int limit, Guid? signedUserGuid = null);
        Task<UserSummary[]> FindUsersByGameAndVrset(string? game, string? vrset, int offset, int limit, Guid? signedUserGuid = null);
        Task<UserSummary[]> GetRandomUsers(int numberOfUsers, Guid? signedUserGuid = null);
    }
}
