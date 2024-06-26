﻿using System;

namespace ProjectVR.WebAPI.Contracts.Responses;

public class GetDetailedUserInfoResponse
{
    public Guid Guid { get; init; }

    public string Username { get; init; } = null!;

    public string? Avatar { get; init; }

    public UserGame[] Games { get; init; } = Array.Empty<UserGame>();

    public UserVrSet[] VrSets { get; init; } = Array.Empty<UserVrSet>();

    public UserPreview[] Friends { get; init; } = Array.Empty<UserPreview>();

    required public string FriendStatus { get; init; }

    public DateTimeOffset CreatedAt { get; init; }

    public DateTimeOffset LastSeen { get; init; }
}