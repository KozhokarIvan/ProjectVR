using System;
using ProjectVR.Domain.Models.Enums;

namespace ProjectVR.Domain.Models;

public class UserBase
{
    public const int MinUsernameLength = 4;
    public const int MaxUsernameLength = 32;
    public const int MinAvatarLength = 8;
    public const int MaxAvatarLength = 256;
    public Guid Guid { get; set; }
    public string Username { get; set; } = null!;
    public string? Avatar { get; set; }
    public FriendStatus FriendStatus { get; set; } = FriendStatus.Undefined;
}