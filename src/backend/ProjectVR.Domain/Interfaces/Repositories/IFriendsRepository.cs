using System;
using System.Threading.Tasks;
using ProjectVR.Domain.Models;

namespace ProjectVR.Domain.Interfaces.Repositories
{
    public interface IFriendsRepository
    {
        Task CreateFriendEntry(Guid userGuid, Guid friendUserGuid);
        Task<Friend?> GetExactFriendEntryByUsersGuids(Guid userGuid, Guid friendUserGuid);
        Task<Friend?> GetFriendEntryByUserGuids(Guid firstUserGuid, Guid secondUserGuid);
        Task<bool> ClearFriendEntryDate(int friendEntryId);
        Task<bool> AddFriendEntryDate(int friendEntryId, DateTimeOffset date);
        Task<bool> DeleteFriendEntry(int friendEntryId);
    }
}
