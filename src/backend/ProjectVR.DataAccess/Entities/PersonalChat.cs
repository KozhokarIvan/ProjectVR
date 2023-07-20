using System;

namespace ProjectVR.DataAccess.Entities
{
    public class PersonalChat
    {
        public int Id { get; set; }
        public UserInfo FirstUser { get; set; }
        public Guid FirstUserGuid { get; set; }
        public UserInfo SecondUser { get; set; }
        public Guid SecondUserGuid { get; set; }
    }
}
