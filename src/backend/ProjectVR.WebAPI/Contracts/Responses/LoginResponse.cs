using System;

namespace ProjectVR.WebAPI.Contracts.Responses
{
    public class LoginResponse
    {
        public Guid UserGuid { get; set; }
        public string Username { get; set; } = null!;
        public string? Avatar { get; set; }
    }
}
