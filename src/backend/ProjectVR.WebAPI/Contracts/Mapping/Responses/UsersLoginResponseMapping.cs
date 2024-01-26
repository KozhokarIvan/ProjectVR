using ProjectVR.Domain.Models;
using ProjectVR.Domain.Models.User;
using ProjectVR.WebAPI.Contracts.Responses;

namespace ProjectVR.WebAPI.Contracts.Mapping.Responses;

internal static class UsersLoginResponseMapping
{
    internal static LoginResponse MapToApi(this UserSummary userInfo)
    {
        var response = new LoginResponse
        {
            UserGuid = userInfo.Guid,
            Username = userInfo.Username,
            Avatar = userInfo.Avatar
        };
        return response;
    }
}