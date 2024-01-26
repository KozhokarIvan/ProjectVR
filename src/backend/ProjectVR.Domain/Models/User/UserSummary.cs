using System;
using System.Collections.Generic;
using ProjectVR.Domain.Models.Enums;

namespace ProjectVR.Domain.Models.User;

public class UserSummary
{
    public Guid Guid { get; }
    public string Username { get; }
    public string? Avatar { get; }
    public FriendStatus FriendStatus { get; }
    public ICollection<UserGame> Games { get; }
    public ICollection<UserVrSet> VrSets { get; }

    private UserSummary(Guid guid, string username, string? avatar, FriendStatus friendStatus,
        ICollection<UserGame> games, ICollection<UserVrSet> vrSets)
    {
        Guid = guid;
        Username = username;
        Avatar = avatar;
        FriendStatus = friendStatus;
        Games = games;
        VrSets = vrSets;
    }

    public static UserSummary Create(Guid guid, string username, string? avatar, FriendStatus friendStatus,
        ICollection<UserGame> games, ICollection<UserVrSet> vrSets)
        => new(guid, username, avatar, friendStatus, games, vrSets);
}