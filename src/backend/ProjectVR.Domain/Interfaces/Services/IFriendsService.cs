using System;
using System.Threading.Tasks;

namespace ProjectVR.Domain.Interfaces.Services
{
    public interface IFriendsService
    {
        public Task<bool> AddFriend(Guid from, Guid to);
    }
}
