namespace ProjectVR.WebAPI.Contracts.Responses;

public class CreateUserResponse
{
    required public string UserCreationStatus { get; init; }

    public User? User { get; init; }
}