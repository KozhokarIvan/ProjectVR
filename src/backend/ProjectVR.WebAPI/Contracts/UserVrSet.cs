namespace ProjectVR.WebAPI.Contracts
{
    public class UserVrSet
    {
        public string VrSetName { get; set; } = null!;
        public string VrSetIcon { get; set; } = null!;
        public bool IsFavorite { get; set; }
    }
}
