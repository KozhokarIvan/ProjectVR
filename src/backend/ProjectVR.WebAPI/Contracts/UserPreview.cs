using System;

namespace ProjectVR.WebAPI.Contracts;

public class UserPreview
{
    public Guid Guid { get; init; }
    public string Username { get; init; } = null!;
    public string? Avatar { get; init; }
    public required string FriendStatus { get; init; }
}