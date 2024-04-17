using System;

namespace ProjectVR.WebAPI.Contracts.Responses;

public class LoginResponse
{
    public Guid UserGuid { get; init; }

    public string Username { get; init; } = null!;

    public string? Avatar { get; init; }
}