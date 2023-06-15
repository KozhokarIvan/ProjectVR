using System;
using System.Collections.Generic;

namespace ProjectVR.Domain.Entities
{
    public class UserInfo
    {
        public Guid Guid { get; set; }
        public string Username { get; set; } = null!;
        public string? Avatar { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset LastSeen { get; set; }
        public List<UserGame> Games { get; set; } = null!;
        public List<UserVrSet> VrSets { get; set; } = null!;
    }
}
