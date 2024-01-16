using ProjectVR.Domain.Models.Enums;

namespace ProjectVR.WebAPI.Contracts.Mapping.Enums;

internal static class FriendStatusMappingExtension
{
    internal static string MapToResponse(this FriendStatus domainFriendStatus)
    {
        var friendStatus = domainFriendStatus switch
        {
            FriendStatus.Stranger => nameof(FriendStatus.Stranger),
            FriendStatus.Friend => nameof(FriendStatus.Friend),
            FriendStatus.Incoming => nameof(FriendStatus.Incoming),
            FriendStatus.Outgoing => nameof(FriendStatus.Outgoing),
            FriendStatus.Self => nameof(FriendStatus.Self),
            FriendStatus.Unauthorized => nameof(FriendStatus.Unauthorized),
            _ => nameof(FriendStatus.Undefined)
        };
        return string.Intern(friendStatus);
    }
}