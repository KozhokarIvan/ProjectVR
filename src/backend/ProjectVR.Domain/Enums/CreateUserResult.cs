namespace ProjectVR.Domain.Enums;

public enum CreateUserResult
{
    Created,
    InvalidUsername,
    InvalidEmail,
    InvalidPassword,
    EmailIsUsed,
    UsernameIsTaken,
    UnknownError
}