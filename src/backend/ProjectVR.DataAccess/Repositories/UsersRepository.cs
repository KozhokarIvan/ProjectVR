using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectVR.DataAccess.Entities;
using ProjectVR.DataAccess.Mapping;
using ProjectVR.Domain.Interfaces.Repositories;
using ProjectVR.Domain.Models.User;
using UserVrSet = ProjectVR.Domain.Models.User.UserVrSet;

namespace ProjectVR.DataAccess.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly ProjectVRDbContext _context;

    public UsersRepository(ProjectVRDbContext context)
    {
        _context = context;
    }

    public async Task<UserSummary[]> FindUsersByGameAndVrSet(string? game, string? vrSet, int offset, int limit,
        Guid? ignoredUserGuid = null)
    {
        var usersFromDb = await _context.Usersinfo
            .AsNoTracking()
            .Where(u =>
                (string.IsNullOrWhiteSpace(game) || u.Games.Any(g
                    => EF.Functions.ILike(g.Game.Name, '%' + game + '%')))
                &&
                (string.IsNullOrWhiteSpace(vrSet) || u.VrSets.Any(v
                    => EF.Functions.ILike(v.VrSet.Name, '%' + vrSet + '%')))
                && (!ignoredUserGuid.HasValue || u.Guid != ignoredUserGuid)
                && (!ignoredUserGuid.HasValue ||
                    !u.OutgoingRequests.Any(f =>
                        f.AcceptedAt != null && f.ToUserGuid == ignoredUserGuid)
                    ||
                    !u.IncomingRequests.Any(f =>
                        f.AcceptedAt != null && f.FromUserGuid == ignoredUserGuid))
            )
            .Include(user => user.Games)
            .ThenInclude(userGame => userGame.Game)
            .Include(ui => ui.VrSets)
            .ThenInclude(userVrSet => userVrSet.VrSet)
            .Include(u =>
                u.OutgoingRequests.Where(f => ignoredUserGuid.HasValue && f.AcceptedAt == null
                                                                       && f.ToUserGuid == ignoredUserGuid.Value))
            .Include(u =>
                u.IncomingRequests.Where(f => ignoredUserGuid.HasValue && f.AcceptedAt == null
                                                                       && f.FromUserGuid == ignoredUserGuid.Value))
            .Skip(offset)
            .Take(limit)
            .OrderByDescending(u => u.CreatedAt)
            .ToArrayAsync();

        var users = usersFromDb
            .Select(u => u.MapToDomainUserSummary(ignoredUserGuid))
            .ToArray();
        return users;
    }

    public async Task<UserSummary[]> FindUsersByQuery(string query, int offset, int limit,
        Guid? ignoredUserGuid = null)
    {
        var isQueryEmpty = string.IsNullOrWhiteSpace(query);
        query = '%' + query + '%';
        var usersFromDb = await _context.Usersinfo
            .AsNoTracking()
            .Where(u =>
                (
                    //if query is empty then dont even apply the search
                    isQueryEmpty
                    || u.Games.Any(g => EF.Functions.ILike(g.Game.Name, query))
                    | u.VrSets.Any(v => EF.Functions.ILike(v.VrSet.Name, query)))
                //if ignored user variable isnt empty we exclude him from results
                && (!ignoredUserGuid.HasValue || u.Guid != ignoredUserGuid)
                //if ignored user variable isnt empty we exclude ignored user's friends from results
                && (!ignoredUserGuid.HasValue ||
                    !u.OutgoingRequests.Any(f =>
                        f.AcceptedAt != null && f.ToUserGuid == ignoredUserGuid)
                    ||
                    !u.IncomingRequests.Any(f =>
                        f.AcceptedAt != null && f.FromUserGuid == ignoredUserGuid))
            )
            .Include(user => user.Games)
            .ThenInclude(userGame => userGame.Game)
            .Include(ui => ui.VrSets)
            .ThenInclude(userVrSet => userVrSet.VrSet)
            //if ignored user variable isnt empty and request is unaccepted we include his relation with the ignored user
            .Include(u =>
                u.OutgoingRequests.Where(f => ignoredUserGuid.HasValue
                                              && f.ToUserGuid == ignoredUserGuid.Value))
            .Include(u =>
                u.IncomingRequests.Where(f => ignoredUserGuid.HasValue
                                              && f.FromUserGuid == ignoredUserGuid.Value))
            .Skip(offset)
            .Take(limit)
            .OrderByDescending(u => u.CreatedAt)
            .ToArrayAsync();

        var users = usersFromDb
            .Select(u => u.MapToDomainUserSummary(ignoredUserGuid))
            .ToArray();
        return users;
    }

    public async Task<UserSummary[]> GetRandomUsers(int numberOfUsers, Guid? ignoredUserGuid = null)
    {
        var usersFromDb = await _context.Usersinfo
            .AsNoTracking()
            .OrderBy(u => EF.Functions.Random())
            .Where(u => !ignoredUserGuid.HasValue || u.Guid != ignoredUserGuid)
            .Include(user => user.Games)
            .ThenInclude(userGame => userGame.Game)
            .Include(ui => ui.VrSets)
            .ThenInclude(userVrSet => userVrSet.VrSet)
            .Include(u =>
                u.OutgoingRequests.Where(f => ignoredUserGuid.HasValue
                                              && f.ToUserGuid == ignoredUserGuid.Value))
            .Include(u =>
                u.IncomingRequests.Where(f => ignoredUserGuid.HasValue
                                              && f.FromUserGuid == ignoredUserGuid.Value))
            .Take(numberOfUsers)
            .ToArrayAsync();
        var users = usersFromDb
            .Select(u => u.MapToDomainUserSummary(ignoredUserGuid))
            .ToArray();
        return users;
    }

    public async Task<UserSummary?> GetUserByUsername(string username)
    {
        var foundUser = await _context.Usersinfo
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Username == username);
        var user = foundUser?.MapToDomainUserSummary();
        return user;
    }

    public async Task<UserDetails?> GetUserDetailsByUsername(string username, Guid? ignoredUserGuid = null)
    {
        var foundUser = await _context
            .Usersinfo
            .AsNoTracking()
            .Where(u => u.Username == username)
            .Include(u => u.Games)
            .ThenInclude(g => g.Game)
            .Include(u => u.VrSets)
            .ThenInclude(u => u.VrSet)
            .Include(u => u.IncomingRequests)
            .ThenInclude(f => f.From)
            .Include(u => u.OutgoingRequests)
            .ThenInclude(f => f.To)
            .FirstOrDefaultAsync();
        var user = foundUser?.MapToDomainUserDetails(ignoredUserGuid);
        return user;
    }

    public async Task<UserDetails> CreateUser(string username, string? avatar)
    {
        var user = new Users
        {
            Username = username,
            Avatar = avatar,
            CreatedAt = DateTimeOffset.Now
        };
        _context.Usersinfo.Add(user);
        await _context.SaveChangesAsync();
        return user.MapToDomainUserDetails();
    }

    public Task<bool> DoesUsernameExist(string username)
    {
        return _context.Usersinfo.AnyAsync(u => EF.Functions.ILike(u.Username, username));
    }

    public async Task<UserVrSet[]> GetUserVrSets(Guid userGuid, int limit, int offset)
    {
        var vrSetsFromDb = await _context.UserVrSets
            .Where(vrset => vrset.OwnerGuid == userGuid)
            .OrderBy(vrSet => vrSet.VrSet.Name)
            .Skip(offset)
            .Take(limit)
            .Include(userVrSet => userVrSet.VrSet)
            .ToArrayAsync();
        var vrSets = vrSetsFromDb.Select(vrSet => vrSet.MapToDomain()).ToArray();
        return vrSets;
    }

    public async Task<UserVrSet[]> GetAllUserVrSets(Guid userGuid)
    {
        var vrSetsFromDb = await _context.UserVrSets
            .Where(vrset => vrset.OwnerGuid == userGuid)
            .OrderBy(vrSet => vrSet.VrSet.Name)
            .Include(userVrSet => userVrSet.VrSet)
            .ToArrayAsync();
        var vrSets = vrSetsFromDb.Select(vrSet => vrSet.MapToDomain()).ToArray();
        return vrSets;
    }

    public async Task AddUserVrSets(Guid userGuid, UpdateUserVrSet[] vrSets)
    {
        var user = await _context.Usersinfo
            .Where(u => u.Guid == userGuid)
            .Include(u => u.VrSets)
            .FirstAsync();
        foreach (var vrSet in vrSets)
        {
            if (user.VrSets.FirstOrDefault(vs => vs.VrSetId == vrSet.VrSetId) is not null)
                continue;
            user.VrSets.Add(new Entities.UserVrSet
            {
                OwnerGuid = userGuid,
                VrSetId = vrSet.VrSetId,
                IsFavorite = vrSet.IsFavorite
            });
        }

        await _context.SaveChangesAsync();
    }

    public async Task EditUserVrSets(Guid userGuid, UpdateUserVrSet[] vrSets)
    {
        var user = await _context.Usersinfo
            .Where(u => u.Guid == userGuid)
            .Include(u => u.VrSets)
            .FirstAsync();
        foreach (var vrSet in vrSets)
        {
            var vrSetToEdit = user.VrSets.FirstOrDefault(vs => vs.VrSetId == vrSet.VrSetId);
            if (vrSetToEdit is null) continue;
            vrSetToEdit.IsFavorite = vrSet.IsFavorite;
        }

        await _context.SaveChangesAsync();
    }

    public async Task DetachUserVrSets(Guid userGuid, int[] vrSetIds)
    {
        var user = await _context.Usersinfo
            .Where(u => u.Guid == userGuid)
            .Include(u => u.VrSets)
            .FirstAsync();
        foreach (var vrSetId in vrSetIds)
        {
            var vrSetToRemove = user.VrSets.FirstOrDefault(vs => vs.VrSetId == vrSetId);
            if (vrSetToRemove is null) continue;
            _context.Remove(vrSetToRemove);
        }

        await _context.SaveChangesAsync();
    }
}