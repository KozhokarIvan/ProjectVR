using System;

namespace ProjectVR.WebAPI.Contracts.Responses;

public class GetUsersResponse
{
    public Guid Guid { get; init; }

    public string Username { get; init; } = null!;

    public string? Avatar { get; init; }

    public UserGame[] Games { get; init; } = Array.Empty<UserGame>();

    public UserVrSet[] VrSets { get; init; } = Array.Empty<UserVrSet>();

    public required string FriendStatus { get; init; }
}