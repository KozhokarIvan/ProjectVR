using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectVR.DataAccess.Mapping;
using ProjectVR.Domain.Entities;
using ProjectVR.Domain.Interfaces.Repositories;

namespace ProjectVR.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ProjectVRDbContext _context;
        public UsersRepository(ProjectVRDbContext context)
        {
            _context = context;
        }
        public async Task<List<UserInfo>> FindUsers(string? game, string? vrset)
        {
            List<UserInfo> users = await _context.Usersinfo
                .AsNoTracking()
                .Where(u =>
                (game == null || u.Games.Any(g => g.Game.Name.ToUpper().Contains(game.ToUpper())))
                &&
                (vrset == null || u.VrSets.Any(vs => vs.VrSet.Name.ToUpper().Contains(vrset.ToUpper()))))
                .Include(user => user.Games)
                .ThenInclude(usergame => usergame.Game)
                .Include(ui => ui.VrSets)
                .ThenInclude(uservrset => uservrset.VrSet)
                .Select(u => u.MapToDomainEntity())
                .ToListAsync();

            return users;
        }

        public async Task<List<UserInfo>> GetRandomUsers()
        {
            List<UserInfo> users = await _context.Usersinfo
                .AsNoTracking()
                .OrderBy(u => EF.Functions.Random())
                .Take(5)
                .Include(user => user.Games)
                .ThenInclude(usergame => usergame.Game)
                .Include(ui => ui.VrSets)
                .ThenInclude(uservrset => uservrset.VrSet)
                .Select(u => u.MapToDomainEntity())
                .ToListAsync();

            return users;
        }
    }
}
