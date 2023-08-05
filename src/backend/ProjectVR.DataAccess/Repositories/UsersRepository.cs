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

        public async Task<UserSummary[]> FindUsers(string? game, string? vrset, Guid? userGuidToExclude = null)
        {
            bool isThereUserToExclude = userGuidToExclude is null;
            UserSummary[] users = await _context.Usersinfo
                .AsNoTracking()
                .Where(u =>
                (game == null || u.Games.Any(g => g.Game.Name.ToUpper().Contains(game.ToUpper())))
                &&
                (vrset == null || u.VrSets.Any(vs => vs.VrSet.Name.ToUpper().Contains(vrset.ToUpper())))
                &&
                isThereUserToExclude ? true : u.Guid != userGuidToExclude)
                .Include(user => user.Games)
                    .ThenInclude(usergame => usergame.Game)
                .Include(ui => ui.VrSets)
                    .ThenInclude(uservrset => uservrset.VrSet)
                .Select(u => u.MapToDomainModel())
                .ToArrayAsync() ?? Array.Empty<UserSummary>();

            return users;
        }

        public async Task<UserSummary[]> GetRandomUsers(Guid? userGuidToExclude = null)
        {
            bool isThereUserToExclude = userGuidToExclude is null;
            UserSummary[] users = await _context.Usersinfo
                .AsNoTracking()
                .OrderBy(u => EF.Functions.Random())
                .Where(u => isThereUserToExclude ? true : u.Guid != userGuidToExclude)
                .Take(5)
                .Include(user => user.Games)
                    .ThenInclude(usergame => usergame.Game)
                .Include(ui => ui.VrSets)
                    .ThenInclude(uservrset => uservrset.VrSet)
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
