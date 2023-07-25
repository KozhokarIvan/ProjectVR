using ProjectVR.Domain.Interfaces.Repositories;
using ProjectVR.Domain.Interfaces.Services;
using ProjectVR.Domain.Models;

namespace ProjectVR.BusinessLogic.Services
{
    public class FriendsService : IFriendsService
    {
        private readonly IUsersRepository _usersRepository;
        public FriendsService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<bool> AddFriend(Guid from, Guid to)
        {

            FriendRequest? request = await _usersRepository.GetFriendRequestByUserGuids(from, to);
            bool doesRequestExist = request is not null;
            if (!doesRequestExist)
            {
                bool isRequested = await _usersRepository.CreateFriendRequest(from, to);
                return isRequested;
            }
            bool isAdded = await _usersRepository.CreateFriendAndDeleteFriendRequest(to, from);
            return isAdded;
        }
    }
}
