using System;
using System.Threading.Tasks;
using ProjectVR.Domain.Models;

namespace ProjectVR.Domain.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        public Task<UserInfo[]> FindUsers(string? gameName, string? vrsetName);
        public Task<UserInfo[]> GetRandomUsers();
        public Task<UserInfo?> GetUserByUsername(string username);
        public Task CreateFriendRequest(Guid fromUserGuid, Guid toUserGuid);
        public Task<bool> RequestExists(Guid fromUserGuid, Guid toUserGuid);
        public Task<bool> AcceptFriendRequest(Guid userThatSentRequestGuid, Guid userThatAcceptedRequestGuid);
    }
}
