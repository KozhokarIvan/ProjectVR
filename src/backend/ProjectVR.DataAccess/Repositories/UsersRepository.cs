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
    }
}
