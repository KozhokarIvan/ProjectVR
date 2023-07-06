using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectVR.Domain.Entities;

namespace ProjectVR.Domain.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        public Task<List<UserInfo>> FindUsers(string? game, string? vrset);
    }
}
