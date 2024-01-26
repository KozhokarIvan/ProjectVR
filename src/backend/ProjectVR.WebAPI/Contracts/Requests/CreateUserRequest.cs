namespace ProjectVR.WebAPI.Contracts.Requests;

public class CreateUserRequest
{
    public string Username { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string? Avatar { get; init; }
    public string Password { get; init; } = null!;
}