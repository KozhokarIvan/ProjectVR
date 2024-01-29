namespace ProjectVR.Domain.Models.User.Validation;

public static class UserConstraints
{
    public const int MinUsernameLength = 6;
    public const int MaxUsernameLength = 32;
    public const int MaxAvatarLength = 512;
    public const string UsernameRegex = @"^[a-zA-Z\d\-_\.]+$";
}