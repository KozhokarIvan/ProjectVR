using System;
using System.Collections.Generic;

namespace ProjectVR.DataAccess.Models
{
    public class UserInfo
    {
        public Guid Guid { get; set; }
        public string Username { get; set; }
        public string Avatar { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset LastSeen { get; set; }
        public List<UserGame> Games { get; set; }
        public List<VrSet> Vrsets { get; set; }

    }
}
