using System;
using System.Collections.Generic;
using ProjectVR.Domain.Models.Enums;

namespace ProjectVR.Domain.Models;

public class UserSummary
{
    public const int MinUsernameLength = 4;
    public const int MaxUsernameLength = 32;
    public const int MinAvatarLength = 8;
    public const int MaxAvatarLength = 256;

    public Guid Guid { get; set; }
    public string Username { get; set; } = null!;
    public string? Avatar { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset LastSeen { get; set; }
    public ICollection<UserGame> Games { get; set; } = new List<UserGame>();
    public ICollection<UserVrSet> VrSets { get; set; } = new List<UserVrSet>();
    public FriendStatus FriendStatus { get; set; } = FriendStatus.Undefined;
}