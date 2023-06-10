using ProjectVR.Domain.Entities;

namespace ProjectVR.Domain.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        public List<Userinfo> FindUsers(string? game, string? vrset);
    }
}
