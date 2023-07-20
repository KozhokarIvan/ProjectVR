using System.Threading.Tasks;
using ProjectVR.Domain.Models;

namespace ProjectVR.Domain.Interfaces.Services
{
    public interface IUsersService
    {
        public Task<UserInfo[]> FindUsers(string? game, string? vrset);
        public Task<UserInfo[]> GetRandomUsers();
    }
}
