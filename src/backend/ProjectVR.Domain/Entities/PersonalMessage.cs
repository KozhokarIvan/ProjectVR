namespace ProjectVR.Domain.Entities
{
    public class PersonalMessage
    {
        public int Id { get; set; }
        public PersonalChat Chat { get; set; } = null!;
        public UserInfo From { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
