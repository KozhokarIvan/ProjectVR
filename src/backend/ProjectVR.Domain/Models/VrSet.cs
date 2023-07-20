namespace ProjectVR.Domain.Models
{
    public class VrSet
    {
        public const int MinVrSetNameLength = 4;
        public const int MaxVrSetNameLength = 256;
        public const int MinVrSetIconLength = 8;
        public const int MaxVrSetIconLength = 256;
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Icon { get; set; } = null!;
    }
}
