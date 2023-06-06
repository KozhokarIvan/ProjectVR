namespace ProjectVR.WebAPI.Entities
{
    public class Userinfo
    {
        public Guid Guid { get; set; }
        public string Username { get; set; } = null!;
        public string? Avatar { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset LastSeen { get; set; }
        public List<Game> Games { get; set; } = null!;
        public List<VrSet> VrSets { get; set; } = null!;
    }
}
