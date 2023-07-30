using System;
using System.Threading.Tasks;
using ProjectVR.Domain.Models;

namespace ProjectVR.Domain.Interfaces.Services
{
    public interface IUsersService
    {
        public Task<UserInfo[]> FindUsers(string? game, string? vrset, Guid? userToExcludeGuid = null);
        public Task<UserInfo[]> GetRandomUsers(Guid? userToExcludeGuid = null);
    }
}
