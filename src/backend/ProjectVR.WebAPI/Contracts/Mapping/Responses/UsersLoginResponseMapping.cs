using ProjectVR.Domain.Models;
using ProjectVR.WebAPI.Contracts.Responses;

namespace ProjectVR.WebAPI.Contracts.Mapping.Responses
{
    internal static class UsersLoginResponseMapping
    {
        internal static LoginResponse MapToLoginResponse(this UserSummary userInfo)
        {
            LoginResponse response = new LoginResponse()
            {
                UserGuid = userInfo.Guid,
                Username = userInfo.Username,
                Avatar = userInfo.Avatar
            };
            return response;
        }
    }
}
