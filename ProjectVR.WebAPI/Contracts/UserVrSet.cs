namespace ProjectVR.WebAPI.Contracts
{
    public class UserVrSet
    {
        public int VrSetId { get; set; }
        public string Name { get; set; } = null!;
        public bool IsFavorite { get; set; }
    }
}
