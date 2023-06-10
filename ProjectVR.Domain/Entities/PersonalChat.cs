namespace ProjectVR.Domain.Entities
{
    public class PersonalChat
    {
        public int Id { get; set; }
        public Userinfo FirstUser { get; set; } = null!;
        public Userinfo SecondUser { get; set; } = null!;
    }
}
