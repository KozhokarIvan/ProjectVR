using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectVR.DataAccess.Mapping;
using ProjectVR.Domain.Interfaces.Repositories;
using ProjectVR.Domain.Models;

namespace ProjectVR.DataAccess.Repositories
{
    public class FriendsRepository : IFriendsRepository
    {
        private readonly ProjectVRDbContext _context;
        public FriendsRepository(ProjectVRDbContext context)
        {
            _context = context;
        }
        public async Task<Friend?> GetExactFriendEntryByUsersGuids(Guid fromUserGuid, Guid toUserGuid)
        {
            var friend = await _context.Friends
                .AsNoTracking()
                .Where(f => f.FromUserGuid == fromUserGuid && f.ToUserGuid == toUserGuid)
                .FirstOrDefaultAsync();
            return friend?.MapToDomain();
        }
        public async Task<Friend?> GetFriendEntryByUserGuids(Guid firstUserGuid, Guid secondUserGuid)
        {
            var friend = await _context.Friends
                .AsNoTracking()
                .Where(f =>
                    f.FromUserGuid == firstUserGuid && f.ToUserGuid == secondUserGuid 
                    ||
                    f.ToUserGuid == firstUserGuid && f.FromUserGuid == secondUserGuid)
                .FirstOrDefaultAsync();
            return friend?.MapToDomain();
        }

        public async Task<bool> AddFriendEntryDate(int friendEntryId, DateTimeOffset date)
        {
            var friendEntry = await _context.Friends.FirstOrDefaultAsync(f => f.Id == friendEntryId);
            if (friendEntry is null)
                return false;
            friendEntry.AcceptedAt = date;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ClearFriendEntryDate(int friendEntryId)
        {
            var friendEntry = await _context.Friends.FirstOrDefaultAsync(f => f.Id == friendEntryId);
            if (friendEntry is null)
                return false;
            friendEntry.AcceptedAt = null;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task CreateFriendEntry(Guid fromUserGuid, Guid toUserGuid)
        {
            var friendEntry = new Entities.Friend
            {
                FromUserGuid = fromUserGuid,
                ToUserGuid = toUserGuid
            };
            await _context.Friends.AddAsync(friendEntry);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteFriendEntry(int friendEntryId)
        {
            var friendEntry = await _context.Friends.FirstOrDefaultAsync(f => f.Id == friendEntryId);
            if (friendEntry is null)
                return false;
            _context.Friends.Remove(friendEntry);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
