using System.Threading.Tasks;
using ProjectVR.Domain.Models;

namespace ProjectVR.Domain.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        public Task<UserInfo[]> FindUsers(string? game, string? vrset);
        public Task<UserInfo[]> GetRandomUsers();
    }
}
