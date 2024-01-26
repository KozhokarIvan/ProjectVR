namespace ProjectVR.Domain.Models.User.Validation;

public enum UserValidationError
{
    TooShortUsername,
    TooLongUsername,
    InvalidUsername,
    InvalidEmail,
    TooLongAvatar,
    InvalidAvatar
}