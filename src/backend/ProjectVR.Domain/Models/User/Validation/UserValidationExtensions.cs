using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ProjectVR.Domain.Models.User.Validation;

public static class UserValidationExtensions
{
    public static bool IsUsernameTooShort(this string username)
        => username.Length < UserConstraints.MinUsernameLength;

    public static bool IsUsernameTooLong(this string username)
        => username.Length > UserConstraints.MaxUsernameLength;

    public static bool IsUsernameValid(this string username)
        => Regex.IsMatch(username, UserConstraints.UsernameRegex);

    public static bool IsEmailValid(this string email)
        => new EmailAddressAttribute().IsValid(email);

    public static bool IsAvatarTooLong(this string avatar)
        => avatar.Length > UserConstraints.MaxAvatarLength;

    public static bool IsAvatarValid(this string avatar)
        => Uri.IsWellFormedUriString(avatar, UriKind.Absolute);
}