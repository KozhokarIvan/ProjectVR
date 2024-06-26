﻿using ProjectVR.Domain.Models.User.Validation;

namespace ProjectVR.Domain.Models.User;

public class RegisterUserModel
{
    private RegisterUserModel(string username, string email, string? avatar, string password)
    {
        Username = username;
        Email = email;
        Avatar = avatar;
        Password = password;
    }

    public string Username { get; }

    public string Email { get; }

    public string? Avatar { get; }

    public string Password { get; }

    public static Result<RegisterUserModel, UserValidationError> Create(
        string username,
        string email,
        string? avatar,
        string password)
    {
        UserValidationError? status;
        avatar = string.IsNullOrWhiteSpace(avatar) ? null : avatar;
        if (username.IsUsernameTooShort())
        {
            status = UserValidationError.TooShortUsername;
        }
        else if (username.IsUsernameTooLong())
        {
            status = UserValidationError.TooLongUsername;
        }
        else if (!username.IsUsernameValid())
        {
            status = UserValidationError.InvalidUsername;
        }
        else if (!email.IsEmailValid())
        {
            status = UserValidationError.InvalidEmail;
        }
        else if (avatar is not null && avatar.IsAvatarTooLong())
        {
            status = UserValidationError.TooLongAvatar;
        }
        else if (avatar is not null && !avatar.IsAvatarValid())
        {
            status = UserValidationError.InvalidAvatar;
        }
        else
        {
            var user = new RegisterUserModel(username, email, avatar, password);
            return new Result<RegisterUserModel, UserValidationError>(user);
        }

        return new Result<RegisterUserModel, UserValidationError>(status.Value);
    }
}