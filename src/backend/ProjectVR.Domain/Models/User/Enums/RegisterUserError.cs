namespace ProjectVR.Domain.Models.User.Enums;

public enum RegisterUserError
{
    InvalidUsername,
    InvalidEmail,
    InvalidAvatar,
    UsernameIsTaken,
    EmailIsTaken
}