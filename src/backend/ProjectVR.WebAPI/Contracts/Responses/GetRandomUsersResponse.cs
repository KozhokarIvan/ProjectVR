using System;

namespace ProjectVR.WebAPI.Contracts.Responses
{
    public class GetRandomUsersResponse
    {
        public Guid Guid { get; set; }
        public string Username { get; set; } = null!;
        public string? Avatar { get; set; }
        public UserGame[] Games { get; set; } = Array.Empty<UserGame>();
        public UserVrSet[] VrSets { get; set; } = Array.Empty<UserVrSet>();
    }
}
