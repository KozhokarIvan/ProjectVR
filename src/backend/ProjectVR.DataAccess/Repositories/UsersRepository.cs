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

        public async Task<bool> AcceptFriendRequest(Guid userThatSentRequestGuid, Guid userThatAcceptedRequestGuid)
        {
            var request = await _context.Friends
                .FirstOrDefaultAsync(f => f.FromUserGuid == userThatSentRequestGuid && f.ToUserGuid == userThatAcceptedRequestGuid);
            if (request is null) return false;
            request.AcceptedAt = DateTimeOffset.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task CreateFriendRequest(Guid fromUserGuid, Guid toUserGuid)
        {
            var request = new Entities.Friend
            {
                FromUserGuid = fromUserGuid,
                ToUserGuid = toUserGuid
            };
            await _context.Friends.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> RequestExists(Guid fromUserGuid, Guid toUserGuid)
        {
            bool doesRequestExist = await _context.Friends
                .AsNoTracking()
                .AnyAsync(friend => friend.FromUserGuid == fromUserGuid && friend.ToUserGuid == toUserGuid);
            return doesRequestExist;
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
    }
}
