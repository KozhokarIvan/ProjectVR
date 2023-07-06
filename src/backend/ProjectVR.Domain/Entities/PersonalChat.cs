namespace ProjectVR.Domain.Entities
{
    public class PersonalChat
    {
        public int Id { get; set; }
        public UserInfo FirstUser { get; set; } = null!;
        public UserInfo SecondUser { get; set; } = null!;
    }
}
