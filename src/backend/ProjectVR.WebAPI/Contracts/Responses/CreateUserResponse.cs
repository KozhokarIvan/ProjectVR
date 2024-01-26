namespace ProjectVR.WebAPI.Contracts.Responses;

public class CreateUserResponse
{
    public required string UserCreationStatus { get; init; }
    public User? User { get; init; }
}