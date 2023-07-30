using System;

namespace ProjectVR.Domain.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public UserInfo From { get; set; } = null!;
        public UserInfo To { get; set; } = null!;
        public DateTimeOffset? AcceptedAt { get; set; }
    }
}
