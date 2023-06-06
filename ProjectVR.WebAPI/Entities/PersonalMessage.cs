namespace ProjectVR.WebAPI.Entities
{
    public class PersonalMessage
    {
        public int Id { get; set; }
        public PersonalChat Chat { get; set; } = null!;
        public Userinfo From { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
