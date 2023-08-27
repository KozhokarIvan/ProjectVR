using System;

namespace ProjectVR.Domain.Models
{
    public class Friend
    {
        public int Id { get; init; }
        public Guid FromUserGuid { get; init; }
        public Guid ToUserGuid { get; init; }
    }
}
