using System;

namespace ProjectVR.DataAccess.Models
{
    public class UserVrSet
    {
        public int Id { get; set; }
        public UserInfo Owner { get; set; } = null!;
        public Guid OwnerGuid { get; set; }
        public VrSet VrSet { get; set; } = null!;
        public int VrSetId { get; set; }
        public bool IsFavorite { get; set; }
    }
}
