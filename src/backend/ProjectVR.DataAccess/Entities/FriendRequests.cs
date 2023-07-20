using System;

namespace ProjectVR.DataAccess.Entities
{
    public class FriendRequests
    {
        public int Id { get; set; }
        public UserInfo From { get; set; }
        public Guid FromUserGuid { get; set; }
        public UserInfo To { get; set; }
        public Guid ToUserGuid { get; set; }
        public DateTimeOffset SentAt { get; set; }
    }
}
