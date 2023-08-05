using System;
using System.Threading.Tasks;

namespace ProjectVR.Domain.Interfaces.Repositories
{
    public interface IFriendsRepository
    {
        public Task CreateFriendEntry(Guid fromUserGuid, Guid toUserGuid);
        public Task<int?> GetExactFriendEntryIdByUsersGuids(Guid fromUserGuid, Guid toUserGuid);
        public Task<int?> GetFriendEntryByUserGuids(Guid firstUserGuid, Guid secondUserGuid);
        public Task<bool> ClearFriendEntryDate(int friendEntryId);
        public Task<bool> AddFriendEntryDate(int friendEntryId, DateTimeOffset date);
        public Task<bool> DeleteFriendEntry(int friendEntryId);
    }
}
