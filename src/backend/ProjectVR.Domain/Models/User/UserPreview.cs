using System;
using ProjectVR.Domain.Models.Enums;

namespace ProjectVR.Domain.Models.User;

public class UserPreview
{
    private UserPreview(Guid guid, string username, string? avatar, FriendStatus friendStatus)
    {
        Guid = guid;
        Username = username;
        Avatar = avatar;
        FriendStatus = friendStatus;
    }

    public Guid Guid { get; }
    public string Username { get; }
    public string? Avatar { get; }
    public FriendStatus FriendStatus { get; }

    public static UserPreview Create(Guid guid, string username, string? avatar, FriendStatus friendStatus)
    {
        return new UserPreview(guid, username, avatar, friendStatus);
    }
}