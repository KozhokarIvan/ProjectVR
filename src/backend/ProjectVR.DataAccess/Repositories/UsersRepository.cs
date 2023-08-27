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

        public async Task<UserSummary[]> FindUsersByGameOrVrset(string? game, string? vrset, int offset, int limit, Guid? ignoredUserGuid = null)
        {
            UserSummary[] users = await _context.Usersinfo
            .AsNoTracking()
            .Where(u =>
                game == null || u.Games.Any(g => EF.Functions.ILike(g.Game.Name, game))
                &&
                vrset == null || u.VrSets.Any(v => EF.Functions.ILike(v.VrSet.Name, game))
                ||
                vrset == null || u.VrSets.Any(v => EF.Functions.ILike(v.VrSet.Name, vrset)
                &&
                game == null || u.Games.Any(g => EF.Functions.ILike(g.Game.Name, vrset))
                && !ignoredUserGuid.HasValue ? true : u.Guid != ignoredUserGuid
                && !ignoredUserGuid.HasValue ? true : u.Friends.Any(f => f.ToUserGuid != ignoredUserGuid && f.FromUserGuid != ignoredUserGuid)))
             .Include(user => user.Games)
                .ThenInclude(usergame => usergame.Game)
            .Include(ui => ui.VrSets)
                .ThenInclude(uservrset => uservrset.VrSet)
                .Skip(offset)
                .Take(limit)
                .Select(u => u.MapToDomainModel())
                .ToArrayAsync() ?? Array.Empty<UserSummary>();

            return users;
        }

        public async Task<UserSummary[]> GetRandomUsers(int numberOfUsers, Guid? ignoredUserGuid = null)
        {
            UserSummary[] users = await _context.Usersinfo
                .AsNoTracking()
                .OrderBy(u => EF.Functions.Random())
                .Where(u => !ignoredUserGuid.HasValue ? true : u.Guid != ignoredUserGuid)
                .Include(user => user.Games)
                    .ThenInclude(usergame => usergame.Game)
                .Include(ui => ui.VrSets)
                    .ThenInclude(uservrset => uservrset.VrSet)
                .Take(numberOfUsers)
                .Select(u => u.MapToDomainModel())
                .ToArrayAsync() ?? Array.Empty<UserSummary>();

            return users;
        }

        public async Task<UserSummary?> GetUserByUsername(string username)
        {
            var foundUser = await _context.Usersinfo
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Username == username);
            if (foundUser is null) return null;
            UserSummary? user = foundUser.MapToDomainModel();

            return user;
        }
    }
}
