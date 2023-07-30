using System;
using System.Threading.Tasks;
using ProjectVR.Domain.Models;

namespace ProjectVR.Domain.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        public Task<UserInfo[]> FindUsers(string? gameName, string? vrsetName, Guid? userToExcludeGuid = null);
        public Task<UserInfo[]> GetRandomUsers(Guid? userToExcludeGuid = null);
        public Task<UserInfo?> GetUserByUsername(string username);
        public Task CreateFriendRequest(Guid fromUserGuid, Guid toUserGuid);
        public Task<bool> RequestExists(Guid fromUserGuid, Guid toUserGuid);
        public Task<bool> AcceptFriendRequest(Guid userThatSentRequestGuid, Guid userThatAcceptedRequestGuid);
    }
}
