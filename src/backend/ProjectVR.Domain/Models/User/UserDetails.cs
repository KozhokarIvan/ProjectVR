using System;
using System.Collections.Generic;
using ProjectVR.Domain.Models.Enums;

namespace ProjectVR.Domain.Models.User;

public class UserDetails
{
    private UserDetails(Guid guid, string username, string? avatar, FriendStatus friendStatus,
        ICollection<UserGame> games, ICollection<UserVrSet> vrSets,
        ICollection<UserPreview> friends, DateTimeOffset createdAt, DateTimeOffset lastSeen)
    {
        Guid = guid;
        Username = username;
        Avatar = avatar;
        FriendStatus = friendStatus;
        Games = games;
        VrSets = vrSets;
        Friends = friends;
        CreatedAt = createdAt;
        LastSeen = lastSeen;
    }

    public Guid Guid { get; }
    public string Username { get; }
    public string? Avatar { get; }
    public FriendStatus FriendStatus { get; }
    public ICollection<UserGame> Games { get; }
    public ICollection<UserVrSet> VrSets { get; }
    public ICollection<UserPreview> Friends { get; }
    public DateTimeOffset CreatedAt { get; }
    public DateTimeOffset LastSeen { get; }

    public static UserDetails Create(Guid guid, string username, string? avatar, FriendStatus friendStatus,
        ICollection<UserGame> games, ICollection<UserVrSet> vrSets,
        ICollection<UserPreview> friends, DateTimeOffset createdAt, DateTimeOffset lastSeen)
    {
        return new UserDetails(guid, username, avatar, friendStatus, games, vrSets, friends, createdAt, lastSeen);
    }
}