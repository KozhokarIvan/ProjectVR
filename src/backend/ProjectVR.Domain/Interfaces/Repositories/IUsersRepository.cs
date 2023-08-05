using System;
using System.Threading.Tasks;
using ProjectVR.Domain.Models;

namespace ProjectVR.Domain.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        public Task<UserSummary[]> FindUsers(string? gameName, string? vrsetName, Guid? userToExcludeGuid = null);
        public Task<UserSummary[]> GetRandomUsers(Guid? userToExcludeGuid = null);
        public Task<UserSummary?> GetUserByUsername(string username);
    }
}
