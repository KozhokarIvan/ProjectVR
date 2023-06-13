using System;

namespace ProjectVR.DataAccess.Models
{
    public class Friends
    {
        public int Id { get; set; }
        public UserInfo From { get; set; }
        public Guid FromUserGuid { get; set; }
        public UserInfo To { get; set; }
        public Guid ToUserGuid { get; set; }
        public DateTimeOffset AcceptedAt { get; set; }
    }
}
