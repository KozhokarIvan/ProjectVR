using System;
using System.Threading.Tasks;
using ProjectVR.Domain.Models;

namespace ProjectVR.Domain.Interfaces.Services
{
    public interface IUsersService
    {
        Task<UserSummary[]> FindUsersByGameOrVrset(string? game, string? vrset, int offset, int limit, Guid? signedUser = null);
        Task<UserSummary[]> GetRandomUsers(int numberOfUsers, Guid? signedUser = null);
    }
}
