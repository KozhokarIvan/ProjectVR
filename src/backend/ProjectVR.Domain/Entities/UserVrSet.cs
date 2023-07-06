namespace ProjectVR.Domain.Entities
{
    public class UserVrSet
    {
        public VrSet VrSet { get; set; } = null!;
        public bool IsFavorite { get; set; }
    }
}
