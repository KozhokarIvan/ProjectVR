using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectVR.DataAccess.Mapping;
using ProjectVR.Domain.Interfaces.Repositories;
using ProjectVR.Domain.Models;

namespace ProjectVR.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ProjectVRDbContext _context;
        public UsersRepository(ProjectVRDbContext context)
        {
            _context = context;
        }
        public async Task<FriendRequest?> GetFriendRequestByUserGuids(Guid fromUserGuid, Guid toUserGuid)
        {
            Entities.FriendRequest? result = await _context.FriendRequests
                .Include(request => request.From)
                .ThenInclude(user => user.OutgoingFriendRequests)
                .Include(request => request.To)
                .SingleOrDefaultAsync(fr => fr.ToUserGuid == fromUserGuid && fr.FromUserGuid == toUserGuid);
            if (result is null) return null;
            UserInfo from = result.From.MapToDomainModel();
            UserInfo to = result.To.MapToDomainModel();
            FriendRequest friendRequest = result.MapToDomainModel(from, to);
            return friendRequest;
        }

        public async Task<UserInfo[]> FindUsers(string? game, string? vrset)
        {
            UserInfo[] users = await _context.Usersinfo
                .AsNoTracking()
                .Where(u =>
                (game == null || u.Games.Any(g => g.Game.Name.ToUpper().Contains(game.ToUpper())))
                &&
                (vrset == null || u.VrSets.Any(vs => vs.VrSet.Name.ToUpper().Contains(vrset.ToUpper()))))
                .Include(user => user.Games)
                .ThenInclude(usergame => usergame.Game)
                .Include(ui => ui.VrSets)
                .ThenInclude(uservrset => uservrset.VrSet)
                .Select(u => u.MapToDomainModel())
                .ToArrayAsync() ?? Array.Empty<UserInfo>();

            return users;
        }

        public async Task<UserInfo[]> GetRandomUsers()
        {
            UserInfo[] users = await _context.Usersinfo
                .AsNoTracking()
                .OrderBy(u => EF.Functions.Random())
                .Take(5)
                .Include(user => user.Games)
                .ThenInclude(usergame => usergame.Game)
                .Include(ui => ui.VrSets)
                .ThenInclude(uservrset => uservrset.VrSet)
                .Select(u => u.MapToDomainModel())
                .ToArrayAsync() ?? Array.Empty<UserInfo>();

            return users;
        }

        public async Task<UserInfo?> GetUserByUsername(string username)
        {
            var foundUser = await _context.Usersinfo
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.Username == username);
            if (foundUser is null) return null;
            UserInfo? user = foundUser.MapToDomainModel();

            return user;
        }
        public async Task<bool> CreateFriendAndDeleteFriendRequest(Guid userWhoSentGuid, Guid userWhoAcceptedGuid)
        {
            Entities.Friend friendEntry = new Entities.Friend()
            {
                FromUserGuid = userWhoSentGuid,
                ToUserGuid = userWhoAcceptedGuid,
                AcceptedAt = DateTime.UtcNow
            };
            await _context.Friends.AddAsync(friendEntry);
            _context.FriendRequests.Remove(await _context.FriendRequests
                .SingleAsync(req => req.From.Guid == userWhoSentGuid && req.To.Guid == userWhoAcceptedGuid));
            await _context.SaveChangesAsync();
            bool isFriendAdded = true;
            bool isFriendRequestDeleted = true;
            return isFriendRequestDeleted && isFriendAdded;
        }
        public async Task<bool> CreateFriendRequest(Guid from, Guid to)
        {
            await _context.FriendRequests.AddAsync(new Entities.FriendRequest()
            {
                FromUserGuid = from,
                ToUserGuid = to,
                SentAt = DateTime.UtcNow
            });
            await _context.SaveChangesAsync();
            bool isCreated = true;
            return isCreated;
        }
    }
}
