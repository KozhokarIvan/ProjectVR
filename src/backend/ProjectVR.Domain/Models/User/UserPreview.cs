using System;
using ProjectVR.Domain.Models.Enums;

namespace ProjectVR.Domain.Models.User;

public class UserPreview
{
    public Guid Guid { get; }
    public string Username { get; }
    public string? Avatar { get; }
    public FriendStatus FriendStatus { get; }

    private UserPreview(Guid guid, string username, string? avatar, FriendStatus friendStatus)
    {
        Guid = guid;
        Username = username;
        Avatar = avatar;
        FriendStatus = friendStatus;
    }

    public static UserPreview Create(Guid guid, string username, string? avatar, FriendStatus friendStatus)
        => new(guid, username, avatar, friendStatus);
}