using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ProjectVR.Domain.Models.User.Validation;

public static class UserValidationExtensions
{
    public static bool IsUsernameTooShort(this string username)
    {
        return username.Length < UserConstraints.MinUsernameLength;
    }

    public static bool IsUsernameTooLong(this string username)
    {
        return username.Length > UserConstraints.MaxUsernameLength;
    }

    public static bool IsUsernameValid(this string username)
    {
        return Regex.IsMatch(username, UserConstraints.UsernameRegex);
    }

    public static bool IsEmailValid(this string email)
    {
        return new EmailAddressAttribute().IsValid(email);
    }

    public static bool IsAvatarTooLong(this string avatar)
    {
        return avatar.Length > UserConstraints.MaxAvatarLength;
    }

    public static bool IsAvatarValid(this string avatar)
    {
        return Uri.IsWellFormedUriString(avatar, UriKind.Absolute);
    }
}