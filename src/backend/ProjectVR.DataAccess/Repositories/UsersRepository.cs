﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectVR.DataAccess.Mapping;
using ProjectVR.Domain.Interfaces.Repositories;
using ProjectVR.Domain.Models;

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
                    !u.Friends.Any(f => f.AcceptedAt != null
                                        && (f.FromUserGuid == ignoredUserGuid || f.ToUserGuid == ignoredUserGuid)))
            )
            .Include(user => user.Games)
            .ThenInclude(userGame => userGame.Game)
            .Include(ui => ui.VrSets)
            .ThenInclude(userVrSet => userVrSet.VrSet)
            .Skip(offset)
            .Take(limit)
            .OrderByDescending(u => u.CreatedAt)
            .ToArrayAsync();

        var users = usersFromDb
            .Select(u => u.MapToDomain(ignoredUserGuid))
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
                    !u.Friends.Any(f =>
                        f.AcceptedAt != null && (f.FromUserGuid == ignoredUserGuid || f.ToUserGuid == ignoredUserGuid)))
            )
            .Include(user => user.Games)
            .ThenInclude(userGame => userGame.Game)
            .Include(ui => ui.VrSets)
            .ThenInclude(userVrSet => userVrSet.VrSet)
            //if ignored user variable isnt empty and request is unaccepted we include his relation with the ignored user
            .Include(u =>
                u.Friends.Where(f => !ignoredUserGuid.HasValue || f.AcceptedAt == null
                    && (f.ToUserGuid == ignoredUserGuid || f.FromUserGuid == ignoredUserGuid))
            )
            .Skip(offset)
            .Take(limit)
            .OrderByDescending(u => u.CreatedAt)
            .ToArrayAsync();

        var users = usersFromDb
            .Select(u => u.MapToDomain(ignoredUserGuid))
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
            .Take(numberOfUsers)
            .OrderByDescending(u => u.CreatedAt)
            .ToArrayAsync();
        var users = usersFromDb
            .Select(u => u.MapToDomain(ignoredUserGuid))
            .ToArray();
        return users;
    }

    public async Task<UserSummary?> GetUserByUsername(string username)
    {
        var foundUser = await _context.Usersinfo
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Username == username);
        var user = foundUser?.MapToDomain();
        return user;
    }
}