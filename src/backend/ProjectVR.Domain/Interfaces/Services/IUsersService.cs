using System;
using System.Threading.Tasks;
using ProjectVR.Domain.Models;

namespace ProjectVR.Domain.Interfaces.Services
{
    public interface IUsersService
    {
        public Task<UserSummary[]> FindUsers(string? game, string? vrset, Guid? userToExcludeGuid = null);
        public Task<UserSummary[]> GetRandomUsers(Guid? userToExcludeGuid = null);
    }
}
