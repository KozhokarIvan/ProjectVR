namespace ProjectVR.Domain.Models
{
    public class UserVrSet
    {
        public VrSet VrSet { get; set; } = null!;
        public bool IsFavorite { get; set; }
    }
}
