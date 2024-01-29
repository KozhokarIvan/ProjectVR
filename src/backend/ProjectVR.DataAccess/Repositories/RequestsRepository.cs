using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectVR.DataAccess.Mapping;
using ProjectVR.Domain.Interfaces.Repositories;
using ProjectVR.Domain.Models;

namespace ProjectVR.DataAccess.Repositories;

public class RequestsRepository : IRequestsRepository
{
    private readonly ProjectVRDbContext _context;

    public RequestsRepository(ProjectVRDbContext context)
    {
        _context = context;
    }

    public async Task<Friend?> GetExactRequestByUsersGuids(Guid fromUserGuid, Guid toUserGuid)
    {
        var friend = await _context.Requests
            .AsNoTracking()
            .Where(f => f.FromUserGuid == fromUserGuid && f.ToUserGuid == toUserGuid)
            .FirstOrDefaultAsync();
        return friend?.MapToDomain();
    }

    public async Task<Friend?> GetRequestByUserGuids(Guid firstUserGuid, Guid secondUserGuid)
    {
        var friend = await _context.Requests
            .AsNoTracking()
            .Where(f =>
                (f.FromUserGuid == firstUserGuid && f.ToUserGuid == secondUserGuid)
                ||
                (f.ToUserGuid == firstUserGuid && f.FromUserGuid == secondUserGuid))
            .FirstOrDefaultAsync();
        return friend?.MapToDomain();
    }

    public async Task<bool> AddAcceptedAtDate(int friendEntryId, DateTimeOffset date)
    {
        var friendEntry = await _context.Requests.FirstOrDefaultAsync(f => f.Id == friendEntryId);
        if (friendEntry is null)
            return false;
        friendEntry.AcceptedAt = date;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ClearAcceptedAtDate(int friendEntryId)
    {
        var friendEntry = await _context.Requests.FirstOrDefaultAsync(f => f.Id == friendEntryId);
        if (friendEntry is null)
            return false;
        friendEntry.AcceptedAt = null;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task CreateRequest(Guid fromUserGuid, Guid toUserGuid)
    {
        var friendEntry = new Entities.Request
        {
            FromUserGuid = fromUserGuid,
            ToUserGuid = toUserGuid
        };
        await _context.Requests.AddAsync(friendEntry);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteRequest(int friendEntryId)
    {
        var friendEntry = await _context.Requests.FirstOrDefaultAsync(f => f.Id == friendEntryId);
        if (friendEntry is null)
            return false;
        _context.Requests.Remove(friendEntry);
        await _context.SaveChangesAsync();
        return true;
    }
}