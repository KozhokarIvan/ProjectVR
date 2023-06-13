using System;

namespace ProjectVR.DataAccess.Models
{
    public class UserVrset
    {
        public int Id { get; set; }
        public UserInfo User { get; set; }
        public Guid UserGuid { get; set; }
        public VrSet Vrset { get; set; }
        public int VrsetId { get; set; }
        public bool IsFavorite { get; set; }
    }
}
